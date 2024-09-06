using GW2CraftCalculator.Interfaces;
using GW2CraftCalculator.Interfaces.Translation;
using GW2CraftCalculator.Interfaces.Utils;
using GW2CraftCalculator.Models.Attributes;
using GW2CraftCalculator.Models.Enums;
using GW2CraftCalculator.Models.Logic;
using GW2CraftCalculator.Models.ViewModels;
using GW2CraftCalculator.Utils.Extensions;
using Spectre.Console;
using Spectre.Console.Rendering;
using System.Text;

namespace GW2CraftCalculator;

public class ConsoleProcessor : IConsoleProcessor
{
    private readonly ITranslationsProcessor _translationsProcessor;
    private readonly ILanguageConverter _languageConverter;
    private readonly IMysticForgeUiFilterHandler _mysticForgeUiFilterHandler;

    public ConsoleProcessor() { }

    public ConsoleProcessor(ITranslationsProcessor translationsProcessor, ILanguageConverter languageConverter, IMysticForgeUiFilterHandler filterHandler)
    {
        _translationsProcessor = translationsProcessor;
        _languageConverter = languageConverter;
        _mysticForgeUiFilterHandler = filterHandler;
    }

    public void WriteGreeting()
    {
        string appDisplayNameShort = "GW2-CC";
        string fontSmallPath = @"FIGletFont/small.flf";
        FigletText figletAppNameShort = CreateFigletText(appDisplayNameShort, Color.DarkOrange, fontSmallPath);

        string selectorEftiWall = "s";
        string fontEftiWallPath = @"FIGletFont/eftiwall.flf";
        FigletText figletEftiWallResearcher = CreateFigletText(selectorEftiWall, Color.Grey37, fontEftiWallPath);

        string appDisplayNameFull = "Guild Wars 2 Craft Calculator";
        Rule appNameFullRule = CreateRule(appDisplayNameFull, Color.White);

        WriteRenderables(
            figletAppNameShort,
            figletEftiWallResearcher,
            appNameFullRule
        );
    }

    public async Task PrintViewModels(Language language, Task<IEnumerable<ItemView>> viewModelsTask, int run)
    {
        string tableTitel = await _translationsProcessor.GetTranslation(TranslationCode.TableTitelViewModels, language);
        Table table = new()
        {
            Title = new($"{tableTitel}: {run}"),
            ShowRowSeparators = true,
            ShowFooters = false,
        };

        string[] columns = 
        [
            await _translationsProcessor.GetTranslation(TranslationCode.TableColumnCreatedItem, language),
            await _translationsProcessor.GetTranslation(TranslationCode.TableColumnItemCraftingPath, language)
        ];

        table.AddColumns(columns).Alignment(Justify.Center).RoundedBorder();
        TableColumn profitableColumn = new(await _translationsProcessor.GetTranslation(TranslationCode.TableColumnIsProfitable, language));
        profitableColumn.Alignment(Justify.Center);
        table.AddColumn(profitableColumn);

        foreach (ItemView viewModel in await viewModelsTask)
        {
            Grid rootNode = await CreateRootNode(language, viewModel);
            Tree itemCraftTree = new(rootNode);
            itemCraftTree.Guide(TreeGuide.Line);

            IEnumerable<TreeNode>? nodes = await CreateViewModelComposedItemsNodes(language, viewModel);

            if (nodes != null)
            {
                itemCraftTree.AddNodes(nodes);
            }

            Grid createdItemGrid = await CreateItemCreatedColumn(language, viewModel);
            Markup isProfitable = CreateProfitableColumn(viewModel);
            table.AddRow(createdItemGrid, itemCraftTree, isProfitable);
        }

        string runFinished = await _translationsProcessor.GetTranslation(TranslationCode.RunFinishedViewModels, language);
        Rule runFinishedRule = CreateRule($"{runFinished}: {run}", Color.White);

        AnsiConsole.WriteLine();
        WriteRenderables(table, runFinishedRule);
        AnsiConsole.WriteLine();
    }

