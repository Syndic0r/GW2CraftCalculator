using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Models.ViewModels;
public class ItemVendorCostView : ItemCostView
{
    public int ItemAmount { get; set; }

    public override KeyValuePair<Currency, decimal> GetItemCost()
    {
        decimal vendorItemCostPerItem = (decimal)Amount / ItemAmount;

        if (CurrencyType == Currency.Coin)
        {
            vendorItemCostPerItem = Math.Ceiling(vendorItemCostPerItem);
        }

        return new(CurrencyType, vendorItemCostPerItem);
    }
}
