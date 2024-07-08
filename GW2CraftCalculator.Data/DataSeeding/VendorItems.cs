using GW2CraftCalculator.Models.Data;
using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Data.DataSeeding;

public class VendorItems
{
    internal static IEnumerable<object> Get()
    {
        return
        [
            new VendorItem()
            {
                Id = 20796,
                Name = "Philosopher's Stone",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.None,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.Trophy | ItemSpecifications.MysticItem | ItemSpecifications.AccountBound,
                ItemAmount = 10
            },
            new VendorItem()
            {
                Id = 20799,
                Name = "Mystic Crystal",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.None,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.Trophy | ItemSpecifications.MysticItem | ItemSpecifications.AccountBound,
                ItemAmount = 5
            },
            new VendorItem()
            {
                Id = 19663,
                Name = "Bottle of Elonian Wine",
                Rarity = Rarity.Exotic,
                ItemGroup = ItemGroup.None,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.Trophy,
                ItemAmount = 1
            },
            new VendorItem()
            {
                Id = 39125,
                Name = "Mystic Binding Agent",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.None,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.Trophy | ItemSpecifications.MysticItem | ItemSpecifications.AccountBound,
                ItemAmount = 10
            }
        ];
    }

    internal static IEnumerable<object> GetCosts()
    {
        return
        [
            new
            {
                Id = 1,
                Amount = 1,
                CurrencyType = Currency.SpiritShard,
                VendorItemId = 20796
            },
            new
            {
                Id = 2,
                Amount = 3,
                CurrencyType = Currency.SpiritShard,
                VendorItemId = 20799
            },
            new
            {
                Id = 3,
                Amount = 2504,
                CurrencyType = Currency.Coin,
                VendorItemId = 19663
            },
            new
            {
                Id = 4,
                Amount = 10,
                CurrencyType = Currency.Laurel,
                VendorItemId = 39125
            },
            new
            {
                Id = 5,
                Amount = 32,
                CurrencyType = Currency.Coin,
                VendorItemId = 23038
            },
            new
            {
                Id = 6,
                Amount = 28,
                CurrencyType = Currency.Karma,
                VendorItemId = 23038
            },
            new
            {
                Id = 7,
                Amount = 88,
                CurrencyType = Currency.Coin,
                VendorItemId = 23040
            },
            new
            {
                Id = 8,
                Amount = 77,
                CurrencyType = Currency.Karma,
                VendorItemId = 23040
            },
            new
            {
                Id = 9,
                Amount = 288,
                CurrencyType = Currency.Coin,
                VendorItemId = 23041
            },
            new
            {
                Id = 10,
                Amount = 252,
                CurrencyType = Currency.Karma,
                VendorItemId = 23041
            },
            new
            {
                Id = 11,
                Amount = 800,
                CurrencyType = Currency.Coin,
                VendorItemId = 23042
            },
            new
            {
                Id = 12,
                Amount = 2800,
                CurrencyType = Currency.Karma,
                VendorItemId = 23042
            },
            new
            {
                Id = 13,
                Amount = 1536,
                CurrencyType = Currency.Coin,
                VendorItemId = 23043
            },
            new
            {
                Id = 14,
                Amount = 5600,
                CurrencyType = Currency.Karma,
                VendorItemId = 23043
            },
            new
            {
                Id = 15,
                Amount = 2624,
                CurrencyType = Currency.Coin,
                VendorItemId = 23045
            },
            new
            {
                Id = 16,
                Amount = 8652,
                CurrencyType = Currency.Karma,
                VendorItemId = 23045
            },
            new
            {
                Id = 17,
                Amount = 300,
                CurrencyType = Currency.Gems,
                VendorItemId = 19986
            },
            new
            {
                Id = 18,
                Amount = 800,
                CurrencyType = Currency.Gems,
                VendorItemId = 44602
            },
            new
            {
                Id = 19,
                Amount = 500,
                CurrencyType = Currency.Gems,
                VendorItemId = 67027
            },
            new
            {
                Id = 20,
                Amount = 600,
                CurrencyType = Currency.Gems,
                VendorItemId = 89409
            }
        ];
    }