    public async Task DisplayTaskProgress(Language language, TranslationCode loadingDescription, params Task[] tasks)
    {
        string loadingDescriptionText = await _translationsProcessor.GetTranslation(loadingDescription, language);

        await AnsiConsole.Progress()
            .AutoClear(true)
            .Columns(
            [
                new TaskDescriptionColumn(),
                new PercentageColumn(),
                new SpinnerColumn()
            ])
            .UseRenderHook(RenderHook)
            .StartAsync(ctx => ConfigureProgressContext(ctx, loadingDescriptionText, tasks));
    }

    public async Task<int> Rerun(Language language, Dictionary<int, int> runToConfigMap)
    {
        int lastRun = runToConfigMap.Keys.Max();
        int runNum = 0;
        string runAgain = await _translationsProcessor.GetTranslation(TranslationCode.WantToRunAgain, language);
        if (!(lastRun > 0 && AnsiConsole.Confirm(runAgain)))
        {
            return runNum;
        }

        string reuseConfig = await _translationsProcessor.GetTranslation(TranslationCode.ReusePreviousConfig, language);
        if (AnsiConsole.Confirm(reuseConfig))
        {
            string whichConfig = await _translationsProcessor.GetTranslation(TranslationCode.WhichPreviousConfigToUse, language);
            TextPrompt<int> prompt = new(whichConfig);
            prompt.DefaultValue(lastRun);
            prompt.ShowDefaultValue = true;
            string errorLessThanOne = await _translationsProcessor.GetTranslation(TranslationCode.ErrorLessThan1, language);
            string errorGreaterThanRuns = await _translationsProcessor.GetTranslation(TranslationCode.ErrorGreaterThanOccuredRuns, language);
            string accuredRuns = await _translationsProcessor.GetTranslation(TranslationCode.OccuredRuns, language);
            prompt.Validate(value =>
            {
                if (value <= 0)
                {
                    return ValidationResult.Error(errorLessThanOne);
                }

                if (value > lastRun)
                {
                    return ValidationResult.Error($"{errorGreaterThanRuns} ({accuredRuns}: {lastRun})");
                }

                return ValidationResult.Success();
            });
            runNum = AnsiConsole.Prompt(prompt);
            return runToConfigMap[runNum];
        }
        runNum = runToConfigMap.Values.Max() + 1;
        return runNum;
    }

    public async Task<bool> UseFilter(Language language)
    {
        string filterTranslation = await _translationsProcessor.GetTranslation(TranslationCode.UseFilter, language);
        bool res = DisplayOnCleanScreen(() => AnsiConsole.Confirm(filterTranslation, false));
        return res;
    }

    public async Task<MysticForgeFilter> DisplayMysticForgeRecipeFilters(Language language, CancellationToken cancellationToken)
    {
        string title = await _translationsProcessor.GetTranslation(TranslationCode.FilterChoicesTitle, language, cancellationToken);
        string moreChoices = await CreateMoreChoicesText(language, cancellationToken);
        string instructions = await CreateInstructionsText(language, cancellationToken);
        string titleColor = "orange3";

        string itemTypes = await _translationsProcessor.GetTranslation(TranslationCode.ItemTypes, language, cancellationToken);
        IReadOnlyDictionary<string, IEnumerable<string>> itemTypesFilters = await _mysticForgeUiFilterHandler.GetItemTypeFilterGroup(language, cancellationToken);
        List<string> selectedFilters = GetFilterGroupValues(title, itemTypes, titleColor, moreChoices, instructions, itemTypesFilters);

        string itemGroups = await _translationsProcessor.GetTranslation(TranslationCode.ItemGroups, language, cancellationToken);
        IReadOnlyDictionary<string, IEnumerable<string>> itemGroupFilters = await _mysticForgeUiFilterHandler.GetItemGroupFilterGroup(language, selectedFilters, cancellationToken);
        List<string> additionalSelectedFilters = GetFilterGroupValues(title, itemGroups, titleColor, moreChoices, instructions, itemGroupFilters);
        selectedFilters.AddRange(additionalSelectedFilters);

        string rarities = await _translationsProcessor.GetTranslation(TranslationCode.Rarities, language, cancellationToken);
        IReadOnlyDictionary<string, IEnumerable<string>> raritiesFilters = await _mysticForgeUiFilterHandler.GetRarityFilterGroup(language, selectedFilters, cancellationToken);
        additionalSelectedFilters = GetFilterGroupValues(title, rarities, titleColor, moreChoices, instructions, raritiesFilters);
        selectedFilters.AddRange(additionalSelectedFilters);

        string tiers = await _translationsProcessor.GetTranslation(TranslationCode.Tiers, language, cancellationToken);
        IReadOnlyDictionary<string, IEnumerable<string>> tiersFilters = await _mysticForgeUiFilterHandler.GetTierFilterGroup(language, selectedFilters, cancellationToken);
        additionalSelectedFilters = GetFilterGroupValues(title, tiers, titleColor, moreChoices, instructions, tiersFilters);
        selectedFilters.AddRange(additionalSelectedFilters);

        await DisplayOnCleanScreen(async () =>
        {
            string helpInfo = await CreateNamesFilterHelpText(language, cancellationToken);
            AnsiConsole.Markup(helpInfo);
            TextPrompt<string> namesPrompt = await CreateItemNameFilterPrompt(language, cancellationToken);
            string nameFilterValue = AnsiConsole.Prompt(namesPrompt);

            if (!string.IsNullOrWhiteSpace(nameFilterValue))
            {
                selectedFilters.Add(nameFilterValue);
            }

            TextPrompt<string> additionalNamesPrompt = await CreateAdditionalItemNameFilterPrompt(language, cancellationToken);

            while (!string.IsNullOrWhiteSpace(nameFilterValue))
            {
                nameFilterValue = AnsiConsole.Prompt(additionalNamesPrompt);
                if (!string.IsNullOrWhiteSpace(nameFilterValue))
                {
                    selectedFilters.Add(nameFilterValue);
                }
            }
        });

        await _mysticForgeUiFilterHandler.SetFilter(language, selectedFilters, cancellationToken);
        MysticForgeFilter filter = _mysticForgeUiFilterHandler.GetFilter()!;
        return filter;
    }

