using GW2CraftCalculator.Models.Data;
using GW2CraftCalculator.Models.Exceptions;
using GW2CraftCalculator.Models.ViewModels;
using Gw2Sharp.WebApi.V2.Models;

namespace GW2CraftCalculator.Logic.ViewModelCreators;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
#pragma warning disable CS8601 // Possible null reference assignment.
public sealed class SalvageRecipeItemViewCreation<TCurrentItem, TCurrentItemExtension> : ItemViewExtendedCreator<TCurrentItem, TCurrentItemExtension>
    where TCurrentItem : class
{
    public SalvageRecipeItemViewCreation(ItemViewDefaultCreator creator) : base(creator) { }

    public SalvageRecipeItemViewCreation(ItemViewExtendedCreator<TCurrentItem, TCurrentItemExtension> creator) : base(creator) { }

    public IEnumerable<IGrouping<SalvageRecipeInput, SalvageRecipe>> GroupedRecipes { get; init; }


    public override SalvageRecipeItemViewCreation<TItem, TExtension> Clone<TItem, TExtension>(TItem? currentItem = default, TExtension extension = default, int? factor = null, bool isRoot = false) where TItem : class
    {
        if (currentItem == null && CurrentItem is TItem item)
        {
            currentItem = item;
        }

        return new SalvageRecipeItemViewCreation<TItem, TExtension>(this)
        {
            CurrentItem = currentItem,
            CurrentItemExtension = extension,
            Factor = factor ?? Factor,
            GroupedRecipes = GroupedRecipes,
            IsRoot = isRoot
        };
    }

    public bool UseHighestValueSalvageRecipe(out IGrouping<SalvageRecipeInput, SalvageRecipe>? highestValueSalvageRecipe, out int? vendorCostId, out int? factor)
    {
        highestValueSalvageRecipe = GetHighestValueSalvageRecipeGroup(out int salvageKitVendorCostId, out decimal outputItemValue);

        decimal inputValue = GetSalvageRecipeInputValue(highestValueSalvageRecipe);
        decimal salvageKitCostPerUse = GetVendorCostPerItemGoldConverted(highestValueSalvageRecipe.Key.SalvageKit, salvageKitVendorCostId);

        decimal inputTotalValue = salvageKitCostPerUse + inputValue;

        if (inputTotalValue > outputItemValue)
        {
            highestValueSalvageRecipe = null;
            vendorCostId = null;
            factor = null;
            return false;
        }

        vendorCostId = salvageKitVendorCostId;
        ItemView itemView = GetExtensionConverted<ItemView>();
        factor = GetSalvageItemFactor(highestValueSalvageRecipe, itemView);

        _factor ??= factor;

        return true;
    }

    private IGrouping<SalvageRecipeInput, SalvageRecipe> GetHighestValueSalvageRecipeGroup(out int vendorCostId, out decimal outputItemValue)
    {
        IGrouping<SalvageRecipeInput, SalvageRecipe>? salvageRecipe = null;
        vendorCostId = 0;
        outputItemValue = 0;

        foreach (var group in GroupedRecipes)
        {
            decimal salvageOutputGoldValue = 0;
            decimal costPerUse = 0;

            VendorCost? vendorCost;
            if (group.Key.SalvageKit is VendorItemSalvageKitInfinite infiniteSalvageKit)
            {
                VendorItemCostCountMissmatchException.ThrowIfCostCountMissmatches(infiniteSalvageKit, 1);
                costPerUse = infiniteSalvageKit.CostsPerUse;
                vendorCost = infiniteSalvageKit.Cost.First();
            }
            else
            {
                vendorCost = GetCheapestVendorCostPerItem(group.Key.SalvageKit, out costPerUse);
            }

            salvageOutputGoldValue = GetSalvageRecipeOutputValue(group) - costPerUse;

            if (salvageRecipe == null || outputItemValue < salvageOutputGoldValue)
            {
                salvageRecipe = group;
                vendorCostId = vendorCost.Id;
                outputItemValue = salvageOutputGoldValue;
            }
        }
        return salvageRecipe!;
    }

    private decimal GetSalvageRecipeOutputValue(IGrouping<SalvageRecipeInput, SalvageRecipe> salvageRecipes)
    {
        decimal outputItemCost = 0;
        IEnumerable<SalvageRecipe> commerceableRecipes = salvageRecipes.Where(r => r.SalvageOutput.Item.IsCommerceable() || r.SalvageOutput.Item is VendorItem);

        foreach (SalvageRecipe recipe in commerceableRecipes)
        {
            if (recipe.SalvageOutput.Item is VendorItem vendorItem)
            {
                GetCheapestVendorCostPerItem(vendorItem, out decimal costPerItem);
                outputItemCost += costPerItem * recipe.SalvageOutput.OutputAmount;
            }
            else
            {
                CommercePrice? price = GetUnitPrice(recipe.SalvageOutput.Item, IsRoot);
                ArgumentNullException.ThrowIfNull(price, nameof(price));
                outputItemCost += price.UnitPrice * recipe.SalvageOutput.OutputAmount;
            }
        }
        return outputItemCost;
    }

    private decimal GetSalvageRecipeInputValue(IGrouping<SalvageRecipeInput, SalvageRecipe> salvageRecipes)
    {
        CommercePrice? price = GetUnitPrice(salvageRecipes.Key.Item, IsRoot);
        ArgumentNullException.ThrowIfNull(price, nameof(price));

        return price.UnitPrice;
    }

    private static int GetSalvageItemFactor(IGrouping<SalvageRecipeInput, SalvageRecipe> salvageRecipes, ItemView itemView)
    {
        decimal itemOutputAmount = salvageRecipes!.First(g => g.SalvageOutput.Item.Id == itemView.Id).SalvageOutput.OutputAmount;
        return itemView.GetOverproduceFactor(itemOutputAmount);
    }
}
