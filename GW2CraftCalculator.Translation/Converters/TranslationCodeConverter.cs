using GW2CraftCalculator.Utils.Converters;
using Microsoft.Extensions.Logging;
using GW2CraftCalculator.Interfaces.Translation;
using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Translation.Converters;

internal class TranslationCodeConverter : BaseConverter, ITranslationCodeConverter
{
    private readonly IDictionary<TranslationCode, string> _translationLookup;

    public TranslationCodeConverter(ILogger<TranslationCodeConverter> logger) : base(logger)
    {
        _translationLookup = new Dictionary<TranslationCode, string>()
        {
            { TranslationCode.UseFilter, "useFilter" },
            { TranslationCode.RecipeItemsLoading, "recipeItemsLoading" },
            { TranslationCode.TableTitelViewModels, "viewModelTableTitel" },
            { TranslationCode.RunFinishedViewModels, "viewModelRunFinished" },
            { TranslationCode.TableColumnCreatedItem, "tableColumnCreatedItem" },
            { TranslationCode.TableColumnItemCraftingPath, "tableColumnItemCraftingPath" },
            { TranslationCode.TableColumnIsProfitable, "tableColumnIsProfitable" },
            { TranslationCode.SalvageWith, "salvageWith" },
            { TranslationCode.ExtraOutput, "extraOutput" },
            { TranslationCode.BuyPrice, "buyPrice" },
            { TranslationCode.SellPrice, "sellPrice" },
            { TranslationCode.PricePerUse, "pricePerUse" },
            { TranslationCode.Cost, "cost" },
            { TranslationCode.Profit, "profit" },
            { TranslationCode.Value, "value" },
            { TranslationCode.PieceAbbreviation, "pieceAbbreviation" },
            { TranslationCode.Cloth, "cloth" },
            { TranslationCode.Leather, "leather" },
            { TranslationCode.Metal, "metal" },
            { TranslationCode.Wood, "wood" },
            { TranslationCode.Bone, "bone" },
            { TranslationCode.Claw, "claw" },
            { TranslationCode.Dust, "dust" },
            { TranslationCode.Fang, "fang" },
            { TranslationCode.Scale, "scale" },
            { TranslationCode.Totem, "totem" },
            { TranslationCode.Venom, "venom" },
            { TranslationCode.Blood, "blood" },
            { TranslationCode.Charged, "charged" },
            { TranslationCode.Corrupted, "corrupted" },
            { TranslationCode.Crystal, "crystal" },
            { TranslationCode.Destroyer, "destroyer" },
            { TranslationCode.Essence, "essence" },
            { TranslationCode.Glacial, "glacial" },
            { TranslationCode.Molten, "molten" },
            { TranslationCode.Onyx, "onyx" },
            { TranslationCode.Basic, "basic" },
            { TranslationCode.Fine, "fine" },
            { TranslationCode.Rare, "rare" },
            { TranslationCode.Basics, "basics" },
            { TranslationCode.Refineds, "refineds" },
            { TranslationCode.Fines, "fines" },
            { TranslationCode.Rares, "rares" },
            { TranslationCode.Masterwork, "masterwork" },
            { TranslationCode.Exotic, "exotic" },
            { TranslationCode.ItemGroups, "itemGroups" },
            { TranslationCode.ItemTypes, "itemTypes" },
            { TranslationCode.Rarities, "rarities" },
            { TranslationCode.Tiers, "tier" },
            { TranslationCode.MoreFilterPropertiesChoicesText, "moreFilterPropertiesChoicesText" },
            { TranslationCode.Press, "press" },
            { TranslationCode.Spacebar, "spacebar" },
            { TranslationCode.ToToggleFilterProperties, "toToggleFilterProperties" },
            { TranslationCode.Enter, "enter" },
            { TranslationCode.ToAccept, "toAccept" },
            { TranslationCode.FilterChoicesTitle, "filterChoicesTitle" },
            { TranslationCode.FilterSelectionWarning, "filterSelectionWarning" },
            { TranslationCode.NeedSelectOk, "needSelectOk" },
            { TranslationCode.K, "k" },
            { TranslationCode.ToFinishItemNameFiltering, "toFinishItemNameFiltering" },
            { TranslationCode.ProvideA, "provideA" },
            { TranslationCode.ProvideAnAdditional, "provideAnAdditional" },
            { TranslationCode.ItemName, "itemName" },
            { TranslationCode.ItemNames, "itemNames" },
            { TranslationCode.ToFilter, "toFilter" },
            { TranslationCode.WantToRunAgain, "wantToRunAgain" },
            { TranslationCode.ReusePreviousConfig, "reusePreviousConfig" },
            { TranslationCode.WhichPreviousConfigToUse, "whichPreviousConfigToUse" },
            { TranslationCode.ErrorLessThan1, "errorLessThan1" },
            { TranslationCode.ErrorGreaterThanOccuredRuns, "errorGreaterThanOccuredRuns" },
            { TranslationCode.OccuredRuns, "occuredRuns" }
        };
    }

    public string ConvertFrom(TranslationCode code)
    {
        return GetLookupValue(code, _translationLookup);
    }
}