    private List<string> GetFilterGroupValues(string filterType, string groupName, string titleColor, string moreChoices, string instructions, IReadOnlyDictionary<string, IEnumerable<string>> filterGoups)
    {
        string groupTitle = CreateMarkupText(titleColor, " ", filterType, $"\"{groupName}\"");
        MultiSelectionPrompt<string> itemTypesSelect = CreateMultiSelectPrompt(groupTitle, moreChoices, instructions, filterGoups);
        List<string> selectedFilters = DisplayOnCleanScreen(() => AnsiConsole.Prompt(itemTypesSelect));
        return selectedFilters;
    }

    public void WriteColoredText(string text, Color color, string? lineEnding = null, string? link = null)
    {
        Markup markup = CreateMarkup(text, color, lineEnding, link);
        WriteRenderables(markup);
    }

    public void WriteRenderables(params IRenderable[] renderables)
    {
        foreach (IRenderable renderable in renderables)
        {
            AnsiConsole.Write(renderable);
        }
    }

    public string CorrectMarkupText(string text)
    {
        return text.Replace("[", "[[").Replace("]", "]]");
    }

    private async Task<IEnumerable<TreeNode>?> CreateViewModelComposedItemsNodes(Language language, ItemView viewModel, bool isSalvage = false)
    {
        if (viewModel.ComposedItems == null)
        {
            return null;
        }

        List<TreeNode> nodes = [];
        foreach(ItemView composedItem in viewModel.ComposedItems)
        {
            TreeNode? itemNode = null;
            if (composedItem.ComposedItems != null)
            {
                itemNode = await CreateNode(language, composedItem);
            }

            if (isSalvage)
            {
                itemNode ??= await CreateLastSalvageNode(language, composedItem);
            }
            else
            {
                itemNode ??= await CreateLastNode(language, composedItem);
            }

            bool isComposedItemSalvage = isSalvage || composedItem is SalvageItemView;
            IEnumerable<TreeNode>? underlyingNodes = await CreateViewModelComposedItemsNodes(language, composedItem, isComposedItemSalvage);

            if (underlyingNodes != null)
            {
                itemNode.AddNodes(underlyingNodes);
            }
            nodes.Add(itemNode);
        }
        return nodes;
    }

    private static Markup CreateProfitableColumn(ItemView viewModel)
    {
        string profitable = viewModel.IsProfitable() ? Emoji.Known.HeavyDollarSign : Emoji.Known.CrossMark;
        Markup profitableMarkup = new(profitable);
        profitableMarkup.Centered();
        return profitableMarkup;
    }

