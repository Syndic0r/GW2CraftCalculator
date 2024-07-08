namespace GW2CraftCalculator.Models.Enums;

[Flags]
public enum ItemSpecifications
{
    CraftingMaterial = 1 << 0,
    Consumable = 1 << 1,
    SalvageKit = 1 << 2,
    MysticItem = 1 << 3,
    Trophy = 1 << 4,
    AccountBound = 1 << 5,
    NotCommerceable = AccountBound | SalvageKit
}
