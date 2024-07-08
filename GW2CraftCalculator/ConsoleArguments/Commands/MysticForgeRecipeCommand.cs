using GW2CraftCalculator.ConsoleArguments.Settings;
using GW2CraftCalculator.Interfaces;
using GW2CraftCalculator.Interfaces.Logic;
using GW2CraftCalculator.Interfaces.Translation;
using GW2CraftCalculator.Models.Enums;
using GW2CraftCalculator.Models.Logic;
using GW2CraftCalculator.Models.ViewModels;
using GW2CraftCalculator.Utils.Extensions;
using GW2CraftCalculator.Utils.Logging;
using Microsoft.Extensions.Logging;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace GW2CraftCalculator.ConsoleArguments.Commands;
public class MysticForgeRecipeCommand : AsyncCommand<MysticForgeRecipeSetting>
{
    private readonly ITranslationsProcessor _translationsProcessor;
    private readonly IMysticForgeUiFilterHandler _filterHandler;
    private readonly ILogicProcessor _logicProcessor;
    private readonly IConsoleProcessor _consoleProcessor;
    private readonly ILogger<MysticForgeRecipeCommand> _logger;

    public MysticForgeRecipeCommand(ITranslationsProcessor translationsProcessor, IMysticForgeUiFilterHandler filterHandler, ILogicProcessor logicProcessor, IConsoleProcessor consoleProcessor, ILogger<MysticForgeRecipeCommand> logger)
    {
        _translationsProcessor = translationsProcessor;
        _filterHandler = filterHandler;
        _logicProcessor = logicProcessor;
        _consoleProcessor = consoleProcessor;
        _logger = logger;
    }

    public override ValidationResult Validate(CommandContext context, MysticForgeRecipeSetting settings)
    {
        if (!settings.Filter.IsSet)
        {
            return ValidationResult.Success();
        }

        string[] filterTypes = _translationsProcessor.GetTranslations(settings.Language, TranslationCode.ItemTypes, TranslationCode.ItemGroups, TranslationCode.Rarities, TranslationCode.Tiers, TranslationCode.ItemNames).Result;

        ItemType[] itemTypes = Enum.GetValues<ItemType>().Where(i => i != ItemType.None).ToArray();
        ItemGroup[] itemGroups = Enum.GetValues<ItemGroup>().Where(i => i != ItemGroup.Luck && i != ItemGroup.None).ToArray();
        Rarity[] rarities = Enum.GetValues<Rarity>().Where(i => i != Rarity.Masterwork).ToArray();
        string[] allItemTypes = _translationsProcessor.GetTranslations(settings.Language, itemTypes).Result;
        string[] allItemGroup = _translationsProcessor.GetTranslations(settings.Language, itemGroups).Result;
        string[] allItemRarities = _translationsProcessor.GetTranslations(settings.Language, rarities).Result;

        HashSet<string> matchedGroups = [];

        foreach (var filterSetting in settings.Filter.Value)
        {
            if (!MatchValue(filterSetting.Key, filterTypes, out string? match))
            {
                return ValidationResult.Error($"Invalid filter type. Expected one of: '{string.Join("', '", filterTypes)}' (with or without spaces or spaces replaced with underscore '_') but got: '{filterSetting.Key}'");
            }

            if (matchedGroups.Contains(match))
            {
                return ValidationResult.Error($"Invalid filter type count. Filter types cannot occure more than once. Invalid filter type: '{match}' (Secound occurrence: '{filterSetting.Key}')");
            }

            matchedGroups.Add(match);

            if (match == filterTypes[4])
            {
                continue;
            }

            foreach (var filterValue in filterSetting.Value)
            {
                bool[] results = 
                [
                    MatchValue(filterValue, allItemTypes, out _), 
                    MatchValue(filterValue, allItemGroup, out _), 
                    MatchValue(filterValue, allItemRarities, out _)
                ];

                bool tierResult = false;
                foreach (ItemTier itemTier in Enum.GetValues<ItemTier>().Where(t => t != ItemTier.T1 && t != ItemTier.None && t != ItemTier.T7))
                {
                    if (((int)itemTier).ToString() == filterValue)
                    {
                        tierResult = true;
                        break;
                    }

                    if (itemTier.ToString().Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                    {
                        tierResult = true;
                        break;
                    }
                }

                results = results.Add(tierResult);

                if (!results.Any(res => res))
                {
                    return ValidationResult.Error($"Invalid filter value '{filterValue}'\n\t" +
                        $"Valid {filterTypes[0]}: '{string.Join("', '", allItemTypes)}'\n\t" +
                        $"Valid {filterTypes[1]}: '{string.Join("', '", allItemGroup)}'\n\t" +
                        $"Valid {filterTypes[2]}: '{string.Join("', '", allItemRarities)}'\n\t" +
                        $"Valid {filterTypes[3]}: '{string.Join("', '", EnumExtensions.GetExpectedValues("', '", ItemTier.None, ItemTier.T1, ItemTier.T7))}'");
                }
            }
        }

        return ValidationResult.Success();
    }

    public override async Task<int> ExecuteAsync(CommandContext context, MysticForgeRecipeSetting settings)
    {
        _logger.LogDebug("MysticForgeRecipe Command is executing... (Settings: {setting})", settings.ConvertReadable());
        _consoleProcessor.WriteGreeting();

        MysticForgeFilter? filter = null;
        if (settings.Filter.IsSet)
        {
            IEnumerable<string> filterValues = settings.Filter.Value.Values.SelectMany(v => v);
            await _filterHandler.SetFilter(settings.Language, filterValues, default);
            filter = _filterHandler.GetFilter();
        }

        Task<IEnumerable<ItemView>> viewModels = _logicProcessor.GetPricedRecipes(settings.Language, filter, 0);
        Task display = _consoleProcessor.PrintViewModels(settings.Language, viewModels, 1);
        await _consoleProcessor.DisplayTaskProgress(settings.Language, TranslationCode.RecipeItemsLoading, viewModels, display);
        _logger.LogDebug("MysticForgeRecipe Command finished executing.");
        return 0;
    }

    private static bool MatchValue(string value, string[] matchValues, [NotNullWhen(true)] out string? matchedValue)
    {
        foreach (var matchValue in matchValues)
        {
            if (value.Equals(matchValue, StringComparison.OrdinalIgnoreCase))
            {
                matchedValue = matchValue;
                return true;
            }

            string matchUnderscore = matchValue.Replace(' ', '_');
            if (value.Equals(matchUnderscore, StringComparison.OrdinalIgnoreCase))
            {
                matchedValue = matchValue;
                return true;
            }

            string matchNoSpaces = matchValue.Replace(" ", "");
            if (value.Equals(matchNoSpaces, StringComparison.OrdinalIgnoreCase))
            {
                matchedValue = matchValue;
                return true;
            }
        }

        matchedValue = null;
        return false;
    }
}
