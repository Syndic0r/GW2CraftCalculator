using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Models.Data;
public record VendorItemSalvageKit : VendorItem
{
    public required decimal ChanceOfRareMaterials { get; set; }
    public required decimal ChanceOfSalvagingUpgrades { get; set; }
    public required SalvageUpgradesType SalvageUpgradesType { get; set; }
}
    