using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Models.ViewModels;
public class SalvageItemView : ItemView
{
    public SalvageKitItemView SalvageKit { get; set; }

    public override Dictionary<Currency, decimal>? GetTotalValues()
    {
        Dictionary<Currency, decimal>? itemValue = base.GetTotalValues();

        if (itemValue == null)
        {
            return null;
        }

        KeyValuePair<Currency, decimal>? salvageKitItemPrice = SalvageKit.GetPricePerItem();

        if (salvageKitItemPrice == null)
        {
            return itemValue;
        }

        if (itemValue.TryGetValue(salvageKitItemPrice.Value.Key, out decimal currentItemValue))
        {
            itemValue[salvageKitItemPrice.Value.Key] = currentItemValue + (salvageKitItemPrice.Value.Value * (Amount + OverproducedAmount));
        }

        return itemValue;
    }
}
