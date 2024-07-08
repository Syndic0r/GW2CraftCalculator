using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Models.ViewModels;
public class SalvageKitInfiniteItemView : SalvageKitItemView
{
    public int CostsPerUse { get; set; }
    public Currency CostPerUseCurrencyType { get; set; }

    public override KeyValuePair<Currency, decimal>? GetPricePerItem() => new(Currency.Coin, CostsPerUse);

    public override KeyValuePair<Currency, decimal> GetProfit()
    {
        throw new NotImplementedException();
    }
}
