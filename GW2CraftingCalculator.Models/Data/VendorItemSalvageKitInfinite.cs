using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Models.Data;
public record VendorItemSalvageKitInfinite : VendorItemSalvageKit
{
    public required int CostsPerUse { get; set; }
    public required Currency CostPerUseCurrencyType { get; set; }
}