    internal static IEnumerable<VendorItemSalvageKit> GetSalvageKits()
    {
        return
        [
            new VendorItemSalvageKit()
            {
                Id = 23038,
                Name = "Crude Salvage Kit",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.None,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.Consumable | ItemSpecifications.SalvageKit,
                ItemAmount = 15,
                ChanceOfRareMaterials = 0,
                ChanceOfSalvagingUpgrades = 0.05M,
                SalvageUpgradesType = SalvageUpgradesType.Salvage
            },
            new VendorItemSalvageKit()
            {
                Id = 23040,
                Name = "Basic Salvage Kit",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.None,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.Consumable | ItemSpecifications.SalvageKit,
                ItemAmount = 25,
                ChanceOfRareMaterials = 0.1M,
                ChanceOfSalvagingUpgrades = 0.2M,
                SalvageUpgradesType = SalvageUpgradesType.Salvage
            },
            new VendorItemSalvageKit()
            {
                Id = 23041,
                Name = "Fine Salvage Kit",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.None,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.Consumable | ItemSpecifications.SalvageKit,
                ItemAmount = 25,
                ChanceOfRareMaterials = 0.15M,
                ChanceOfSalvagingUpgrades = 0.4M,
                SalvageUpgradesType = SalvageUpgradesType.Salvage
            },
            new VendorItemSalvageKit()
            {
                Id = 23042,
                Name = "Journeyman's Salvage Kit",
                Rarity = Rarity.Masterwork,
                ItemGroup = ItemGroup.None,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.Consumable | ItemSpecifications.SalvageKit,
                ItemAmount = 25,
                ChanceOfRareMaterials = 0.2M,
                ChanceOfSalvagingUpgrades = 0.6M,
                SalvageUpgradesType = SalvageUpgradesType.Salvage
            },
            new VendorItemSalvageKit()
            {
                Id = 23043,
                Name = "Master's Salvage Kit",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.None,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.Consumable | ItemSpecifications.SalvageKit,
                ItemAmount = 25,
                ChanceOfRareMaterials = 0.25M,
                ChanceOfSalvagingUpgrades = 0.8M,
                SalvageUpgradesType = SalvageUpgradesType.Salvage
            },
            new VendorItemSalvageKit()
            {
                Id = 23045,
                Name = "Mystic Salvage Kit",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.None,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.Consumable | ItemSpecifications.SalvageKit,
                ItemAmount = 250,
                ChanceOfRareMaterials = 0.25M,
                ChanceOfSalvagingUpgrades = 0.8M,
                SalvageUpgradesType = SalvageUpgradesType.Salvage
            },
            new VendorItemSalvageKit()
            {
                Id = 19986,
                Name = "Black Lion Salvage Kit",
                Rarity = Rarity.Exotic,
                ItemGroup = ItemGroup.None,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.Consumable | ItemSpecifications.SalvageKit,
                ItemAmount = 25,
                ChanceOfRareMaterials = 0.5M,
                ChanceOfSalvagingUpgrades = 1M,
                SalvageUpgradesType = SalvageUpgradesType.Recover
            }
        ];
    }

    internal static IEnumerable<VendorItemSalvageKitInfinite> GetSalvageKitInfinites()
    {
        return
        [
            new VendorItemSalvageKitInfinite()
            {
                Id = 44602,
                Name = "Copper-Fed Salvage-o-Matic",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.None,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.Consumable | ItemSpecifications.SalvageKit | ItemSpecifications.AccountBound,
                ItemAmount = 1,
                CostsPerUse = 3,
                CostPerUseCurrencyType = Currency.Coin,
                ChanceOfRareMaterials = 0.1M,
                ChanceOfSalvagingUpgrades = 0.2M,
                SalvageUpgradesType = SalvageUpgradesType.Salvage
            },
            new VendorItemSalvageKitInfinite()
            {
                Id = 67027,
                Name = "Silver-Fed Salvage-o-Matic",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.None,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.Consumable | ItemSpecifications.SalvageKit | ItemSpecifications.AccountBound,
                ItemAmount = 1,
                CostsPerUse = 60,
                CostPerUseCurrencyType = Currency.Coin,
                ChanceOfRareMaterials = 0.25M,
                ChanceOfSalvagingUpgrades = 0.8M,
                SalvageUpgradesType = SalvageUpgradesType.Salvage
            },
            new VendorItemSalvageKitInfinite()
            {
                Id = 89409,
                Name = "Runecrafter's Salvage-o-Matic",
                Rarity = Rarity.Exotic,
                ItemGroup = ItemGroup.None,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.Consumable | ItemSpecifications.SalvageKit | ItemSpecifications.AccountBound,
                ItemAmount = 1,
                CostsPerUse = 30,
                CostPerUseCurrencyType = Currency.Coin,
                ChanceOfRareMaterials = 0.2M,
                ChanceOfSalvagingUpgrades = 1M,
                SalvageUpgradesType = SalvageUpgradesType.Salvage
            },
        ];
    }
}
