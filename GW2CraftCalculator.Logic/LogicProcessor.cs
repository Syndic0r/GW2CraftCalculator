using AutoMapper;
using GW2CraftCalculator.Interfaces.Data;
using GW2CraftCalculator.Interfaces.Logic;
using GW2CraftCalculator.Interfaces.Translation;
using GW2CraftCalculator.Logic.ViewModelCreators;
using GW2CraftCalculator.Models.Data;
using GW2CraftCalculator.Models.Enums;
using GW2CraftCalculator.Models.Exceptions;
using GW2CraftCalculator.Models.Logic;
using GW2CraftCalculator.Models.ViewModels;
using GW2CraftCalculator.Utils.Logging;
using Gw2Sharp;
using Gw2Sharp.WebApi.Exceptions;
using Gw2Sharp.WebApi.V2;
using Gw2Sharp.WebApi.V2.Models;
using Microsoft.Extensions.Logging;
using Currency = GW2CraftCalculator.Models.Enums.Currency;
using Gw2Currency = Gw2Sharp.WebApi.V2.Models.Currency;
using Gw2Item = Gw2Sharp.WebApi.V2.Models.Item;
using Item = GW2CraftCalculator.Models.Data.Item;

namespace GW2CraftCalculator.Logic;

public class LogicProcessor : ILogicProcessor
{
    private readonly IGw2ClientFactory _gw2ClientFactory;
    private readonly IItemsRepository _itemsRepository;
    private readonly ILogger<LogicProcessor> _logger;
    private readonly IMapper _mapper;
    private readonly ITranslationsProcessor _translationsProcessor;

    private ViewModelCreationCache _viewModelCreationCache;

    private const int MAX_GOLD = 200000000;

    public LogicProcessor(IGw2ClientFactory gw2ClientFactory, IItemsRepository itemsRepository, ILogger<LogicProcessor> logger, IItemMapper mapper, ITranslationsProcessor translationsProcessor)
    {
        _gw2ClientFactory = gw2ClientFactory;
        _itemsRepository = itemsRepository;
        _logger = logger;
        _mapper = mapper.Mapper;
        _translationsProcessor = translationsProcessor;
        _viewModelCreationCache = new ViewModelCreationCache();
    }

    public async Task<IEnumerable<ItemView>> GetPricedRecipes(Language language, MysticForgeFilter? filter, int runConfig)
    {
        Task setCurrencyTranslation = SetCurrencyTranslations(language);
        Task<IList<CurrencyConversion>> currencyConversionsTask = _itemsRepository.GetCurrencyConversions();
        Task<CurrencyConversion> goldGemsConversion = GetGoldGemsExchangeRate(language);

        bool hasCreator;
        ItemViewDefaultCreator? cachedCreator;
        if (runConfig > 0)
        {
            hasCreator = _viewModelCreationCache.TryGetOldCreatorVersion(runConfig, out cachedCreator);
        }
        else
        {
            hasCreator = _viewModelCreationCache.TryGetCurrentCreator(out cachedCreator);
        }

        IEnumerable<MysticForgeRecipe> mysticForgeRecipes;
        if (hasCreator)
        {
            mysticForgeRecipes = cachedCreator!.Recipes;
        }
        else
        {
            mysticForgeRecipes = await _itemsRepository.GetMysticForgeRecipes();
        }

        IEnumerable<Item> recipeItems = SelectItems(mysticForgeRecipes, r => [r.RecipeInput.Item, r.RecipeOutput.Item]);

        IEnumerable<Item> salvageableItems = recipeItems.Where(i => i.IsSalvageable());

        IEnumerable<SalvageRecipe> salvageRecipes;
        if (hasCreator)
        {
            salvageRecipes = cachedCreator!.SalvageRecipes;
        }
        else
        {
            salvageRecipes = await _itemsRepository.GetSalvageRecipes(salvageableItems);
        }

        IEnumerable<Item> salvageItems = SelectItems(salvageRecipes, s => [s.SalvageInput.SalvageKit, s.SalvageInput.Item, s.SalvageOutput.Item]);

        Task<IReadOnlyList<CommercePrices>> commercePrices = GetItemCommercePrices(language, recipeItems, salvageItems);
        Task<IReadOnlyList<Gw2Item>> gw2Items = GetLanguageTranslatedItems(language, recipeItems, salvageItems);

        IList<CurrencyConversion> currencyConversions = await currencyConversionsTask;
        currencyConversions.Add(await goldGemsConversion);

        ItemViewDefaultCreator creator;
        if (hasCreator)
        {
            creator = cachedCreator!.CacheClone(await commercePrices, await gw2Items, currencyConversions, filter);
        }
        else
        {
            creator = new(mysticForgeRecipes, salvageRecipes, await commercePrices, await gw2Items, currencyConversions, filter);
            _viewModelCreationCache.SetCurrentCreator(creator);
        }

        IEnumerable<ItemView> viewModels = CreateViewModels(creator);

        await setCurrencyTranslation;
       
        return viewModels;
    }