    private async Task<Grid> CreateItemCreatedColumn(Language language, ItemView viewModel)
    {
        Grid createdItemGrid = new();
        createdItemGrid.AddColumn();
        Grid defaultGrid = await CreateItemDefaultText(language, viewModel);
        string[] totalCost = await CreateTotalValuesText(language, viewModel);
        string[] totalValue = (await CreatePriceText(language, TranslationCode.Value, viewModel, false))!;
        string[] profitItemText = await CreateProfitText(language, viewModel);

        Grid content = new();
        AddGridRows(ref content, totalValue, totalCost, profitItemText);
        createdItemGrid.AddRow(defaultGrid);
        createdItemGrid.AddRow(content);
        return createdItemGrid;
    }

    private async Task<Grid> CreateRootNode(Language language, ItemView itemView)
    {
        Grid defaultGrid = await CreateItemDefaultText(language, itemView);

        string[] sellItemText = await CreateSellPriceText(language, itemView);

        Grid contentGrid = new();
        AddGridRows(ref contentGrid, sellItemText);

        Grid rootNode = new();
        rootNode.AddColumn();
        rootNode.AddRow(defaultGrid);
        rootNode.AddRow(contentGrid);

        return rootNode;
    }

    private async Task<TreeNode> CreateNode(Language language, ItemView itemView)
    {
        Grid defaultGrid = await CreateItemDefaultText(language, itemView);

        Grid treeNodeGrid = new();
        treeNodeGrid.AddColumn();
        treeNodeGrid.AddRow(defaultGrid);

        if (itemView is not SalvageItemView salvageItemView)
        {
            return new TreeNode(treeNodeGrid);
        }

        string[] buyPricePerItem = await CreateBuyPricePerItemText(language, itemView);

        string[]? buyPrice = await CreatePriceText(language, TranslationCode.Cost, itemView);
        ArgumentNullException.ThrowIfNull(buyPrice, nameof(buyPrice));

        string salvageWith = await _translationsProcessor.GetTranslation(TranslationCode.SalvageWith, language);
        string salvageKitLink = CreateWikiLinkText(language, salvageItemView.SalvageKit.DisplayName);
        string[] salvage = ["", salvageWith, salvageKitLink];

        string[] salvageKitCostPerUse = await CreatePricePerUse(language, salvageItemView);

        Grid contentGrid = new();
        AddGridRows(ref contentGrid, buyPricePerItem, buyPrice, salvage, salvageKitCostPerUse);
        treeNodeGrid.AddRow(contentGrid);

        return new TreeNode(treeNodeGrid);
    }

    private async Task<TreeNode> CreateLastNode(Language language, ItemView itemView)
    {
        Grid defaultGrid = await CreateItemDefaultText(language, itemView);
        string[] buyPricePerItemText = await CreateBuyPricePerItemText(language, itemView);
        string[]? totalBuyPriceText = await CreatePriceText(language, TranslationCode.Cost, itemView);
        
        Grid treeNodeGrid = new();
        treeNodeGrid.AddColumn();
        treeNodeGrid.AddRow(defaultGrid);

        if (totalBuyPriceText == null)
        {
            return new TreeNode(treeNodeGrid);
        }

        Grid contentGrid = new();
        AddGridRows(ref contentGrid, buyPricePerItemText, totalBuyPriceText);
        treeNodeGrid.AddRow(contentGrid);

        return new TreeNode(treeNodeGrid);
    }

    private async Task<TreeNode> CreateLastSalvageNode(Language language, ItemView itemView)
    {
        Grid defaultGrid = await CreateItemDefaultText(language, itemView);
        string[]? totalBuyPriceText = await CreatePriceText(language, TranslationCode.Value, itemView);

        Grid treeNodeGrid = new();
        treeNodeGrid.AddColumn();
        treeNodeGrid.AddRow(defaultGrid);

        if (totalBuyPriceText == null)
        {
            return new TreeNode(treeNodeGrid);
        }

        Grid contentGrid = new();
        AddGridRows(ref contentGrid, totalBuyPriceText);
        treeNodeGrid.AddRow(contentGrid);

        return new TreeNode(treeNodeGrid);
    }

