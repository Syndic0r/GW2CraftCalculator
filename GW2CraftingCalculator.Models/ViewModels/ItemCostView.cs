using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Models.ViewModels;
public class ItemCostView
{
    public int Amount { get; set; }
    public Currency CurrencyType { get; set; }

    public virtual KeyValuePair<Currency, decimal> GetItemCost() => new(CurrencyType, Amount);
}