    private async Task SetCurrencyTranslations(Language language)
    {
        IReadOnlyList<Gw2Currency> translatedCurrencies = await GetCurrencies(language);
        Dictionary<int, string> currencyTranslations = translatedCurrencies.ToDictionary(k => k.Id, v => v.Name);
        _translationsProcessor.TrySetCurrencyTranslations(currencyTranslations);
    }

    private async Task<IReadOnlyList<Gw2Currency>> GetCurrencies(Language language)
    {
        _logger.LogDebug("Getting currenies. Language: {language}", language.ToString());
        IEnumerable<int> currencyIds = Enum.GetValues<Currency>().Select(c => (int)c);
        IReadOnlyList<Gw2Currency> currencies = await Gw2ApiGet(language, client => client.Currencies.ManyAsync(currencyIds));
        return currencies;
    }

    private async Task<CurrencyConversion> GetGoldGemsExchangeRate(Language language)
    {
        _logger.LogDebug("Getting Gold to Gems exchange rate. Language: {language}", language.ToString());
        CommerceExchangeCoins goldGemsExchange = await Gw2ApiGet(language, client => client.Commerce.Exchange.Coins.Quantity(MAX_GOLD).GetAsync());
        CurrencyConversion currencyConversion = new()
        {
            BaseCurrencyAmount = 1,
            BaseCurrencyType = Currency.Gems,
            ConversionCurrencyAmount = goldGemsExchange.CoinsPerGem,
            ConversionCurrencyType = Currency.Coin
        };

        return currencyConversion;
    }

    private async Task<IReadOnlyList<CommercePrices>> GetItemCommercePrices(Language language, params IEnumerable<Item>[] items)
    {
        HashSet<Item> allItems = [];

        foreach (IEnumerable<Item> itemCollection in items)
        {
            allItems.UnionWith(itemCollection);
        }

        IEnumerable<Item> commerceableItems = allItems.Where(i => i.IsCommerceable());
        IEnumerable<int> commerceableItemIds = commerceableItems.Select(i => i.Id);
        _logger.LogDebug("Getting Items Commerce Prices. Language: {language}", language.ToString());
        IReadOnlyList<CommercePrices> recipeItemPrices = await Gw2ApiGet(language, client => client.Commerce.Prices.ManyAsync(commerceableItemIds));
        return recipeItemPrices;
    }

    private async Task<IReadOnlyList<Gw2Item>> GetLanguageTranslatedItems(Language language, params IEnumerable<Item>[] items)
    {
        HashSet<Item> translationItem = [];
        foreach (IEnumerable<Item> itemsCollection in items)
        {
            translationItem.UnionWith(itemsCollection);
        }

        IEnumerable<int> allItemIds = translationItem.Select(i => i.Id);
        _logger.LogDebug("Getting Language translated Items. Language: {language}", language.ToString());
        IReadOnlyList<Gw2Item> gw2Items = await Gw2ApiGet(language, client => client.Items.ManyAsync(allItemIds));
        return gw2Items;
    }