    private async Task<Grid> CreateItemDefaultText(Language language, ItemView itemView) 
    {
        Grid grid = new();
        string displayName = itemView.DisplayName;

        if (itemView.ItemGroup == ItemGroup.Luck)
        {
            string itemRarity = await _translationsProcessor.GetTranslation(itemView.Rarity, language, default);
            displayName += $" ({itemRarity})";
        }

        string itemLink = CreateWikiLinkText(language, displayName);
        string amount = itemView.Amount.ToString();
        string overproduceAmount = await CreateOverproduceAmountText(language, itemView);
        string[] texts = [$"{amount} {itemLink}"];
        if (overproduceAmount == "")
        {
            AddGridRows(ref grid, texts);
            return grid;
        }
        texts = texts.Add(overproduceAmount);
        AddGridRows(ref grid, texts);
        return grid;
    }

    private async Task<string[]> CreateSellPriceText(Language language, ItemView itemView)
    {
        string itemPrice = CreatePricePerItemText(itemView);
        string sellPrice = await _translationsProcessor.GetTranslation(TranslationCode.SellPrice, language);
        return ["", sellPrice, itemPrice];
    }

    private async Task<string[]?> CreatePriceText(Language language, TranslationCode translationCode, ItemView itemView, bool addSeparator = true)
    {
        string descriptor = await _translationsProcessor.GetTranslation(translationCode, language);
        string itemPrice = CreatePriceText(itemView);
        if (itemPrice == "")
        {
            return null;
        }
        
        if (addSeparator)
        {
            return ["", descriptor, itemPrice]; 
        }
        return [descriptor, itemPrice];
    }

    private async Task<string[]> CreateBuyPricePerItemText(Language language, ItemView itemView)
    {
        string buyPrice = await _translationsProcessor.GetTranslation(TranslationCode.BuyPrice, language);
        string[] texts = ["", buyPrice];
        if (itemView.Cost is ItemVendorCostView vendorCostView)
        {
            var vendorCost = new KeyValuePair<Currency, decimal>(vendorCostView.CurrencyType, vendorCostView.Amount);
            string currencyText = CreateCurrencyText(vendorCost);
            string pieceAbbr = await _translationsProcessor.GetTranslation(TranslationCode.PieceAbbreviation, language);
            string vendorCostText = $"{vendorCostView.ItemAmount} {pieceAbbr} / {currencyText}";
            return texts.Add(vendorCostText);
        }
        string itemPrice = CreatePricePerItemText(itemView);
        return texts.Add(itemPrice);
    }

    private async Task<string[]> CreatePricePerUse(Language language, SalvageItemView salvageItemView)
    {
        string pricePerUse = await _translationsProcessor.GetTranslation(TranslationCode.PricePerUse, language);
        string salvageKitCostPerUse = CreatePricePerItemText(salvageItemView.SalvageKit);
        return ["", pricePerUse, salvageKitCostPerUse];
    }

    private async Task<string[]> CreateProfitText(Language language, ItemView itemView)
    {
        KeyValuePair<Currency, decimal> itemProfit = itemView.GetProfit();
        string profit = await _translationsProcessor.GetTranslation(TranslationCode.Profit, language);
        string profitColor = itemProfit.Value switch
        {
            > 0 => "green",
            < 0 => "red",
            _ => "white"
        };

        string currency = CreateCurrencyText(itemProfit);
        return [CreateMarkupText(profitColor, "", profit), currency];
    }

    private string CreatePricePerItemText(ItemView itemView)
    {
        KeyValuePair<Currency, decimal>? itemCost = itemView.GetPricePerItem();
        if (itemCost == null)
        {
            return "";
        }
        return CreateCurrencyText(itemCost.Value);
    }

    private string CreatePriceText(ItemView itemView)
    {
        KeyValuePair<Currency, decimal>? itemCost = itemView.GetTotalPrice();
        if (itemCost == null)
        {
            return "";
        }
        return CreateCurrencyText(itemCost.Value);
    }

