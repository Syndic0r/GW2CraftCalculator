using GW2CraftCalculator.Models.Data;

namespace GW2CraftCalculator.Logic.ViewModelCreators;
public abstract class ItemViewExtendedCreator<TCurrentItem, TCurrentItemExtension> : ItemViewCreator<TCurrentItem> where TCurrentItem : class
{
    private protected ItemViewExtendedCreator(ItemViewDefaultCreator creator) : base(creator) { }

    private protected ItemViewExtendedCreator(ItemViewExtendedCreator<TCurrentItem, TCurrentItemExtension> creator) : base(creator)
    {
        CurrentItemExtension = creator.CurrentItemExtension;
    }

    public TCurrentItemExtension? CurrentItemExtension { get; init; }

    public int? Factor { get => _factor; init => _factor = value; }

    private protected int? _factor;

    public abstract ItemViewExtendedCreator<TItem, TExtension> Clone<TItem, TExtension>(TItem? currentItem = default, TExtension? extensionInfo = default, int? factor = null, bool isRoot = false)
        where TItem : class;

    public VendorCost GetVendorCost()
    {
        VendorItem vendorItem = GetCurrentItemConverted<VendorItem>();
        int vendorCostId = GetExtensionConverted<int>();
        return GetVendorCost(vendorItem, vendorCostId);
    }

    private static VendorCost GetVendorCost(VendorItem vendorItem, int vendorCostId)
    {
        VendorCost currentVendorCost = vendorItem.Cost.First(c => c.Id == vendorCostId);
        return currentVendorCost;
    }

    private protected decimal GetVendorCostPerItemGoldConverted(VendorItem vendorItem, int vendorCostId)
    {
        if (vendorItem is VendorItemSalvageKitInfinite salvageKitInfinite)
        {
            return salvageKitInfinite.CostsPerUse;
        }

        VendorCost vendorCost = GetVendorCost(vendorItem, vendorCostId);
        decimal goldCost = GetVendorCostGoldConverted(vendorCost);
        decimal goldPerUse = Math.Ceiling(goldCost) / vendorItem.ItemAmount;
        return goldPerUse;
    }

    private protected VendorCost GetCheapestVendorCostPerItem(VendorItem vendorItem, out decimal costPerItemGoldConverted)
    {
        VendorCost? cheapestCost = null;
        costPerItemGoldConverted = 0;
        foreach (VendorCost vendorCost in vendorItem.Cost)
        {
            decimal vendorItemGoldCost = GetVendorCostGoldConverted(vendorCost);
            decimal vendorCostPerItemGoldConverted = Math.Ceiling(vendorItemGoldCost) / vendorItem.ItemAmount;
            if (cheapestCost == null || costPerItemGoldConverted > vendorCostPerItemGoldConverted)
            {
                cheapestCost = vendorCost;
                costPerItemGoldConverted = vendorCostPerItemGoldConverted;
            }
        }

        return cheapestCost!;
    }

    private protected T GetExtensionConverted<T>()
    {
        ArgumentNullException.ThrowIfNull(CurrentItemExtension);
        if (CurrentItemExtension is not T extension)
        {
            string message = $"Failed to convert '{nameof(CurrentItemExtension)}' of Type '{CurrentItemExtension.GetType()}' to Type '{typeof(T)}'.";
            throw new InvalidCastException(message);
        }
        return extension;
    }
}