    private async Task<T> Gw2ApiGet<T>(Language language, Func<IGw2WebApiV2Client, Task<T>> endpointCall) where T : class
    {
        try
        {
            _logger.LogDebug("Running Request to Guild Wars 2 API. Language: {language}", language.ToString());
            using IGw2Client gw2Client = _gw2ClientFactory.CreateClient(language);
            T result = await endpointCall(gw2Client.WebApi.V2);
            _logger.LogDebug("Guild Wars 2 API call finished.");
            return result;
        }
        catch (UnexpectedStatusException ex)
        {
            _logger.LogError(ex, ex.Message);
            const string message = $"Unable to connect to Guild Wars 2 Servers.";
            throw new Exception(message, ex);
        }
    }

    private IEnumerable<Item> SelectItems<T>(IEnumerable<T> inputs, Func<T, IEnumerable<Item>> itemSelector) where T : class
    {
        _logger.LogDebug("Selecting items...");
        HashSet<Item> selectedItems = [];
        foreach(T input in inputs)
        {
            foreach (Item item in itemSelector(input))
            {
                if (selectedItems.Contains(item))
                {
                    continue;
                }
                yield return item;
                selectedItems.Add(item);
            }
        }
    }

    private HashSet<ItemView> CreateViewModels(ItemViewDefaultCreator creator)
    {
        _logger.LogDebug("Start creating view models.");
        GroupingRecipeCreator<MysticForgeRecipeOutput, MysticForgeRecipe> groupingCreator = new(creator, creator.Recipes, r => r.RecipeOutput);

        HashSet<ItemView> viewModels = [];
        foreach (IGrouping<MysticForgeRecipeOutput, MysticForgeRecipe> recipeGroup in groupingCreator.Group())
        {
            MysticForgeRecipeOutput currentOutput = recipeGroup.Key;

            if (!MatchFilter(currentOutput, creator))
            {
                _logger.LogDebug("Filter missmatch. Skipping Mystic Forge Output {outputId} with Item {Id} {Name}", currentOutput.Id, currentOutput.Item.Id, currentOutput.Item.Name);
                continue;
            }

            MysticForgeRecipeItemViewCreator<Item, MysticForgeRecipeOutputAmount> recipeCreator = new(creator)
            {
                CurrentItem = recipeGroup.Key.Item,
                CurrentItemExtension = recipeGroup.Key.OutputAmount,
                GroupedRecipes = groupingCreator.Group(),
                CurrentRecipe = recipeGroup,
                IsRoot = true
            };
            ItemView viewModel = CreateCompleteViewModel(recipeCreator);

            viewModels.Add(viewModel);
        }
        _logger.LogDebug("Created View Model. View Models: {viewModels}", viewModels.ConvertReadable());
        return viewModels;
    }

    private static bool MatchFilter(MysticForgeRecipeOutput output, ItemViewDefaultCreator creator)
    {
        bool result = creator.MatchItemType(output.Item.ItemType);
        result &= creator.MatchItemGroup(output.Item.ItemGroup);
        result &= creator.MatchRarity(output.Item.Rarity);
        result &= creator.MatchTier(output.Item.Tier);
        result &= creator.MatchItemName(output.Item.Id);
        return result;
    }