    private async Task<string[]> CreateTotalValuesText(Language language, ItemView itemView)
    {
        Dictionary<Currency, decimal>? itemValues = itemView.GetTotalValues();
        if (itemValues == null)
        {
            return [""];
        }

        string[] itemValueTexts = [];

        foreach (KeyValuePair<Currency, decimal> itemValue in itemValues)
        {
            itemValueTexts = itemValueTexts.Add(CreateCurrencyText(itemValue));
        }

        string value = await _translationsProcessor.GetTranslation(TranslationCode.Cost, language);

        string[] texts = [value];
        return texts.AddRange(itemValueTexts);
    }

    private string CreateCurrencyText(KeyValuePair<Currency, decimal> currency)
    {
        if (currency.Value == 0)
        {
            return "";
        }

        if (currency.Key != Currency.Coin)
        {
            string color = currency.Key.GetEnumAttributeValue<Currency, CurrencyColorAttribute, string>(attribute => attribute.Colors[0]);
            string translatedCurrency = _translationsProcessor.GetCurrencyTranslation(currency.Key);
            return CreateMarkupText(color, " ", currency.Value, translatedCurrency);
        }

        return CreateGoldCurrencyText(currency.Value);
    }

    private static string CreateGoldCurrencyText(decimal itemCost)
    {
        const int silverInCopper = 100;
        const int goldInCopper = silverInCopper * 100;

        bool isNegativ = itemCost < 0;
        decimal absoluteItemCost = isNegativ ? itemCost * -1 : itemCost;

        int copper = (int)(absoluteItemCost % silverInCopper);
        int silver = (int)(absoluteItemCost % goldInCopper / silverInCopper);
        int gold = (int)(absoluteItemCost / goldInCopper);

        string[] colors = Currency.Coin.GetEnumAttributeValue<Currency, CurrencyColorAttribute, string[]>(a => a.Colors);

        string goldText = CreateMarkupText(colors[0], "", gold, "g");
        string silverText = CreateMarkupText(colors[1], "", silver, "s");
        string copperText = CreateMarkupText(colors[2], "", copper, "c");

        StringBuilder stringBuilder = new();

        if (isNegativ)
        {
            stringBuilder.Append('-');
        }

        List<string> coinTexts = [];

        if (gold > 0)
        {
            coinTexts.Add(goldText);
        }

        if (silver > 0)
        {
            coinTexts.Add(silverText);
        }

        if (copper > 0)
        {
            coinTexts.Add(copperText);
        }

        return stringBuilder.AppendJoin(' ', coinTexts).ToString();
    }

    private async Task<string> CreateOverproduceAmountText(Language language, ItemView itemView)
    {
        if (itemView.OverproducedAmount > 0)
        {
            string extraOutput = await _translationsProcessor.GetTranslation(TranslationCode.ExtraOutput, language);
            return $"{extraOutput}: {itemView.OverproducedAmount}";
        }
        return "";
    }

    private string CreateWikiLinkText(Language language, string text)
    {
        string wikiText = text.Replace(" ", "_");
        string wikiLanguageExtension = "";

        if (language != Language.English)
        {
            wikiLanguageExtension = "-" + _languageConverter.ConvertFrom(language);
        }

        string link = $"link=https://wiki{wikiLanguageExtension}.guildwars2.com/wiki/{wikiText}";
        return CreateMarkupText(link, " ", text);
    }

    private static MultiSelectionPrompt<T> CreateMultiSelectPrompt<T>(string title, string moreChoicesText, string instructionsText, IReadOnlyDictionary<T, IEnumerable<T>> choices, int pageSize = 20) where T : notnull
    {
        MultiSelectionPrompt<T> multiSelect = new();
        multiSelect
            .PageSize(pageSize)
            .Title(title)
            .MoreChoicesText(moreChoicesText)
            .InstructionsText(instructionsText);

        return SetMultiSelectChoices(multiSelect, choices);
    }

    private static MultiSelectionPrompt<T> SetMultiSelectChoices<T>(MultiSelectionPrompt<T> multiSelectionPrompt, IReadOnlyDictionary<T, IEnumerable<T>> choices) where T : notnull
    {
        foreach (var filter in choices)
        {
            if (filter.Key is string stringVal && stringVal == "")
            {
                multiSelectionPrompt.AddChoices(filter.Value);
            }
            else
            {
                multiSelectionPrompt.AddChoiceGroup(filter.Key, filter.Value);
            }
        }

        return multiSelectionPrompt;
    }

