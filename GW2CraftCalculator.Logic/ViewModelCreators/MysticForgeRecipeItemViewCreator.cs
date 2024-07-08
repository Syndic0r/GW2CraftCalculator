using GW2CraftCalculator.Models.Data;
using Gw2Sharp.WebApi.V2.Models;
using Item = GW2CraftCalculator.Models.Data.Item;

namespace GW2CraftCalculator.Logic.ViewModelCreators;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
#pragma warning disable CS8601 // Possible null reference assignment.
public sealed class MysticForgeRecipeItemViewCreator<TCurrentItem, TCurrentItemExtension> : ItemViewExtendedCreator<TCurrentItem, TCurrentItemExtension> where TCurrentItem : class
{
    public MysticForgeRecipeItemViewCreator(ItemViewDefaultCreator creator) : base(creator) { }

    public IEnumerable<IGrouping<MysticForgeRecipeOutput, MysticForgeRecipe>> GroupedRecipes { get; init; }

    public IGrouping<MysticForgeRecipeOutput, MysticForgeRecipe>? CurrentRecipe
    {
        get => _currentRecipe;
        init => _currentRecipe = value;
    }

    private IGrouping<MysticForgeRecipeOutput, MysticForgeRecipe> _currentRecipe;

    public override MysticForgeRecipeItemViewCreator<TItem, TExtension> Clone<TItem, TExtension>(TItem? currentItem = default, TExtension extensionInfo = default, int? factor = null, bool isRoot = false)
        where TItem : class
    {
        if (currentItem == null && CurrentItem is TItem item)
        {
            currentItem = item;
        }

        return new MysticForgeRecipeItemViewCreator<TItem, TExtension>(this)
        {
            CurrentItem = currentItem,
            CurrentItemExtension = extensionInfo,
            Factor = factor ?? Factor ?? (isRoot ? 1 : factor),
            GroupedRecipes = GroupedRecipes,
            CurrentRecipe = null,
            IsRoot = isRoot
        };
    }

    public MysticForgeRecipeItemViewCreator<TItem, TExtension> Clone<TItem, TExtension>(TItem? currentItem = default,
                                                                                           TExtension extensionInfo = default,
                                                                                           IGrouping<MysticForgeRecipeOutput, MysticForgeRecipe>? currentRecipe = null,
                                                                                           int? factor = null,
                                                                                           bool isRoot = false)
        where TItem : class
    {
        var cloned = Clone(currentItem, extensionInfo, factor, isRoot);
        cloned._currentRecipe = currentRecipe;
        return cloned;
    }

    public bool TrySetNextCurrentItemValuableRecipe(bool forceOverride = false)
    {
        if (forceOverride || _currentRecipe == null)
        {
            ArgumentNullException.ThrowIfNull(CurrentItem, nameof(CurrentItem));
            var nextCurrentRecipe = GetNextHighestValueGroup(out decimal? pricePerItem);
            if (IsCraftingRecipeValuable(nextCurrentRecipe, pricePerItem))
            {
                _currentRecipe = nextCurrentRecipe;
                return true;
            }
            return false;
        }

        return false;
    }

    private bool IsCraftingRecipeValuable(IGrouping<MysticForgeRecipeOutput, MysticForgeRecipe>? currentItemRecipe, decimal? pricePerItem)
    {
        if (IsRoot)
        {
            return true;
        }

        if (currentItemRecipe == null)
        {
            return false;
        }

        ArgumentNullException.ThrowIfNull(pricePerItem, nameof(pricePerItem));
        ArgumentNullException.ThrowIfNull(Prices, nameof(Prices));
        CommercePrice? outputItemPrice = GetUnitPrice(currentItemRecipe.Key.Item);
        ArgumentNullException.ThrowIfNull(outputItemPrice, nameof(outputItemPrice));

        return pricePerItem < outputItemPrice.UnitPrice;
    }

    private IGrouping<MysticForgeRecipeOutput, MysticForgeRecipe>? GetNextHighestValueGroup(out decimal? pricePerItem)
    {
        ArgumentNullException.ThrowIfNull(Prices, nameof(Prices));

        Item item = GetCurrentItemConverted<Item>();

        var groupings = GroupedRecipes.Where(g => g.Key.Item.Id == item.Id);

        if (!groupings.Any())
        {
            pricePerItem = null;
            return null;
        }

        if (groupings.Count() == 1)
        {
            var group = groupings.First();
            pricePerItem = GetItemRecipePricePerItem(group);
            return group;
        }

        decimal currentLowestCostPerOutputItem = 0;
        IGrouping<MysticForgeRecipeOutput, MysticForgeRecipe>? output = null;

        foreach (var grouping in groupings)
        {
            decimal costPerOutputItem = GetItemRecipePricePerItem(grouping);
            if (output == null || costPerOutputItem < currentLowestCostPerOutputItem)
            {
                currentLowestCostPerOutputItem = costPerOutputItem;
                output = grouping;
            }
        }
        pricePerItem = currentLowestCostPerOutputItem;
        return output;
    }

    private decimal GetItemRecipePricePerItem(IGrouping<MysticForgeRecipeOutput, MysticForgeRecipe> grouping)
    {
        decimal currentInputItemsSum = 0;
        foreach (MysticForgeRecipe recipe in grouping)
        {
            if (recipe.RecipeInput.Item is VendorItem vendorItem)
            {
                GetCheapestVendorCostPerItem(vendorItem, out decimal goldCostPerVendorItem);
                currentInputItemsSum += goldCostPerVendorItem * recipe.RecipeInput.InputAmount.Amount;
            }
            else
            {
                CommercePrice? price = GetUnitPrice(recipe.RecipeInput.Item, IsRoot);
                ArgumentNullException.ThrowIfNull(price, nameof(price));
                currentInputItemsSum += price.UnitPrice * recipe.RecipeInput.InputAmount.Amount;
            }
        }
        decimal costPerOutputItem = currentInputItemsSum / grouping.Key.OutputAmount.Amount;
        return costPerOutputItem;
    }
}