    private ItemView CreateCompleteViewModel<TExtension>(MysticForgeRecipeItemViewCreator<Item, TExtension> creator) where TExtension : class
    {
        ArgumentNullException.ThrowIfNull(creator.GroupedRecipes);
        ItemView viewModel = CreateViewModelWithSalvage(creator);

        if (creator.CurrentRecipe == null)
        {
            return viewModel;
        }

        int produceFactor = viewModel.GetOverproduceFactor(creator.CurrentRecipe.Key.OutputAmount.Amount);
        viewModel.SetOverproduceAmount(creator.CurrentRecipe.Key.OutputAmount.Amount);

        viewModel.ComposedItems ??= [];

        foreach (MysticForgeRecipe recipe in creator.CurrentRecipe)
        {
            var inputCreator = creator.Clone(recipe.RecipeInput.Item, recipe.RecipeInput.InputAmount, currentRecipe: null, factor: produceFactor);
            inputCreator.TrySetNextCurrentItemValuableRecipe(true);

            ItemView inputViewModel;
            if (creator.CurrentItem.Id != recipe.RecipeInput.Item.Id)
            {
                inputViewModel = CreateCompleteViewModel(inputCreator);
            }
            else
            {
                inputViewModel = CreateViewModelWithSalvage(inputCreator);
            }

            viewModel.ComposedItems.Add(inputViewModel);
        }
        return viewModel;
    }

    private ItemView CreateViewModelWithSalvage<TExtension>(ItemViewExtendedCreator<Item, TExtension> creator) where TExtension : class
    {
        ItemView viewModel = CreateViewModel(creator);

        if (creator.CurrentItem.IsSalvageable())
        {
            var salvageCreator = creator.Clone(creator.CurrentItem, viewModel, creator.Factor, creator.IsRoot);
            viewModel = CreateSalvageViewModel(salvageCreator);
        }
        return viewModel;
    }

    private ItemView CreateViewModel<TExtension>(ItemViewExtendedCreator<Item, TExtension> creator) where TExtension : class
    {
        ItemView viewModel = _mapper.Map<ItemView>(creator.CurrentItemExtension);
        var itemViewCreator = creator.Clone<Item, Func<Item, Item>>(creator.CurrentItem, i => i);
        viewModel = CreateViewModel(itemViewCreator, viewModel);
        return viewModel;
    }

    private TItemView CreateViewModel<TItemView, TItem>(ItemViewExtendedCreator<TItem, Func<TItem, Item>> creator, TItemView? viewModel = null) where TItemView : ItemView where TItem : class
    {
        ArgumentNullException.ThrowIfNull(creator.CurrentItemExtension, nameof(creator.CurrentItemExtension));

        if (viewModel == null)
        {
            viewModel = _mapper.Map<TItemView>(creator.CurrentItemExtension(creator.CurrentItem));
        }
        else
        {
            viewModel = _mapper.Map(creator.CurrentItemExtension(creator.CurrentItem), viewModel);
        }

        viewModel = _mapper.Map(creator.GetGw2Item(creator.CurrentItemExtension), viewModel);
        CommercePrice? unitPrice = creator.GetUnitPrice(creator.CurrentItemExtension);

        if (unitPrice != null)
        {
            viewModel.Cost = _mapper.Map<ItemCostView>(unitPrice);
        }

        if (creator.Factor != null)
        {
            viewModel.Amount *= creator.Factor.Value;
        }

        if (creator.CurrentItem is VendorItem vendorItem)
        {
            VendorItemCostCountMissmatchException.ThrowIfCostCountMissmatches(vendorItem, 1);
            var vendorItemCreator = creator.Clone<VendorItem, Func<VendorItem, VendorCost>>(vendorItem, v => v.Cost.First());
            viewModel.Cost = CreateVendorItemCostViewModel(vendorItemCreator);
        }
        return viewModel;
    }

    private ItemVendorCostView CreateVendorItemCostViewModel<TVendorItem>(ItemViewExtendedCreator<TVendorItem, Func<TVendorItem, VendorCost>> creator) where TVendorItem : VendorItem
    {
        ArgumentNullException.ThrowIfNull(creator.CurrentItemExtension, nameof(creator.CurrentItemExtension));
        ItemVendorCostView vendorCostView = _mapper.Map<ItemVendorCostView>(creator.CurrentItem);
        return _mapper.Map(creator.CurrentItemExtension(creator.CurrentItem), vendorCostView);
    }