    private async Task<TextPrompt<string>> CreateItemNameFilterPrompt(Language language, CancellationToken cancellationToken)
    {
        string provide = await _translationsProcessor.GetTranslation(TranslationCode.ProvideA, language, cancellationToken);
        string itemName = await CreateItemNameMarkup(language, cancellationToken);
        string toFilter = await _translationsProcessor.GetTranslation(TranslationCode.ToFilter, language, cancellationToken);

        string text = $"{provide} {itemName} {toFilter}:";

        TextPrompt<string> namesPrompt = new(text)
        {
            AllowEmpty = true
        };
        return namesPrompt;
    }

    private async Task<TextPrompt<string>> CreateAdditionalItemNameFilterPrompt(Language language, CancellationToken cancellationToken)
    {
        string provide = await _translationsProcessor.GetTranslation(TranslationCode.ProvideAnAdditional, language, cancellationToken);
        string itemName = await CreateItemNameMarkup(language, cancellationToken);
        string toFilter = await _translationsProcessor.GetTranslation(TranslationCode.ToFilter, language, cancellationToken);

        string text = $"{provide} {itemName} {toFilter}:";

        TextPrompt<string> namesPrompt = new(text)
        {
            AllowEmpty = true
        };
        return namesPrompt;
    }

    private async Task<string> CreateNamesFilterHelpText(Language language, CancellationToken cancellationToken)
    {
        string press = await _translationsProcessor.GetTranslation(TranslationCode.Press, language, cancellationToken);
        string enter = await CreateEnterKeyMarkup(language, cancellationToken);
        string toFinishItemFiltering = await _translationsProcessor.GetTranslation(TranslationCode.ToFinishItemNameFiltering, language, cancellationToken);

        return CreateMarkupText("grey", " ", $"({press}", enter, $"{toFinishItemFiltering})\n");
    }

    private async Task<string> CreateMoreChoicesText(Language language, CancellationToken cancellationToken)
    {
        string moreChoices = await _translationsProcessor.GetTranslation(TranslationCode.MoreFilterPropertiesChoicesText, language, cancellationToken);
        return CreateMarkupText("grey", "", "(", moreChoices, ")");
    }

    private async Task<string> CreateInstructionsText(Language language, CancellationToken cancellationToken)
    {
        string press = await _translationsProcessor.GetTranslation(TranslationCode.Press, language, cancellationToken);
        string spacebar = await CreateSpacebarKeyMarkup(language, cancellationToken);
        string toToggle = await _translationsProcessor.GetTranslation(TranslationCode.ToToggleFilterProperties, language, cancellationToken);
        string enter = await CreateEnterKeyMarkup(language, cancellationToken);
        string toAccept = await _translationsProcessor.GetTranslation(TranslationCode.ToAccept, language, cancellationToken);

        return CreateMarkupText("grey", " ", $"({press}", spacebar, $"{toToggle},", enter, $"{toAccept})");
    }

    private async Task<string> CreateItemNameMarkup(Language language, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        string itemName = await _translationsProcessor.GetTranslation(TranslationCode.ItemName, language, cancellationToken);
        string itemNameMarkup = CreateMarkupText("green", "", "[[", itemName, "]]");
        return itemNameMarkup;
    }

    private async Task<string> CreateEnterKeyMarkup(Language language, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        string enter = await _translationsProcessor.GetTranslation(TranslationCode.Enter, language, cancellationToken);
        return CreateMarkupText("green", "", "<", enter, ">");
    }

    private async Task<string> CreateSpacebarKeyMarkup(Language language, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        string spacebar = await _translationsProcessor.GetTranslation(TranslationCode.Spacebar, language, cancellationToken);
        return CreateMarkupText("blue", "", "<", spacebar, ">");
    }

    private static string CreateMarkupText(string markup, string separator, params object[] textContent)
    {
        return $"[{markup}]{string.Join(separator, textContent)}[/]";
    }

