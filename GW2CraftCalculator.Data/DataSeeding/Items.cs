using GW2CraftCalculator.Models.Data;
using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Data.DataSeeding;

public class Items
{
    internal static IEnumerable<Item> Get()
    {
        return
        [
            #region Basic Items
            #region Cloth
            new Item()
            {
                Id = 19718,
                Name = "Jute Scrap",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Cloth,
                Tier = ItemTier.T1,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19739,
                Name = "Wool Scrap",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Cloth,
                Tier = ItemTier.T2,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19741,
                Name = "Cotton Scrap",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Cloth,
                Tier = ItemTier.T3,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19743,
                Name = "Linen Scrap",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Cloth,
                Tier = ItemTier.T4,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19748,
                Name = "Silk Scrap",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Cloth,
                Tier = ItemTier.T5,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19745,
                Name = "Gossamer Scrap",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Cloth,
                Tier = ItemTier.T6,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Leather
            new Item()
            {
                Id = 19719,
                Name = "Rawhide Leather Section",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Leather,
                Tier = ItemTier.T1,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19728,
                Name = "Thin Leather Section",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Leather,
                Tier = ItemTier.T2,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19730,
                Name = "Coarse Leather Section",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Leather,
                Tier = ItemTier.T3,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19731,
                Name = "Rugged Leather Section",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Leather,
                Tier = ItemTier.T4,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19729,
                Name = "Thick Leather Section",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Leather,
                Tier = ItemTier.T5,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19732,
                Name = "Hardened Leather Section",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Leather,
                Tier = ItemTier.T6,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Metal
            new Item()
            {
                Id = 19697,
                Name = "Copper Ore",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T1,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19699,
                Name = "Iron Ore",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T2,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19703,
                Name = "Silver Ore",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T2,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19698,
                Name = "Gold Ore",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T3,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19702,
                Name = "Platinum Ore",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T4,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19700,
                Name = "Mithril Ore",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T5,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19701,
                Name = "Orichalcum Ore",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T6,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Wood
            new Item()
            {
                Id = 19723,
                Name = "Green Wood Log",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Wood,
                Tier = ItemTier.T1,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19726,
                Name = "Soft Wood Log",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Wood,
                Tier = ItemTier.T2,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19727,
                Name = "Seasoned Wood Log",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Wood,
                Tier = ItemTier.T3,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19724,
                Name = "Hard Wood Log",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Wood,
                Tier = ItemTier.T4,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19722,
                Name = "Elder Wood Log",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Wood,
                Tier = ItemTier.T5,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19725,
                Name = "Ancient Wood Log",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Wood,
                Tier = ItemTier.T6,
                ItemType = ItemType.Basics,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #endregion
            #region Refined Common Items
            #region Cloth
            new Item()
            {
                Id = 19720,
                Name = "Bolt of Jute",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Cloth,
                Tier = ItemTier.T1,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19740,
                Name = "Bolt of Wool",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Cloth,
                Tier = ItemTier.T2,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19742,
                Name = "Bolt of Cotton",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Cloth,
                Tier = ItemTier.T3,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19744,
                Name = "Bolt of Linen",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Cloth,
                Tier = ItemTier.T4,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19747,
                Name = "Bolt of Silk",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Cloth,
                Tier = ItemTier.T5,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19746,
                Name = "Bolt of Gossamer",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Cloth,
                Tier = ItemTier.T6,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Leather
            new Item()
            {
                Id = 19738,
                Name = "Stretched Rawhide Leather Square",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Leather,
                Tier = ItemTier.T1,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19733,
                Name = "Cured Thin Leather Square",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Leather,
                Tier = ItemTier.T2,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19734,
                Name = "Cured Coarse Leather Square",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Leather,
                Tier = ItemTier.T3,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19736,
                Name = "Cured Rugged Leather Square",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Leather,
                Tier = ItemTier.T4,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19735,
                Name = "Cured Thick Leather Square",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Leather,
                Tier = ItemTier.T5,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19737,
                Name = "Cured Hardened Leather Square",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Leather,
                Tier = ItemTier.T6,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Metal
            new Item()
            {
                Id = 19680,
                Name = "Copper Ingot",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T1,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19679,
                Name = "Bronze Ingot",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T1,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19683,
                Name = "Iron Ingot",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T2,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19687,
                Name = "Silver Ingot",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T2,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19688,
                Name = "Steel Ingot",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T3,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19682,
                Name = "Gold Ingot",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T3,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19686,
                Name = "Platinum Ingot",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T4,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19681,
                Name = "Darksteel Ingot",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T4,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19684,
                Name = "Mithril Ingot",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T5,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19685,
                Name = "Orichalcum Ingot",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Metal,
                Tier = ItemTier.T6,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Wood
            new Item()
            {
                Id = 19710,
                Name = "Green Wood Plank",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Wood,
                Tier = ItemTier.T1,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19713,
                Name = "Soft Wood Plank",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Wood,
                Tier = ItemTier.T2,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19714,
                Name = "Seasoned Wood Plank",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Wood,
                Tier = ItemTier.T3,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19711,
                Name = "Hard Wood Plank",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Wood,
                Tier = ItemTier.T4,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19709,
                Name = "Elder Wood Plank",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Wood,
                Tier = ItemTier.T5,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 19712,
                Name = "Ancient Wood Plank",
                Rarity = Rarity.Basic,
                ItemGroup = ItemGroup.Wood,
                Tier = ItemTier.T6,
                ItemType = ItemType.Refineds,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #endregion
            #region Fine Items
            #region Bones
            new Item()
            {
                Id = 24342,
                Name = "Bone Chip",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Bone,
                Tier = ItemTier.T1,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24343,
                Name = "Bone Shard",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Bone,
                Tier = ItemTier.T2,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24344,
                Name = "Bone",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Bone,
                Tier = ItemTier.T3,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24345,
                Name = "Heavy Bone",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Bone,
                Tier = ItemTier.T4,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24341,
                Name = "Large Bone",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Bone,
                Tier = ItemTier.T5,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24358,
                Name = "Ancient Bone",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Bone,
                Tier = ItemTier.T6,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Claws
            new Item()
            {
                Id = 24346,
                Name = "Tiny Claw",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Claw,
                Tier = ItemTier.T1,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24347,
                Name = "Small Claw",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Claw,
                Tier = ItemTier.T2,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24348,
                Name = "Claw",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Claw,
                Tier = ItemTier.T3,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24349,
                Name = "Sharp Claw",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Claw,
                Tier = ItemTier.T4,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24350,
                Name = "Large Claw",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Claw,
                Tier = ItemTier.T5,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24351,
                Name = "Vicious Claw",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Claw,
                Tier = ItemTier.T6,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Dusts
            new Item()
            {
                Id = 24272,
                Name = "Pile of Glittering Dust",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Dust,
                Tier = ItemTier.T1,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24273,
                Name = "Pile of Shimmering Dust",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Dust,
                Tier = ItemTier.T2,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24274,
                Name = "Pile of Radiant Dust",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Dust,
                Tier = ItemTier.T3,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24275,
                Name = "Pile of Luminous Dust",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Dust,
                Tier = ItemTier.T4,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24276,
                Name = "Pile of Incandescent Dust",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Dust,
                Tier = ItemTier.T5,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24277,
                Name = "Pile of Crystalline Dust",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Dust,
                Tier = ItemTier.T6,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Fangs
            new Item()
            {
                Id = 24352,
                Name = "Tiny Fang",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Fang,
                Tier = ItemTier.T1,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24353,
                Name = "Small Fang",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Fang,
                Tier = ItemTier.T2,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24354,
                Name = "Fang",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Fang,
                Tier = ItemTier.T3,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24355,
                Name = "Sharp Fang",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Fang,
                Tier = ItemTier.T4,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24356,
                Name = "Large Fang",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Fang,
                Tier = ItemTier.T5,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24357,
                Name = "Vicious Fang",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Fang,
                Tier = ItemTier.T6,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Scales
            new Item()
            {
                Id = 24284,
                Name = "Tiny Scale",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Scale,
                Tier = ItemTier.T1,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24285,
                Name = "Small Scale",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Scale,
                Tier = ItemTier.T2,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24286,
                Name = "Scale",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Scale,
                Tier = ItemTier.T3,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24287,
                Name = "Smooth Scale",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Scale,
                Tier = ItemTier.T4,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24288,
                Name = "Large Scale",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Scale,
                Tier = ItemTier.T5,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24289,
                Name = "Armored Scale",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Scale,
                Tier = ItemTier.T6,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Totems
            new Item()
            {
                Id = 24296,
                Name = "Tiny Totem",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Totem,
                Tier = ItemTier.T1,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24297,
                Name = "Small Totem",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Totem,
                Tier = ItemTier.T2,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24298,
                Name = "Totem",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Totem,
                Tier = ItemTier.T3,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24363,
                Name = "Engraved Totem",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Totem,
                Tier = ItemTier.T4,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24299,
                Name = "Intricate Totem",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Totem,
                Tier = ItemTier.T5,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24300,
                Name = "Elaborate Totem",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Totem,
                Tier = ItemTier.T6,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Venoms
            new Item()
            {
                Id = 24278,
                Name = "Tiny Venom Sac",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Venom,
                Tier = ItemTier.T1,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24279,
                Name = "Small Venom Sac",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Venom,
                Tier = ItemTier.T2,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24280,
                Name = "Venom Sac",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Venom,
                Tier = ItemTier.T3,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24281,
                Name = "Full Venom Sac",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Venom,
                Tier = ItemTier.T4,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24282,
                Name = "Potent Venom Sac",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Venom,
                Tier = ItemTier.T5,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24283,
                Name = "Powerful Venom Sac",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Venom,
                Tier = ItemTier.T6,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Bloods
            new Item()
            {
                Id = 24290,
                Name = "Vial of Weak Blood",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Blood,
                Tier = ItemTier.T1,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24291,
                Name = "Vial of Thin Blood",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Blood,
                Tier = ItemTier.T2,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24292,
                Name = "Vial of Blood",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Blood,
                Tier = ItemTier.T3,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24293,
                Name = "Vial of Thick Blood",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Blood,
                Tier = ItemTier.T4,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24294,
                Name = "Vial of Potent Blood",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Blood,
                Tier = ItemTier.T5,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24295,
                Name = "Vial of Powerful Blood",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Blood,
                Tier = ItemTier.T6,
                ItemType = ItemType.Fines,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #endregion
            #region Rare Items
            #region Charged
            new Item()
            {
                Id = 24301,
                Name = "Charged Sliver",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Charged,
                Tier = ItemTier.T1,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24302,
                Name = "Charged Fragment",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Charged,
                Tier = ItemTier.T2,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24303,
                Name = "Charged Shard",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Charged,
                Tier = ItemTier.T3,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24304,
                Name = "Charged Core",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Charged,
                Tier = ItemTier.T4,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24305,
                Name = "Charged Lodestone",
                Rarity = Rarity.Exotic,
                ItemGroup = ItemGroup.Charged,
                Tier = ItemTier.T5,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Corrupted
            new Item()
            {
                Id = 24336,
                Name = "Corrupted Sliver",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Corrupted,
                Tier = ItemTier.T1,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24337,
                Name = "Corrupted Fragment",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Corrupted,
                Tier = ItemTier.T2,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24338,
                Name = "Corrupted Shard",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Corrupted,
                Tier = ItemTier.T3,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24339,
                Name = "Corrupted Core",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Corrupted,
                Tier = ItemTier.T4,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24340,
                Name = "Corrupted Lodestone",
                Rarity = Rarity.Exotic,
                ItemGroup = ItemGroup.Corrupted,
                Tier = ItemTier.T5,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Crystal
            new Item()
            {
                Id = 24326,
                Name = "Crystal Sliver",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Crystal,
                Tier = ItemTier.T1,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24327,
                Name = "Crystal Fragment",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Crystal,
                Tier = ItemTier.T2,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24328,
                Name = "Crystal Shard",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Crystal,
                Tier = ItemTier.T3,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24329,
                Name = "Crystal Core",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Crystal,
                Tier = ItemTier.T4,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24330,
                Name = "Crystal Lodestone",
                Rarity = Rarity.Exotic,
                ItemGroup = ItemGroup.Crystal,
                Tier = ItemTier.T5,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Destroyer
            new Item()
            {
                Id = 24321,
                Name = "Destroyer Sliver",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Destroyer,
                Tier = ItemTier.T1,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24322,
                Name = "Destroyer Fragment",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Destroyer,
                Tier = ItemTier.T2,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24323,
                Name = "Destroyer Shard",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Destroyer,
                Tier = ItemTier.T3,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24324,
                Name = "Destroyer Core",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Destroyer,
                Tier = ItemTier.T4,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24325,
                Name = "Destroyer Lodestone",
                Rarity = Rarity.Exotic,
                ItemGroup = ItemGroup.Destroyer,
                Tier = ItemTier.T5,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Essence
            new Item()
            {
                Id = 24331,
                Name = "Pile of Soiled Essence",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Essence,
                Tier = ItemTier.T1,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24332,
                Name = "Pile of Foul Essence",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Essence,
                Tier = ItemTier.T2,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24333,
                Name = "Pile of Filthy Essence",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Essence,
                Tier = ItemTier.T3,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24334,
                Name = "Pile of Vile Essence",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Essence,
                Tier = ItemTier.T4,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24335,
                Name = "Pile of Putrid Essence",
                Rarity = Rarity.Exotic,
                ItemGroup = ItemGroup.Essence,
                Tier = ItemTier.T5,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Glacial
            new Item()
            {
                Id = 24316,
                Name = "Glacial Sliver",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Glacial,
                Tier = ItemTier.T1,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24317,
                Name = "Glacial Fragment",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Glacial,
                Tier = ItemTier.T2,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24318,
                Name = "Glacial Shard",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Glacial,
                Tier = ItemTier.T3,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24319,
                Name = "Glacial Core",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Glacial,
                Tier = ItemTier.T4,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24320,
                Name = "Glacial Lodestone",
                Rarity = Rarity.Exotic,
                ItemGroup = ItemGroup.Glacial,
                Tier = ItemTier.T5,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Molten
            new Item()
            {
                Id = 24311,
                Name = "Molten Sliver",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Molten,
                Tier = ItemTier.T1,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24312,
                Name = "Molten Fragment",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Molten,
                Tier = ItemTier.T2,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24313,
                Name = "Molten Shard",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Molten,
                Tier = ItemTier.T3,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24314,
                Name = "Molten Core",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Molten,
                Tier = ItemTier.T4,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24315,
                Name = "Molten Lodestone",
                Rarity = Rarity.Exotic,
                ItemGroup = ItemGroup.Molten,
                Tier = ItemTier.T5,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #region Onyx
            new Item()
            {
                Id = 24306,
                Name = "Onyx Sliver",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Onyx,
                Tier = ItemTier.T1,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24307,
                Name = "Onyx Fragment",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Onyx,
                Tier = ItemTier.T2,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24308,
                Name = "Onyx Shard",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Onyx,
                Tier = ItemTier.T3,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24309,
                Name = "Onyx Core",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Onyx,
                Tier = ItemTier.T4,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            new Item()
            {
                Id = 24310,
                Name = "Onyx Lodestone",
                Rarity = Rarity.Exotic,
                ItemGroup = ItemGroup.Onyx,
                Tier = ItemTier.T5,
                ItemType = ItemType.Rares,
                Specifications = ItemSpecifications.CraftingMaterial
            },
            #endregion
            #endregion
            #region Luck
            new Item()
            {
                Id = 45175,
                Name = "Essence of Luck (fine)",
                Rarity = Rarity.Fine,
                ItemGroup = ItemGroup.Luck,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.CraftingMaterial | ItemSpecifications.Consumable | ItemSpecifications.AccountBound
            },
            new Item()
            {
                Id = 45176,
                Name = "Essence of Luck (masterwork)",
                Rarity = Rarity.Masterwork,
                ItemGroup = ItemGroup.Luck,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.CraftingMaterial | ItemSpecifications.Consumable | ItemSpecifications.AccountBound
            },
            new Item()
            {
                Id = 45177,
                Name = "Essence of Luck (rare)",
                Rarity = Rarity.Rare,
                ItemGroup = ItemGroup.Luck,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.CraftingMaterial | ItemSpecifications.Consumable | ItemSpecifications.AccountBound
            },
            new Item()
            {
                Id = 45178,
                Name = "Essence of Luck (exotic)",
                Rarity = Rarity.Exotic,
                ItemGroup = ItemGroup.Luck,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.CraftingMaterial | ItemSpecifications.Consumable | ItemSpecifications.AccountBound
            },
            #endregion
            #region AdditionalItems
            new Item()
            {
                Id = 19721,
                Name = "Glob of Ectoplasm",
                Rarity = Rarity.Exotic,
                ItemGroup = ItemGroup.None,
                Tier = ItemTier.None,
                ItemType = ItemType.None,
                Specifications = ItemSpecifications.Trophy
            }
            #endregion
        ];
    }
}