    private ItemView CreateSalvageViewModel<TItem, TExtension>(ItemViewExtendedCreator<TItem, TExtension> creator) where TItem : Item where TExtension : ItemView
    {
        ArgumentNullException.ThrowIfNull(creator.CurrentItemExtension, nameof(creator.CurrentItemExtension));

        GroupingRecipeCreator<SalvageRecipeInput, SalvageRecipe> groupingCreator = new(creator, creator.SalvageRecipes, r => r.SalvageInput);
        groupingCreator.WhereSelector = RecipesContainSalvageInput;

        SalvageRecipeItemViewCreation<TItem, TExtension> salvageRecipeCreator = new(creator)
        {
            GroupedRecipes = groupingCreator.Group(),
        };

        if (!salvageRecipeCreator.UseHighestValueSalvageRecipe(out var highestValueGroup, out int? vendorCostId, out int? factor))
        {
            return creator.CurrentItemExtension;
        }

        var salvageInputCreator = salvageRecipeCreator.Clone(highestValueGroup!.Key, vendorCostId!.Value);
        SalvageItemView salvageView = CreateSalvageInputViewModel(salvageInputCreator);
        salvageView.ComposedItems = [];

        foreach (SalvageRecipe salvageRecipe in highestValueGroup)
        {
            var salvageOutputCreator = salvageInputCreator.Clone(salvageRecipe.SalvageOutput.Item, salvageRecipe.SalvageOutput);
            ItemView salvageOutputViewModel = CreateViewModel(salvageOutputCreator);
            salvageView.ComposedItems.Add(salvageOutputViewModel);
        }

        creator.CurrentItemExtension.ComposedItems ??= [];
        creator.CurrentItemExtension.ComposedItems.Add(salvageView);
        return creator.CurrentItemExtension;

        bool RecipesContainSalvageInput(SalvageRecipe recipe)
        {
            IEnumerable<int> salvageInputIds = groupingCreator.SelectSalvageInputIds(recipe.SalvageOutput.Item.Id);
            return salvageInputIds.Contains(recipe.SalvageInput.Id);
        }
    }

    private SalvageItemView CreateSalvageInputViewModel(ItemViewExtendedCreator<SalvageRecipeInput, int> creator)
    {
        ArgumentNullException.ThrowIfNull(creator.Factor, nameof(creator.Factor));

        var itemViewCreator = creator.Clone<SalvageRecipeInput, Func<SalvageRecipeInput, Item>>(creator.CurrentItem, r => r.Item, creator.Factor);
        SalvageItemView salvageView = CreateViewModel<SalvageItemView, SalvageRecipeInput>(itemViewCreator);

        var salvageKitCreator = creator.Clone(creator.CurrentItem.SalvageKit, creator.CurrentItemExtension);
        salvageView.SalvageKit = CreateSalvageKitViewModel(salvageKitCreator);
        return salvageView;
    }

    private SalvageKitItemView CreateSalvageKitViewModel(ItemViewExtendedCreator<VendorItemSalvageKit, int> creator)
    {
        SalvageKitItemView salvageKitView;
        if (creator.CurrentItem is VendorItemSalvageKitInfinite infiniteSalvageKit)
        {
            salvageKitView = _mapper.Map<SalvageKitInfiniteItemView>(infiniteSalvageKit);
        }
        else
        {
            salvageKitView = _mapper.Map<SalvageKitItemView>(creator.CurrentItem);
        }

        salvageKitView = _mapper.Map(creator.GetGw2Item(), salvageKitView);
        var vendorItemCostView = creator.Clone<VendorItem, Func<VendorItem, VendorCost>>(creator.CurrentItem, _ => creator.GetVendorCost());
        salvageKitView.Cost = CreateVendorItemCostViewModel(vendorItemCostView);
        return salvageKitView;
    }
}
