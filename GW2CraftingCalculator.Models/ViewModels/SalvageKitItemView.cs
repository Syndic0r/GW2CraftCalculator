using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Models.ViewModels;
public class SalvageKitItemView : ItemView
{
    public SalvageUpgradesType SalvageUpgradesType { get; set; }

    public override KeyValuePair<Currency, decimal> GetProfit()
    {
        throw new NotImplementedException();
    }
}