    private async Task DisplayOkPrompt(string text, Language language)
    {
        string needOk = await _translationsProcessor.GetTranslation(TranslationCode.NeedSelectOk, language);
        string k = await _translationsProcessor.GetTranslation(TranslationCode.K, language);

        string kMarkup = CreateMarkupText("green", "", "[[", k, "]]");
        string invalidMessage = needOk + kMarkup;

        ConfirmationPrompt prompt = new(text)
        {
            No = '\0',
            Yes = 'k',
            DefaultValue = true,
            InvalidChoiceMessage = invalidMessage,
            ShowChoices = false,
            ShowDefaultValue = true
        };

        bool res = false;
        do
        {
            res = DisplayOnCleanScreen(() => AnsiConsole.Prompt(prompt));
        } while(!res);
    }

    private T DisplayOnCleanScreen<T>(Func<T> displayFunc)
    {
        T val = default;
        AnsiConsole.AlternateScreen(() =>
        {
            WriteGreeting();
            val = displayFunc();
        });
        return val;
    }

    private static async Task ConfigureProgressContext(ProgressContext ctx, string description, params Task[] tasks)
    {
        const double maxProgress = 100;
        ProgressTask totalProgressTask = ctx.AddTask(description, maxValue: maxProgress);

        double maxTaskProgress = maxProgress / tasks.Length;
        double currentTaskProgress = 0;
        double incrementSteps = 0.1;
        int taskCounter = 0;

        foreach (Task task in tasks)
        {
            taskCounter += 1;
            double currentTaskMaxProgress = maxTaskProgress * taskCounter;

            while (!task.IsCompleted)
            {
                //don't increment to current task max if task not finished
                if (currentTaskProgress < currentTaskMaxProgress - 1)
                {
                    currentTaskProgress += incrementSteps;
                    totalProgressTask.Increment(incrementSteps);
                }
                await Task.Delay(25);
            }

            if (currentTaskProgress < currentTaskMaxProgress)
            {
                double missingIncrement = currentTaskMaxProgress - currentTaskProgress;
                totalProgressTask.Increment(missingIncrement);
                currentTaskProgress = currentTaskMaxProgress;
            }
        }
    }

    private IRenderable RenderHook(IRenderable renderable, IReadOnlyList<ProgressTask> progressTasks)
    {
        const string ESC = "\u001b";
        string escapeSequence;
        if (progressTasks.All(i => i.IsFinished))
        {
            escapeSequence = $"{ESC}]]9;4;0;100{ESC}\\";
        }
        else
        {
            var total = progressTasks.Sum(i => i.MaxValue);
            var done = progressTasks.Sum(i => i.Value);
            var percent = (int)(done / total * 100);
            escapeSequence = $"{ESC}]]9;4;1;{percent}{ESC}\\";
        }

        return new Rows(renderable, new ControlCode(escapeSequence));
    }

    private static void AddGridColumnsIfNeeded(ref Grid grid, int neededColumns)
    {
        int missingColumns = neededColumns - grid.Columns.Count;
        if (missingColumns <= 0)
        {
            return;
        }
        grid.AddColumns(missingColumns);
    }

    private static void AddGridRows(ref Grid grid, params string[][] rows)
    {
        Grid newGrid = new();
        AddGridColumnsIfNeeded(ref newGrid, grid.Columns.Count);

        foreach (string[] row in rows)
        {
            AddGridColumnsIfNeeded(ref newGrid, row.Length);
        }

        foreach (GridRow row in grid.Rows)
        {
            IEnumerator<IRenderable> rowEnumerator = row.GetEnumerator();
            while (rowEnumerator.MoveNext())
            {
                newGrid.AddRow(rowEnumerator.Current);
            }
        }

        foreach (string[] row in rows)
        {
            newGrid.AddRow(row);
        }

        grid = newGrid;
    }

    private static Markup CreateMarkup(string text, Color textColor, string? lineEnding = null, string? link = null)
    {
        Style textStyle = new(foreground: textColor, link: link);
        string textMessage = text + lineEnding ?? string.Empty;
        Markup textMarkup = new(textMessage, textStyle);
        return textMarkup;
    }

    private static FigletText CreateFigletText(string text, Color color, string fontPath, Justify justification = Justify.Center)
    {
        FigletFont figletFont = FigletFont.Load(fontPath);
        FigletText figletText = new FigletText(figletFont, text)
                                            .Justify(justification)
                                            .Color(color);
        return figletText;
    }

    public static Rule CreateRule(string text, Color color)
    {
        Rule rule = new Rule(text).RuleStyle(new Style(color));
        return rule;
    }
}
