namespace GW2CraftCalculator.Data.DataSeeding;

public class MysticForgeRecipes
{
    internal static IEnumerable<object> Get()
    {
        return
        [
            #region Common Items
            #region Cloth
            //Wool Scrap
            new
            {
                Id = 1,
                RecipeOutputId = 1,
                RecipeInputId = 25,
            },
            new
            {
                Id = 2,
                RecipeOutputId = 1,
                RecipeInputId = 26,
            },
            new
            {
                Id = 3,
                RecipeOutputId = 1,
                RecipeInputId = 16,
            },
            new
            {
                Id = 4,
                RecipeOutputId = 1,
                RecipeInputId = 1,
            },
            //Cotten Scrap
            new
            {
                Id = 5,
                RecipeOutputId = 2,
                RecipeInputId = 27,
            },
            new
            {
                Id = 6,
                RecipeOutputId = 2,
                RecipeInputId = 28,
            },
            new
            {
                Id = 7,
                RecipeOutputId = 2,
                RecipeInputId = 18,
            },
            new
            {
                Id = 8,
                RecipeOutputId = 2,
                RecipeInputId = 2,
            },
            //Linen Scrap
            new
            {
                Id = 9,
                RecipeOutputId = 3,
                RecipeInputId = 29,
            },
            new
            {
                Id = 10,
                RecipeOutputId = 3,
                RecipeInputId = 30,
            },
            new
            {
                Id = 11,
                RecipeOutputId = 3,
                RecipeInputId = 18,
            },
            new
            {
                Id = 12,
                RecipeOutputId = 3,
                RecipeInputId = 3,
            },
            //Silk Scrap
            new
            {
                Id = 13,
                RecipeOutputId = 4,
                RecipeInputId = 31,
            },
            new
            {
                Id = 14,
                RecipeOutputId = 4,
                RecipeInputId = 32,
            },
            new
            {
                Id = 15,
                RecipeOutputId = 4,
                RecipeInputId = 22,
            },
            new
            {
                Id = 16,
                RecipeOutputId = 4,
                RecipeInputId = 4,
            },
            //Gossamer Scrap
            new
            {
                Id = 17,
                RecipeOutputId = 5,
                RecipeInputId = 33,
            },
            new
            {
                Id = 18,
                RecipeOutputId = 5,
                RecipeInputId = 34,
            },
            new
            {
                Id = 19,
                RecipeOutputId = 5,
                RecipeInputId = 24,
            },
            new
            {
                Id = 20,
                RecipeOutputId = 5,
                RecipeInputId = 5,
            },
            #endregion
            #region Leather
            //Thin Leather Section
            new
            {
                Id = 21,
                RecipeOutputId = 6,
                RecipeInputId = 35,
            },
            new
            {
                Id = 22,
                RecipeOutputId = 6,
                RecipeInputId = 36,
            },
            new
            {
                Id = 23,
                RecipeOutputId = 6,
                RecipeInputId = 16,
            },
            new
            {
                Id = 24,
                RecipeOutputId = 6,
                RecipeInputId = 1,
            },
            //Coarse Leather Section
            new
            {
                Id = 25,
                RecipeOutputId = 7,
                RecipeInputId = 37,
            },
            new
            {
                Id = 26,
                RecipeOutputId = 7,
                RecipeInputId = 38,
            },
            new
            {
                Id = 27,
                RecipeOutputId = 7,
                RecipeInputId = 18,
            },
            new
            {
                Id = 28,
                RecipeOutputId = 7,
                RecipeInputId = 2,
            },
            //Rugged Leather Section
            new
            {
                Id = 29,
                RecipeOutputId = 8,
                RecipeInputId = 39,
            },
            new
            {
                Id = 30,
                RecipeOutputId = 8,
                RecipeInputId = 40,
            },
            new
            {
                Id = 31,
                RecipeOutputId = 8,
                RecipeInputId = 18,
            },
            new
            {
                Id = 32,
                RecipeOutputId = 8,
                RecipeInputId = 3,
            },
            //Thick Leather Section
            new
            {
                Id = 33,
                RecipeOutputId = 9,
                RecipeInputId = 41,
            },
            new
            {
                Id = 34,
                RecipeOutputId = 9,
                RecipeInputId = 42,
            },
            new
            {
                Id = 35,
                RecipeOutputId = 9,
                RecipeInputId = 22,
            },
            new
            {
                Id = 36,
                RecipeOutputId = 9,
                RecipeInputId = 4,
            },
            //Hardened Leather Section
            new
            {
                Id = 37,
                RecipeOutputId = 10,
                RecipeInputId = 43,
            },
            new
            {
                Id = 38,
                RecipeOutputId = 10,
                RecipeInputId = 44,
            },
            new
            {
                Id = 39,
                RecipeOutputId = 10,
                RecipeInputId = 24,
            },
            new
            {
                Id = 40,
                RecipeOutputId = 10,
                RecipeInputId = 5,
            },
            #endregion
            #region Metal
            //Iron Ore
            new
            {
                Id = 41,
                RecipeOutputId = 11,
                RecipeInputId = 45,
            },
            new
            {
                Id = 42,
                RecipeOutputId = 11,
                RecipeInputId = 46,
            },
            new
            {
                Id = 43,
                RecipeOutputId = 11,
                RecipeInputId = 16,
            },
            new
            {
                Id = 44,
                RecipeOutputId = 11,
                RecipeInputId = 1,
            },
            //Gold Ore
            new
            {
                Id = 45,
                RecipeOutputId = 12,
                RecipeInputId = 48,
            },
            new
            {
                Id = 46,
                RecipeOutputId = 12,
                RecipeInputId = 49,
            },
            new
            {
                Id = 47,
                RecipeOutputId = 12,
                RecipeInputId = 18,
            },
            new
            {
                Id = 48,
                RecipeOutputId = 12,
                RecipeInputId = 2,
            },
            //Platinum Ore with Gold Ore
            new
            {
                Id = 49,
                RecipeOutputId = 13,
                RecipeInputId = 50,
            },
            new
            {
                Id = 50,
                RecipeOutputId = 13,
                RecipeInputId = 51,
            },
            new
            {
                Id = 51,
                RecipeOutputId = 13,
                RecipeInputId = 20,
            },
            new
            {
                Id = 52,
                RecipeOutputId = 13,
                RecipeInputId = 4,
            },
            //Platinum Ore with Iron Ore
            new
            {
                Id = 53,
                RecipeOutputId = 14,
                RecipeInputId = 47,
            },
            new
            {
                Id = 54,
                RecipeOutputId = 14,
                RecipeInputId = 51,
            },
            new
            {
                Id = 55,
                RecipeOutputId = 14,
                RecipeInputId = 18,
            },
            new
            {
                Id = 56,
                RecipeOutputId = 14,
                RecipeInputId = 2,
            },
            //Mithril Ore
            new
            {
                Id = 57,
                RecipeOutputId = 15,
                RecipeInputId = 52,
            },
            new
            {
                Id = 58,
                RecipeOutputId = 15,
                RecipeInputId = 53,
            },
            new
            {
                Id = 59,
                RecipeOutputId = 15,
                RecipeInputId = 22,
            },
            new
            {
                Id = 60,
                RecipeOutputId = 15,
                RecipeInputId = 4,
            },
            //Orichalcum Ore
            new
            {
                Id = 61,
                RecipeOutputId = 16,
                RecipeInputId = 54,
            },
            new
            {
                Id = 62,
                RecipeOutputId = 16,
                RecipeInputId = 55,
            },
            new
            {
                Id = 63,
                RecipeOutputId = 16,
                RecipeInputId = 24,
            },
            new
            {
                Id = 64,
                RecipeOutputId = 16,
                RecipeInputId = 5,
            },
            #endregion
            #region Wood
            //Soft Wood Log
            new
            {
                Id = 65,
                RecipeOutputId = 17,
                RecipeInputId = 56,
            },
            new
            {
                Id = 66,
                RecipeOutputId = 17,
                RecipeInputId = 57,
            },
            new
            {
                Id = 67,
                RecipeOutputId = 17,
                RecipeInputId = 16,
            },
            new
            {
                Id = 68,
                RecipeOutputId = 17,
                RecipeInputId = 1,
            },
            //Seasoned Wood Log
            new
            {
                Id = 69,
                RecipeOutputId = 18,
                RecipeInputId = 58,
            },
            new
            {
                Id = 70,
                RecipeOutputId = 18,
                RecipeInputId = 59,
            },
            new
            {
                Id = 71,
                RecipeOutputId = 18,
                RecipeInputId = 18,
            },
            new
            {
                Id = 72,
                RecipeOutputId = 18,
                RecipeInputId = 2,
            },
            //Hard Wood Log
            new
            {
                Id = 73,
                RecipeOutputId = 19,
                RecipeInputId = 60,
            },
            new
            {
                Id = 74,
                RecipeOutputId = 19,
                RecipeInputId = 61,
            },
            new
            {
                Id = 75,
                RecipeOutputId = 19,
                RecipeInputId = 18,
            },
            new
            {
                Id = 76,
                RecipeOutputId = 19,
                RecipeInputId = 3,
            },
            //Elder Wood Log
            new
            {
                Id = 77,
                RecipeOutputId = 20,
                RecipeInputId = 62,
            },
            new
            {
                Id = 78,
                RecipeOutputId = 20,
                RecipeInputId = 63,
            },
            new
            {
                Id = 79,
                RecipeOutputId = 20,
                RecipeInputId = 22,
            },
            new
            {
                Id = 80,
                RecipeOutputId = 20,
                RecipeInputId = 4,
            },
            //Ancient Wood Log
            new
            {
                Id = 81,
                RecipeOutputId = 21,
                RecipeInputId = 64,
            },
            new
            {
                Id = 82,
                RecipeOutputId = 21,
                RecipeInputId = 65,
            },
            new
            {
                Id = 83,
                RecipeOutputId = 21,
                RecipeInputId = 24,
            },
            new
            {
                Id = 84,
                RecipeOutputId = 21,
                RecipeInputId = 5,
            },
            #endregion
            #endregion
            #region Refined Common Items
            #region Cloth
            //Bolt of Wool
            new
            {
                Id = 85,
                RecipeOutputId = 22,
                RecipeInputId = 66,
            },
            new
            {
                Id = 86,
                RecipeOutputId = 22,
                RecipeInputId = 67,
            },
            new
            {
                Id = 87,
                RecipeOutputId = 22,
                RecipeInputId = 16,
            },
            new
            {
                Id = 88,
                RecipeOutputId = 22,
                RecipeInputId = 2,
            },
            //Bolt of Cotton
            new
            {
                Id = 89,
                RecipeOutputId = 23,
                RecipeInputId = 68,
            },
            new
            {
                Id = 90,
                RecipeOutputId = 23,
                RecipeInputId = 69,
            },
            new
            {
                Id = 91,
                RecipeOutputId = 23,
                RecipeInputId = 18,
            },
            new
            {
                Id = 92,
                RecipeOutputId = 23,
                RecipeInputId = 4,
            },
            //Bolt of Linen
            new
            {
                Id = 93,
                RecipeOutputId = 24,
                RecipeInputId = 70,
            },
            new
            {
                Id = 94,
                RecipeOutputId = 24,
                RecipeInputId = 71,
            },
            new
            {
                Id = 95,
                RecipeOutputId = 24,
                RecipeInputId = 18,
            },
            new
            {
                Id = 96,
                RecipeOutputId = 24,
                RecipeInputId = 6,
            },
            //Bolt of Silk
            new
            {
                Id = 97,
                RecipeOutputId = 25,
                RecipeInputId = 72,
            },
            new
            {
                Id = 98,
                RecipeOutputId = 25,
                RecipeInputId = 73,
            },
            new
            {
                Id = 99,
                RecipeOutputId = 25,
                RecipeInputId = 22,
            },
            new
            {
                Id = 100,
                RecipeOutputId = 25,
                RecipeInputId = 7,
            },
            //Bolt of Gossamer
            new
            {
                Id = 101,
                RecipeOutputId = 26,
                RecipeInputId = 74,
            },
            new
            {
                Id = 102,
                RecipeOutputId = 26,
                RecipeInputId = 75,
            },
            new
            {
                Id = 103,
                RecipeOutputId = 26,
                RecipeInputId = 24,
            },
            new
            {
                Id = 104,
                RecipeOutputId = 26,
                RecipeInputId = 8,
            },
            #endregion
            #region Leather
            //Cured Thin Leather Square
            new
            {
                Id = 105,
                RecipeOutputId = 27,
                RecipeInputId = 76,
            },
            new
            {
                Id = 106,
                RecipeOutputId = 27,
                RecipeInputId = 77,
            },
            new
            {
                Id = 107,
                RecipeOutputId = 27,
                RecipeInputId = 16,
            },
            new
            {
                Id = 108,
                RecipeOutputId = 27,
                RecipeInputId = 2,
            },
            //Cured Coarse Leather Square
            new
            {
                Id = 109,
                RecipeOutputId = 28,
                RecipeInputId = 78,
            },
            new
            {
                Id = 110,
                RecipeOutputId = 28,
                RecipeInputId = 79,
            },
            new
            {
                Id = 111,
                RecipeOutputId = 28,
                RecipeInputId = 18,
            },
            new
            {
                Id = 112,
                RecipeOutputId = 28,
                RecipeInputId = 4,
            },
            //Cured Rugged Leather Square
            new
            {
                Id = 113,
                RecipeOutputId = 29,
                RecipeInputId = 80,
            },
            new
            {
                Id = 114,
                RecipeOutputId = 29,
                RecipeInputId = 81,
            },
            new
            {
                Id = 115,
                RecipeOutputId = 29,
                RecipeInputId = 18,
            },
            new
            {
                Id = 116,
                RecipeOutputId = 29,
                RecipeInputId = 6,
            },
            //Cured Thick Leather Square
            new
            {
                Id = 117,
                RecipeOutputId = 30,
                RecipeInputId = 82,
            },
            new
            {
                Id = 118,
                RecipeOutputId = 30,
                RecipeInputId = 83,
            },
            new
            {
                Id = 119,
                RecipeOutputId = 30,
                RecipeInputId = 22,
            },
            new
            {
                Id = 120,
                RecipeOutputId = 30,
                RecipeInputId = 7,
            },
            //Cured Hardened Leather Square
            new
            {
                Id = 121,
                RecipeOutputId = 31,
                RecipeInputId = 84,
            },
            new
            {
                Id = 122,
                RecipeOutputId = 31,
                RecipeInputId = 85,
            },
            new
            {
                Id = 123,
                RecipeOutputId = 31,
                RecipeInputId = 24,
            },
            new
            {
                Id = 124,
                RecipeOutputId = 31,
                RecipeInputId = 8,
            },
            #endregion
            #region Metal
            //Silver Ingot
            new
            {
                Id = 125,
                RecipeOutputId = 32,
                RecipeInputId = 86,
            },
            new
            {
                Id = 126,
                RecipeOutputId = 32,
                RecipeInputId = 88,
            },
            new
            {
                Id = 127,
                RecipeOutputId = 32,
                RecipeInputId = 16,
            },
            new
            {
                Id = 128,
                RecipeOutputId = 32,
                RecipeInputId = 2,
            },
            //Iron Ingot
            new
            {
                Id = 129,
                RecipeOutputId = 33,
                RecipeInputId = 87,
            },
            new
            {
                Id = 130,
                RecipeOutputId = 33,
                RecipeInputId = 90,
            },
            new
            {
                Id = 131,
                RecipeOutputId = 33,
                RecipeInputId = 16,
            },
            new
            {
                Id = 132,
                RecipeOutputId = 33,
                RecipeInputId = 2,
            },
            //Steel Ingot
            new
            {
                Id = 133,
                RecipeOutputId = 34,
                RecipeInputId = 91,
            },
            new
            {
                Id = 134,
                RecipeOutputId = 34,
                RecipeInputId = 92,
            },
            new
            {
                Id = 135,
                RecipeOutputId = 34,
                RecipeInputId = 18,
            },
            new
            {
                Id = 136,
                RecipeOutputId = 34,
                RecipeInputId = 4,
            },
            //Gold Ingot
            new
            {
                Id = 137,
                RecipeOutputId = 35,
                RecipeInputId = 89,
            },
            new
            {
                Id = 138,
                RecipeOutputId = 35,
                RecipeInputId = 93,
            },
            new
            {
                Id = 139,
                RecipeOutputId = 35,
                RecipeInputId = 18,
            },
            new
            {
                Id = 140,
                RecipeOutputId = 35,
                RecipeInputId = 4,
            },
            //Platinum Ingot
            new
            {
                Id = 141,
                RecipeOutputId = 36,
                RecipeInputId = 94,
            },
            new
            {
                Id = 142,
                RecipeOutputId = 36,
                RecipeInputId = 95,
            },
            new
            {
                Id = 143,
                RecipeOutputId = 36,
                RecipeInputId = 20,
            },
            new
            {
                Id = 144,
                RecipeOutputId = 36,
                RecipeInputId = 6,
            },
            //Mithril Ingot with Darksteel Ingot
            new
            {
                Id = 145,
                RecipeOutputId = 37,
                RecipeInputId = 97,
            },
            new
            {
                Id = 146,
                RecipeOutputId = 37,
                RecipeInputId = 98,
            },
            new
            {
                Id = 147,
                RecipeOutputId = 37,
                RecipeInputId = 20,
            },
            new
            {
                Id = 148,
                RecipeOutputId = 37,
                RecipeInputId = 6,
            },
            //Mithril Ingot with Platinum Ingot
            new
            {
                Id = 149,
                RecipeOutputId = 38,
                RecipeInputId = 96,
            },
            new
            {
                Id = 150,
                RecipeOutputId = 38,
                RecipeInputId = 98,
            },
            new
            {
                Id = 151,
                RecipeOutputId = 38,
                RecipeInputId = 22,
            },
            new
            {
                Id = 152,
                RecipeOutputId = 38,
                RecipeInputId = 7,
            },
            //Orchalcum Ingot
            new
            {
                Id = 153,
                RecipeOutputId = 39,
                RecipeInputId = 99,
            },
            new
            {
                Id = 154,
                RecipeOutputId = 39,
                RecipeInputId = 100,
            },
            new
            {
                Id = 155,
                RecipeOutputId = 39,
                RecipeInputId = 24,
            },
            new
            {
                Id = 156,
                RecipeOutputId = 39,
                RecipeInputId = 8,
            },
            #endregion
            #region Wood
            //Soft Wood Plank
            new
            {
                Id = 157,
                RecipeOutputId = 40,
                RecipeInputId = 101,
            },
            new
            {
                Id = 158,
                RecipeOutputId = 40,
                RecipeInputId = 102,
            },
            new
            {
                Id = 159,
                RecipeOutputId = 40,
                RecipeInputId = 16,
            },
            new
            {
                Id = 160,
                RecipeOutputId = 40,
                RecipeInputId = 2,
            },
            //Seasoned Wood Plank
            new
            {
                Id = 161,
                RecipeOutputId = 41,
                RecipeInputId = 103,
            },
            new
            {
                Id = 162,
                RecipeOutputId = 41,
                RecipeInputId = 104,
            },
            new
            {
                Id = 163,
                RecipeOutputId = 41,
                RecipeInputId = 18,
            },
            new
            {
                Id = 164,
                RecipeOutputId = 41,
                RecipeInputId = 4,
            },
            //Hard Wood Plank
            new
            {
                Id = 165,
                RecipeOutputId = 42,
                RecipeInputId = 105,
            },
            new
            {
                Id = 166,
                RecipeOutputId = 42,
                RecipeInputId = 106,
            },
            new
            {
                Id = 167,
                RecipeOutputId = 42,
                RecipeInputId = 18,
            },
            new
            {
                Id = 168,
                RecipeOutputId = 42,
                RecipeInputId = 6,
            },
            //Elder Wood Plank
            new
            {
                Id = 169,
                RecipeOutputId = 43,
                RecipeInputId = 107,
            },
            new
            {
                Id = 170,
                RecipeOutputId = 43,
                RecipeInputId = 108,
            },
            new
            {
                Id = 171,
                RecipeOutputId = 43,
                RecipeInputId = 22,
            },
            new
            {
                Id = 172,
                RecipeOutputId = 43,
                RecipeInputId = 7,
            },
            //Ancient Wood Plank
            new
            {
                Id = 173,
                RecipeOutputId = 44,
                RecipeInputId = 109,
            },
            new
            {
                Id = 174,
                RecipeOutputId = 44,
                RecipeInputId = 110,
            },
            new
            {
                Id = 175,
                RecipeOutputId = 44,
                RecipeInputId = 24,
            },
            new
            {
                Id = 176,
                RecipeOutputId = 44,
                RecipeInputId = 8,
            },
            #endregion
            #endregion
            #region Fine Items
            #region Bones
            //Bone Shard
            new
            {
                Id = 177,
                RecipeOutputId = 45,
                RecipeInputId = 111,
            },
            new
            {
                Id = 178,
                RecipeOutputId = 45,
                RecipeInputId = 112,
            },
            new
            {
                Id = 179,
                RecipeOutputId = 45,
                RecipeInputId = 16,
            },
            new
            {
                Id = 180,
                RecipeOutputId = 45,
                RecipeInputId = 1,
            },
            //Bone
            new
            {
                Id = 181,
                RecipeOutputId = 46,
                RecipeInputId = 113,
            },
            new
            {
                Id = 182,
                RecipeOutputId = 46,
                RecipeInputId = 114,
            },
            new
            {
                Id = 183,
                RecipeOutputId = 46,
                RecipeInputId = 18,
            },
            new
            {
                Id = 184,
                RecipeOutputId = 46,
                RecipeInputId = 2,
            },
            //Heavy Bone
            new
            {
                Id = 185,
                RecipeOutputId = 47,
                RecipeInputId = 115,
            },
            new
            {
                Id = 186,
                RecipeOutputId = 47,
                RecipeInputId = 116,
            },
            new
            {
                Id = 187,
                RecipeOutputId = 47,
                RecipeInputId = 20,
            },
            new
            {
                Id = 188,
                RecipeOutputId = 47,
                RecipeInputId = 3,
            },
            //Large Bone
            new
            {
                Id = 189,
                RecipeOutputId = 48,
                RecipeInputId = 117,
            },
            new
            {
                Id = 190,
                RecipeOutputId = 48,
                RecipeInputId = 118,
            },
            new
            {
                Id = 191,
                RecipeOutputId = 48,
                RecipeInputId = 22,
            },
            new
            {
                Id = 192,
                RecipeOutputId = 48,
                RecipeInputId = 4,
            },
            //Ancient Bone
            new
            {
                Id = 193,
                RecipeOutputId = 49,
                RecipeInputId = 119,
            },
            new
            {
                Id = 194,
                RecipeOutputId = 49,
                RecipeInputId = 120,
            },
            new
            {
                Id = 195,
                RecipeOutputId = 49,
                RecipeInputId = 24,
            },
            new
            {
                Id = 196,
                RecipeOutputId = 49,
                RecipeInputId = 5,
            },
            #endregion
            #region Claws
            //Small Claw
            new
            {
                Id = 197,
                RecipeOutputId = 50,
                RecipeInputId = 121,
            },
            new
            {
                Id = 198,
                RecipeOutputId = 50,
                RecipeInputId = 122,
            },
            new
            {
                Id = 199,
                RecipeOutputId = 50,
                RecipeInputId = 16,
            },
            new
            {
                Id = 200,
                RecipeOutputId = 50,
                RecipeInputId = 1,
            },
            //Claw
            new
            {
                Id = 201,
                RecipeOutputId = 51,
                RecipeInputId = 123,
            },
            new
            {
                Id = 202,
                RecipeOutputId = 51,
                RecipeInputId = 124,
            },
            new
            {
                Id = 203,
                RecipeOutputId = 51,
                RecipeInputId = 18,
            },
            new
            {
                Id = 204,
                RecipeOutputId = 51,
                RecipeInputId = 2,
            },
            //Sharp Claw
            new
            {
                Id = 205,
                RecipeOutputId = 52,
                RecipeInputId = 125,
            },
            new
            {
                Id = 206,
                RecipeOutputId = 52,
                RecipeInputId = 126,
            },
            new
            {
                Id = 207,
                RecipeOutputId = 52,
                RecipeInputId = 20,
            },
            new
            {
                Id = 208,
                RecipeOutputId = 52,
                RecipeInputId = 3,
            },
            //Large Claw
            new
            {
                Id = 209,
                RecipeOutputId = 53,
                RecipeInputId = 127,
            },
            new
            {
                Id = 210,
                RecipeOutputId = 53,
                RecipeInputId = 128,
            },
            new
            {
                Id = 211,
                RecipeOutputId = 53,
                RecipeInputId = 22,
            },
            new
            {
                Id = 212,
                RecipeOutputId = 53,
                RecipeInputId = 4,
            },
            //Vicious Claw
            new
            {
                Id = 213,
                RecipeOutputId = 54,
                RecipeInputId = 129,
            },
            new
            {
                Id = 214,
                RecipeOutputId = 54,
                RecipeInputId = 130,
            },
            new
            {
                Id = 215,
                RecipeOutputId = 54,
                RecipeInputId = 24,
            },
            new
            {
                Id = 216,
                RecipeOutputId = 54,
                RecipeInputId = 5,
            },
            #endregion
            #region Dusts
            //Pile of Shimmering Dust
            new
            {
                Id = 217,
                RecipeOutputId = 55,
                RecipeInputId = 131,
            },
            new
            {
                Id = 218,
                RecipeOutputId = 55,
                RecipeInputId = 132,
            },
            new
            {
                Id = 219,
                RecipeOutputId = 55,
                RecipeInputId = 9,
            },
            new
            {
                Id = 220,
                RecipeOutputId = 55,
                RecipeInputId = 1,
            },
            //Pile of Radiant Dust
            new
            {
                Id = 221,
                RecipeOutputId = 56,
                RecipeInputId = 133,
            },
            new
            {
                Id = 222,
                RecipeOutputId = 56,
                RecipeInputId = 17,
            },
            new
            {
                Id = 223,
                RecipeOutputId = 56,
                RecipeInputId = 10,
            },
            new
            {
                Id = 224,
                RecipeOutputId = 56,
                RecipeInputId = 2,
            },
            //Pile of Luminous Dust
            new
            {
                Id = 225,
                RecipeOutputId = 57,
                RecipeInputId = 134,
            },
            new
            {
                Id = 226,
                RecipeOutputId = 57,
                RecipeInputId = 19,
            },
            new
            {
                Id = 227,
                RecipeOutputId = 57,
                RecipeInputId = 11,
            },
            new
            {
                Id = 228,
                RecipeOutputId = 57,
                RecipeInputId = 3,
            },
            //Pile of Incandescent Dust
            new
            {
                Id = 229,
                RecipeOutputId = 58,
                RecipeInputId = 135,
            },
            new
            {
                Id = 230,
                RecipeOutputId = 58,
                RecipeInputId = 21,
            },
            new
            {
                Id = 231,
                RecipeOutputId = 58,
                RecipeInputId = 12,
            },
            new
            {
                Id = 232,
                RecipeOutputId = 58,
                RecipeInputId = 4,
            },
            //Pile of Crystalline
            new
            {
                Id = 233,
                RecipeOutputId = 59,
                RecipeInputId = 136,
            },
            new
            {
                Id = 234,
                RecipeOutputId = 59,
                RecipeInputId = 23,
            },
            new
            {
                Id = 235,
                RecipeOutputId = 59,
                RecipeInputId = 13,
            },
            new
            {
                Id = 236,
                RecipeOutputId = 59,
                RecipeInputId = 5,
            },
            #endregion
            #region Fangs
            //Small Fang
            new
            {
                Id = 237,
                RecipeOutputId = 60,
                RecipeInputId = 137,
            },
            new
            {
                Id = 238,
                RecipeOutputId = 60,
                RecipeInputId = 138,
            },
            new
            {
                Id = 239,
                RecipeOutputId = 60,
                RecipeInputId = 16,
            },
            new
            {
                Id = 240,
                RecipeOutputId = 60,
                RecipeInputId = 1,
            },
            //Fang
            new
            {
                Id = 241,
                RecipeOutputId = 61,
                RecipeInputId = 139,
            },
            new
            {
                Id = 242,
                RecipeOutputId = 61,
                RecipeInputId = 140,
            },
            new
            {
                Id = 243,
                RecipeOutputId = 61,
                RecipeInputId = 18,
            },
            new
            {
                Id = 244,
                RecipeOutputId = 61,
                RecipeInputId = 2,
            },
            //Sharp Fang
            new
            {
                Id = 245,
                RecipeOutputId = 62,
                RecipeInputId = 141,
            },
            new
            {
                Id = 246,
                RecipeOutputId = 62,
                RecipeInputId = 142,
            },
            new
            {
                Id = 247,
                RecipeOutputId = 62,
                RecipeInputId = 20,
            },
            new
            {
                Id = 248,
                RecipeOutputId = 62,
                RecipeInputId = 3,
            },
            //Large Fang
            new
            {
                Id = 249,
                RecipeOutputId = 63,
                RecipeInputId = 143,
            },
            new
            {
                Id = 250,
                RecipeOutputId = 63,
                RecipeInputId = 144,
            },
            new
            {
                Id = 251,
                RecipeOutputId = 63,
                RecipeInputId = 22,
            },
            new
            {
                Id = 252,
                RecipeOutputId = 63,
                RecipeInputId = 4,
            },
            //Vicious Fang
            new
            {
                Id = 253,
                RecipeOutputId = 64,
                RecipeInputId = 145,
            },
            new
            {
                Id = 254,
                RecipeOutputId = 64,
                RecipeInputId = 146,
            },
            new
            {
                Id = 255,
                RecipeOutputId = 64,
                RecipeInputId = 24,
            },
            new
            {
                Id = 256,
                RecipeOutputId = 64,
                RecipeInputId = 5,
            },
            #endregion
            #region Scales
            //Small Scale
            new
            {
                Id = 257,
                RecipeOutputId = 65,
                RecipeInputId = 147,
            },
            new
            {
                Id = 258,
                RecipeOutputId = 65,
                RecipeInputId = 148,
            },
            new
            {
                Id = 259,
                RecipeOutputId = 65,
                RecipeInputId = 16,
            },
            new
            {
                Id = 260,
                RecipeOutputId = 65,
                RecipeInputId = 1,
            },
            //Scale
            new
            {
                Id = 261,
                RecipeOutputId = 66,
                RecipeInputId = 149,
            },
            new
            {
                Id = 262,
                RecipeOutputId = 66,
                RecipeInputId = 150,
            },
            new
            {
                Id = 263,
                RecipeOutputId = 66,
                RecipeInputId = 18,
            },
            new
            {
                Id = 264,
                RecipeOutputId = 66,
                RecipeInputId = 2,
            },
            //Smooth Scale
            new
            {
                Id = 265,
                RecipeOutputId = 67,
                RecipeInputId = 151,
            },
            new
            {
                Id = 266,
                RecipeOutputId = 67,
                RecipeInputId = 152,
            },
            new
            {
                Id = 267,
                RecipeOutputId = 67,
                RecipeInputId = 20,
            },
            new
            {
                Id = 268,
                RecipeOutputId = 67,
                RecipeInputId = 3,
            },
            //Large Scale
            new
            {
                Id = 269,
                RecipeOutputId = 68,
                RecipeInputId = 153,
            },
            new
            {
                Id = 270,
                RecipeOutputId = 68,
                RecipeInputId = 154,
            },
            new
            {
                Id = 271,
                RecipeOutputId = 68,
                RecipeInputId = 22,
            },
            new
            {
                Id = 272,
                RecipeOutputId = 68,
                RecipeInputId = 4,
            },
            //Armored Scale
            new
            {
                Id = 273,
                RecipeOutputId = 69,
                RecipeInputId = 155,
            },
            new
            {
                Id = 274,
                RecipeOutputId = 69,
                RecipeInputId = 156,
            },
            new
            {
                Id = 275,
                RecipeOutputId = 69,
                RecipeInputId = 24,
            },
            new
            {
                Id = 276,
                RecipeOutputId = 69,
                RecipeInputId = 5,
            },
            #endregion
            #region Totems
            //Small Totem
            new
            {
                Id = 277,
                RecipeOutputId = 70,
                RecipeInputId = 157,
            },
            new
            {
                Id = 278,
                RecipeOutputId = 70,
                RecipeInputId = 158,
            },
            new
            {
                Id = 279,
                RecipeOutputId = 70,
                RecipeInputId = 16,
            },
            new
            {
                Id = 280,
                RecipeOutputId = 70,
                RecipeInputId = 1,
            },
            //Totem
            new
            {
                Id = 281,
                RecipeOutputId = 71,
                RecipeInputId = 159,
            },
            new
            {
                Id = 282,
                RecipeOutputId = 71,
                RecipeInputId = 160,
            },
            new
            {
                Id = 283,
                RecipeOutputId = 71,
                RecipeInputId = 18,
            },
            new
            {
                Id = 284,
                RecipeOutputId = 71,
                RecipeInputId = 2,
            },
            //Engraved Totem
            new
            {
                Id = 285,
                RecipeOutputId = 72,
                RecipeInputId = 161,
            },
            new
            {
                Id = 286,
                RecipeOutputId = 72,
                RecipeInputId = 162,
            },
            new
            {
                Id = 287,
                RecipeOutputId = 72,
                RecipeInputId = 20,
            },
            new
            {
                Id = 288,
                RecipeOutputId = 72,
                RecipeInputId = 3,
            },
            //Intricate Totem
            new
            {
                Id = 289,
                RecipeOutputId = 73,
                RecipeInputId = 163,
            },
            new
            {
                Id = 290,
                RecipeOutputId = 73,
                RecipeInputId = 164,
            },
            new
            {
                Id = 291,
                RecipeOutputId = 73,
                RecipeInputId = 22,
            },
            new
            {
                Id = 292,
                RecipeOutputId = 73,
                RecipeInputId = 4,
            },
            //Elaborate Totem
            new
            {
                Id = 293,
                RecipeOutputId = 74,
                RecipeInputId = 165,
            },
            new
            {
                Id = 294,
                RecipeOutputId = 74,
                RecipeInputId = 166,
            },
            new
            {
                Id = 295,
                RecipeOutputId = 74,
                RecipeInputId = 24,
            },
            new
            {
                Id = 296,
                RecipeOutputId = 74,
                RecipeInputId = 5,
            },
            #endregion
            #region Venoms
            //Small Venom Sac
            new
            {
                Id = 297,
                RecipeOutputId = 75,
                RecipeInputId = 167,
            },
            new
            {
                Id = 298,
                RecipeOutputId = 75,
                RecipeInputId = 168,
            },
            new
            {
                Id = 299,
                RecipeOutputId = 75,
                RecipeInputId = 16,
            },
            new
            {
                Id = 300,
                RecipeOutputId = 75,
                RecipeInputId = 1,
            },
            //Venom Sac
            new
            {
                Id = 301,
                RecipeOutputId = 76,
                RecipeInputId = 169,
            },
            new
            {
                Id = 302,
                RecipeOutputId = 76,
                RecipeInputId = 170,
            },
            new
            {
                Id = 303,
                RecipeOutputId = 76,
                RecipeInputId = 18,
            },
            new
            {
                Id = 304,
                RecipeOutputId = 76,
                RecipeInputId = 2,
            },
            //Full Venom Sac
            new
            {
                Id = 305,
                RecipeOutputId = 77,
                RecipeInputId = 171,
            },
            new
            {
                Id = 306,
                RecipeOutputId = 77,
                RecipeInputId = 172,
            },
            new
            {
                Id = 307,
                RecipeOutputId = 77,
                RecipeInputId = 20,
            },
            new
            {
                Id = 308,
                RecipeOutputId = 77,
                RecipeInputId = 3,
            },
            //Potent Venom Sac
            new
            {
                Id = 309,
                RecipeOutputId = 78,
                RecipeInputId = 173,
            },
            new
            {
                Id = 310,
                RecipeOutputId = 78,
                RecipeInputId = 174,
            },
            new
            {
                Id = 311,
                RecipeOutputId = 78,
                RecipeInputId = 22,
            },
            new
            {
                Id = 312,
                RecipeOutputId = 78,
                RecipeInputId = 4,
            },
            //Powerful Venom Sac
            new
            {
                Id = 313,
                RecipeOutputId = 79,
                RecipeInputId = 175,
            },
            new
            {
                Id = 314,
                RecipeOutputId = 79,
                RecipeInputId = 176,
            },
            new
            {
                Id = 315,
                RecipeOutputId = 79,
                RecipeInputId = 24,
            },
            new
            {
                Id = 316,
                RecipeOutputId = 79,
                RecipeInputId = 5,
            },
            #endregion
            #region Bloods
            //Vial of Thin Blood
            new
            {
                Id = 317,
                RecipeOutputId = 80,
                RecipeInputId = 177,
            },
            new
            {
                Id = 318,
                RecipeOutputId = 80,
                RecipeInputId = 178,
            },
            new
            {
                Id = 319,
                RecipeOutputId = 80,
                RecipeInputId = 16,
            },
            new
            {
                Id = 320,
                RecipeOutputId = 80,
                RecipeInputId = 1,
            },
            //Vial of Blood
            new
            {
                Id = 321,
                RecipeOutputId = 81,
                RecipeInputId = 179,
            },
            new
            {
                Id = 322,
                RecipeOutputId = 81,
                RecipeInputId = 180,
            },
            new
            {
                Id = 323,
                RecipeOutputId = 81,
                RecipeInputId = 18,
            },
            new
            {
                Id = 324,
                RecipeOutputId = 81,
                RecipeInputId = 2,
            },
            //Vial of Thick Blood
            new
            {
                Id = 325,
                RecipeOutputId = 82,
                RecipeInputId = 181,
            },
            new
            {
                Id = 326,
                RecipeOutputId = 82,
                RecipeInputId = 182,
            },
            new
            {
                Id = 327,
                RecipeOutputId = 82,
                RecipeInputId = 20,
            },
            new
            {
                Id = 328,
                RecipeOutputId = 82,
                RecipeInputId = 3,
            },
            //Vial of Potent Blood
            new
            {
                Id = 329,
                RecipeOutputId = 83,
                RecipeInputId = 183,
            },
            new
            {
                Id = 330,
                RecipeOutputId = 83,
                RecipeInputId = 184,
            },
            new
            {
                Id = 331,
                RecipeOutputId = 83,
                RecipeInputId = 22,
            },
            new
            {
                Id = 332,
                RecipeOutputId = 83,
                RecipeInputId = 4,
            },
            //Vial of Powerful Blood
            new
            {
                Id = 333,
                RecipeOutputId = 84,
                RecipeInputId = 185,
            },
            new
            {
                Id = 334,
                RecipeOutputId = 84,
                RecipeInputId = 186,
            },
            new
            {
                Id = 335,
                RecipeOutputId = 84,
                RecipeInputId = 24,
            },
            new
            {
                Id = 336,
                RecipeOutputId = 84,
                RecipeInputId = 5,
            },
            #endregion
            #endregion
            #region Rare Items
            #region Charged
            //Charged Fragment
            new
            {
                Id = 337,
                RecipeOutputId = 85,
                RecipeInputId = 187,
            },
            new
            {
                Id = 338,
                RecipeOutputId = 85,
                RecipeInputId = 14,
            },
            new
            {
                Id = 339,
                RecipeOutputId = 85,
                RecipeInputId = 17,
            },
            new
            {
                Id = 340,
                RecipeOutputId = 85,
                RecipeInputId = 9,
            },
            //Charged Fragment with Mystic Binding
            new
            {
                Id = 341,
                RecipeOutputId = 86,
                RecipeInputId = 188,
            },
            new
            {
                Id = 342,
                RecipeOutputId = 86,
                RecipeInputId = 15,
            },
            new
            {
                Id = 343,
                RecipeOutputId = 86,
                RecipeInputId = 17,
            },
            new
            {
                Id = 344,
                RecipeOutputId = 86,
                RecipeInputId = 9,
            },
            //Charged Shard
            new
            {
                Id = 345,
                RecipeOutputId = 87,
                RecipeInputId = 189,
            },
            new
            {
                Id = 346,
                RecipeOutputId = 87,
                RecipeInputId = 14,
            },
            new
            {
                Id = 347,
                RecipeOutputId = 87,
                RecipeInputId = 19,
            },
            new
            {
                Id = 348,
                RecipeOutputId = 87,
                RecipeInputId = 9,
            },
            //Charged Shard with Mystic Binding
            new
            {
                Id = 349,
                RecipeOutputId = 88,
                RecipeInputId = 190,
            },
            new
            {
                Id = 350,
                RecipeOutputId = 88,
                RecipeInputId = 15,
            },
            new
            {
                Id = 351,
                RecipeOutputId = 88,
                RecipeInputId = 19,
            },
            new
            {
                Id = 352,
                RecipeOutputId = 88,
                RecipeInputId = 9,
            },
            //Charged Core
            new
            {
                Id = 353,
                RecipeOutputId = 89,
                RecipeInputId = 191,
            },
            new
            {
                Id = 354,
                RecipeOutputId = 89,
                RecipeInputId = 14,
            },
            new
            {
                Id = 355,
                RecipeOutputId = 89,
                RecipeInputId = 21,
            },
            new
            {
                Id = 356,
                RecipeOutputId = 89,
                RecipeInputId = 9,
            },
            //Charged Core with Mystic Binding
            new
            {
                Id = 357,
                RecipeOutputId = 90,
                RecipeInputId = 192,
            },
            new
            {
                Id = 358,
                RecipeOutputId = 90,
                RecipeInputId = 15,
            },
            new
            {
                Id = 359,
                RecipeOutputId = 90,
                RecipeInputId = 21,
            },
            new
            {
                Id = 360,
                RecipeOutputId = 90,
                RecipeInputId = 9,
            },
            //Charged Loadstone
            new
            {
                Id = 361,
                RecipeOutputId = 91,
                RecipeInputId = 193,
            },
            new
            {
                Id = 362,
                RecipeOutputId = 91,
                RecipeInputId = 14,
            },
            new
            {
                Id = 363,
                RecipeOutputId = 91,
                RecipeInputId = 23,
            },
            new
            {
                Id = 364,
                RecipeOutputId = 91,
                RecipeInputId = 9,
            },
            //Charged Loadstone with Mystic Binding
            new
            {
                Id = 365,
                RecipeOutputId = 92,
                RecipeInputId = 193,
            },
            new
            {
                Id = 366,
                RecipeOutputId = 92,
                RecipeInputId = 15,
            },
            new
            {
                Id = 367,
                RecipeOutputId = 92,
                RecipeInputId = 23,
            },
            new
            {
                Id = 368,
                RecipeOutputId = 92,
                RecipeInputId = 9,
            },
            #endregion
            #region Corrupted
            //Corrupted Fragment
            new
            {
                Id = 369,
                RecipeOutputId = 93,
                RecipeInputId = 194,
            },
            new
            {
                Id = 370,
                RecipeOutputId = 93,
                RecipeInputId = 14,
            },
            new
            {
                Id = 371,
                RecipeOutputId = 93,
                RecipeInputId = 17,
            },
            new
            {
                Id = 372,
                RecipeOutputId = 93,
                RecipeInputId = 9,
            },
            //Corrupted Fragment with Mystic Binding
            new
            {
                Id = 373,
                RecipeOutputId = 94,
                RecipeInputId = 195,
            },
            new
            {
                Id = 374,
                RecipeOutputId = 94,
                RecipeInputId = 15,
            },
            new
            {
                Id = 375,
                RecipeOutputId = 94,
                RecipeInputId = 17,
            },
            new
            {
                Id = 376,
                RecipeOutputId = 94,
                RecipeInputId = 9,
            },
            //Corrupted Shard
            new
            {
                Id = 377,
                RecipeOutputId = 95,
                RecipeInputId = 196,
            },
            new
            {
                Id = 378,
                RecipeOutputId = 95,
                RecipeInputId = 14,
            },
            new
            {
                Id = 379,
                RecipeOutputId = 95,
                RecipeInputId = 19,
            },
            new
            {
                Id = 380,
                RecipeOutputId = 95,
                RecipeInputId = 9,
            },
            //Corrupted Shard with Mystic Binding
            new
            {
                Id = 381,
                RecipeOutputId = 96,
                RecipeInputId = 197,
            },
            new
            {
                Id = 382,
                RecipeOutputId = 96,
                RecipeInputId = 15,
            },
            new
            {
                Id = 383,
                RecipeOutputId = 96,
                RecipeInputId = 19,
            },
            new
            {
                Id = 384,
                RecipeOutputId = 96,
                RecipeInputId = 9,
            },
            //Corrupted Core
            new
            {
                Id = 385,
                RecipeOutputId = 97,
                RecipeInputId = 198,
            },
            new
            {
                Id = 386,
                RecipeOutputId = 97,
                RecipeInputId = 14,
            },
            new
            {
                Id = 387,
                RecipeOutputId = 97,
                RecipeInputId = 21,
            },
            new
            {
                Id = 388,
                RecipeOutputId = 97,
                RecipeInputId = 9,
            },
            //Corrupted Core with Mystic Binding
            new
            {
                Id = 389,
                RecipeOutputId = 98,
                RecipeInputId = 199,
            },
            new
            {
                Id = 390,
                RecipeOutputId = 98,
                RecipeInputId = 15,
            },
            new
            {
                Id = 391,
                RecipeOutputId = 98,
                RecipeInputId = 21,
            },
            new
            {
                Id = 392,
                RecipeOutputId = 98,
                RecipeInputId = 9,
            },
            //Corrupted Loadstone
            new
            {
                Id = 393,
                RecipeOutputId = 99,
                RecipeInputId = 200,
            },
            new
            {
                Id = 394,
                RecipeOutputId = 99,
                RecipeInputId = 14,
            },
            new
            {
                Id = 395,
                RecipeOutputId = 99,
                RecipeInputId = 23,
            },
            new
            {
                Id = 396,
                RecipeOutputId = 99,
                RecipeInputId = 9,
            },
            //Corrupted Loadstone with Mystic Binding
            new
            {
                Id = 397,
                RecipeOutputId = 100,
                RecipeInputId = 200,
            },
            new
            {
                Id = 398,
                RecipeOutputId = 100,
                RecipeInputId = 15,
            },
            new
            {
                Id = 399,
                RecipeOutputId = 100,
                RecipeInputId = 23,
            },
            new
            {
                Id = 400,
                RecipeOutputId = 100,
                RecipeInputId = 9,
            },
            #endregion
            #region Crystal
            //Crystal Fragment
            new
            {
                Id = 401,
                RecipeOutputId = 101,
                RecipeInputId = 201,
            },
            new
            {
                Id = 402,
                RecipeOutputId = 101,
                RecipeInputId = 14,
            },
            new
            {
                Id = 403,
                RecipeOutputId = 101,
                RecipeInputId = 17,
            },
            new
            {
                Id = 404,
                RecipeOutputId = 101,
                RecipeInputId = 9,
            },
            //Crystal Fragment with Mystic Binding
            new
            {
                Id = 405,
                RecipeOutputId = 102,
                RecipeInputId = 202,
            },
            new
            {
                Id = 406,
                RecipeOutputId = 102,
                RecipeInputId = 15,
            },
            new
            {
                Id = 407,
                RecipeOutputId = 102,
                RecipeInputId = 17,
            },
            new
            {
                Id = 408,
                RecipeOutputId = 102,
                RecipeInputId = 9,
            },
            //Crystal Shard
            new
            {
                Id = 409,
                RecipeOutputId = 103,
                RecipeInputId = 203,
            },
            new
            {
                Id = 410,
                RecipeOutputId = 103,
                RecipeInputId = 14,
            },
            new
            {
                Id = 411,
                RecipeOutputId = 103,
                RecipeInputId = 19,
            },
            new
            {
                Id = 412,
                RecipeOutputId = 103,
                RecipeInputId = 9,
            },
            //Crystal Shard with Mystic Binding
            new
            {
                Id = 413,
                RecipeOutputId = 104,
                RecipeInputId = 204,
            },
            new
            {
                Id = 414,
                RecipeOutputId = 104,
                RecipeInputId = 15,
            },
            new
            {
                Id = 415,
                RecipeOutputId = 104,
                RecipeInputId = 19,
            },
            new
            {
                Id = 416,
                RecipeOutputId = 104,
                RecipeInputId = 9,
            },
            //Crystal Core
            new
            {
                Id = 417,
                RecipeOutputId = 105,
                RecipeInputId = 205,
            },
            new
            {
                Id = 418,
                RecipeOutputId = 105,
                RecipeInputId = 14,
            },
            new
            {
                Id = 419,
                RecipeOutputId = 105,
                RecipeInputId = 21,
            },
            new
            {
                Id = 420,
                RecipeOutputId = 105,
                RecipeInputId = 9,
            },
            //Crystal Core with Mystic Binding
            new
            {
                Id = 421,
                RecipeOutputId = 106,
                RecipeInputId = 206,
            },
            new
            {
                Id = 422,
                RecipeOutputId = 106,
                RecipeInputId = 15,
            },
            new
            {
                Id = 423,
                RecipeOutputId = 106,
                RecipeInputId = 21,
            },
            new
            {
                Id = 424,
                RecipeOutputId = 106,
                RecipeInputId = 9,
            },
            //Crystal Loadstone
            new
            {
                Id = 425,
                RecipeOutputId = 107,
                RecipeInputId = 207,
            },
            new
            {
                Id = 426,
                RecipeOutputId = 107,
                RecipeInputId = 14,
            },
            new
            {
                Id = 427,
                RecipeOutputId = 107,
                RecipeInputId = 23,
            },
            new
            {
                Id = 428,
                RecipeOutputId = 107,
                RecipeInputId = 9,
            },
            //Crystal Loadstone with Mystic Binding
            new
            {
                Id = 429,
                RecipeOutputId = 108,
                RecipeInputId = 207,
            },
            new
            {
                Id = 430,
                RecipeOutputId = 108,
                RecipeInputId = 15,
            },
            new
            {
                Id = 431,
                RecipeOutputId = 108,
                RecipeInputId = 23,
            },
            new
            {
                Id = 432,
                 RecipeOutputId = 108,
                RecipeInputId = 9,
            },
            #endregion
            #region Destroyer
            //Destroyer Fragment
            new
            {
                Id = 433,
                RecipeOutputId = 109,
                RecipeInputId = 208,
            },
            new
            {
                Id = 434,
                RecipeOutputId = 109,
                RecipeInputId = 14,
            },
            new
            {
                Id = 435,
                RecipeOutputId = 109,
                RecipeInputId = 17,
            },
            new
            {
                Id = 436,
                RecipeOutputId = 109,
                RecipeInputId = 9,
            },
            //Destroyer Fragment with Mystic Binding
            new
            {
                Id = 437,
                RecipeOutputId = 110,
                RecipeInputId = 209,
            },
            new
            {
                Id = 438,
                RecipeOutputId = 110,
                RecipeInputId = 15,
            },
            new
            {
                Id = 439,
                RecipeOutputId = 110,
                RecipeInputId = 17,
            },
            new
            {
                Id = 440,
                RecipeOutputId = 110,
                RecipeInputId = 9,
            },
            //Destroyer Shard
            new
            {
                Id = 441,
                RecipeOutputId = 111,
                RecipeInputId = 210,
            },
            new
            {
                Id = 442,
                RecipeOutputId = 111,
                RecipeInputId = 14,
            },
            new
            {
                Id = 443,
                RecipeOutputId = 111,
                RecipeInputId = 19,
            },
            new
            {
                Id = 444,
                RecipeOutputId = 111,
                RecipeInputId = 9,
            },
            //Destroyer Shard with Mystic Binding
            new
            {
                Id = 445,
                RecipeOutputId = 112,
                RecipeInputId = 211,
            },
            new
            {
                Id = 446,
                RecipeOutputId = 112,
                RecipeInputId = 15,
            },
            new
            {
                Id = 447,
                RecipeOutputId = 112,
                RecipeInputId = 19,
            },
            new
            {
                Id = 448,
                RecipeOutputId = 112,
                RecipeInputId = 9,
            },
            //Destroyer Core
            new
            {
                Id = 449,
                RecipeOutputId = 113,
                RecipeInputId = 212,
            },
            new
            {
                Id = 450,
                RecipeOutputId = 113,
                RecipeInputId = 14,
            },
            new
            {
                Id = 451,
                RecipeOutputId = 113,
                RecipeInputId = 21,
            },
            new
            {
                Id = 452,
                RecipeOutputId = 113,
                RecipeInputId = 9,
            },
            //Destroyer Core with Mystic Binding
            new
            {
                Id = 453,
                RecipeOutputId = 114,
                RecipeInputId = 213,
            },
            new
            {
                Id = 454,
                RecipeOutputId = 114,
                RecipeInputId = 15,
            },
            new
            {
                Id = 455,
                RecipeOutputId = 114,
                RecipeInputId = 21,
            },
            new
            {
                Id = 456,
                RecipeOutputId = 114,
                RecipeInputId = 9,
            },
            //Destroyer Loadstone
            new
            {
                Id = 457,
                RecipeOutputId = 115,
                RecipeInputId = 214,
            },
            new
            {
                Id = 458,
                RecipeOutputId = 115,
                RecipeInputId = 14,
            },
            new
            {
                Id = 459,
                RecipeOutputId = 115,
                RecipeInputId = 23,
            },
            new
            {
                Id = 460,
                RecipeOutputId = 115,
                RecipeInputId = 9,
            },
            //Destroyer Loadstone with Mystic Binding
            new
            {
                Id = 461,
                RecipeOutputId = 116,
                RecipeInputId = 214,
            },
            new
            {
                Id = 462,
                RecipeOutputId = 116,
                RecipeInputId = 15,
            },
            new
            {
                Id = 463,
                RecipeOutputId = 116,
                RecipeInputId = 23,
            },
            new
            {
                Id = 464,
                 RecipeOutputId = 116,
                RecipeInputId = 9,
            },
            #endregion
            #region Essence
            //Pile of Foul
            new
            {
                Id = 465,
                RecipeOutputId = 117,
                RecipeInputId = 215,
            },
            new
            {
                Id = 466,
                RecipeOutputId = 117,
                RecipeInputId = 14,
            },
            new
            {
                Id = 467,
                RecipeOutputId = 117,
                RecipeInputId = 17,
            },
            new
            {
                Id = 468,
                RecipeOutputId = 117,
                RecipeInputId = 9,
            },
            //Pile of Foul with Mystic Binding
            new
            {
                Id = 469,
                RecipeOutputId = 118,
                RecipeInputId = 216,
            },
            new
            {
                Id = 470,
                RecipeOutputId = 118,
                RecipeInputId = 15,
            },
            new
            {
                Id = 471,
                RecipeOutputId = 118,
                RecipeInputId = 17,
            },
            new
            {
                Id = 472,
                RecipeOutputId = 118,
                RecipeInputId = 9,
            },
            //Pile of Filthy
            new
            {
                Id = 473,
                RecipeOutputId = 119,
                RecipeInputId = 217,
            },
            new
            {
                Id = 474,
                RecipeOutputId = 119,
                RecipeInputId = 14,
            },
            new
            {
                Id = 475,
                RecipeOutputId = 119,
                RecipeInputId = 19,
            },
            new
            {
                Id = 476,
                RecipeOutputId = 119,
                RecipeInputId = 9,
            },
            //Pile of Filthy with Mystic Binding
            new
            {
                Id = 477,
                RecipeOutputId = 120,
                RecipeInputId = 218,
            },
            new
            {
                Id = 478,
                RecipeOutputId = 120,
                RecipeInputId = 15,
            },
            new
            {
                Id = 479,
                RecipeOutputId = 120,
                RecipeInputId = 19,
            },
            new
            {
                Id = 480,
                RecipeOutputId = 120,
                RecipeInputId = 9,
            },
            //Pile of Vile
            new
            {
                Id = 481,
                RecipeOutputId = 121,
                RecipeInputId = 219,
            },
            new
            {
                Id = 482,
                RecipeOutputId = 121,
                RecipeInputId = 14,
            },
            new
            {
                Id = 483,
                RecipeOutputId = 121,
                RecipeInputId = 21,
            },
            new
            {
                Id = 484,
                RecipeOutputId = 121,
                RecipeInputId = 9,
            },
            //Pile of Vile with Mystic Binding
            new
            {
                Id = 485,
                RecipeOutputId = 122,
                RecipeInputId = 220,
            },
            new
            {
                Id = 486,
                RecipeOutputId = 122,
                RecipeInputId = 15,
            },
            new
            {
                Id = 487,
                RecipeOutputId = 122,
                RecipeInputId = 21,
            },
            new
            {
                Id = 488,
                RecipeOutputId = 122,
                RecipeInputId = 9,
            },
            //Pile of Putrid Loadstone
            new
            {
                Id = 489,
                RecipeOutputId = 123,
                RecipeInputId = 221,
            },
            new
            {
                Id = 490,
                RecipeOutputId = 123,
                RecipeInputId = 14,
            },
            new
            {
                Id = 491,
                RecipeOutputId = 123,
                RecipeInputId = 23,
            },
            new
            {
                Id = 492,
                RecipeOutputId = 123,
                RecipeInputId = 9,
            },
            //Pile of Putrid with Mystic Binding
            new
            {
                Id = 493,
                RecipeOutputId = 124,
                RecipeInputId = 221,
            },
            new
            {
                Id = 494,
                RecipeOutputId = 124,
                RecipeInputId = 15,
            },
            new
            {
                Id = 495,
                RecipeOutputId = 124,
                RecipeInputId = 23,
            },
            new
            {
                Id = 496,
                 RecipeOutputId = 124,
                RecipeInputId = 9,
            },
            #endregion
            #region Glacial
            //Glacial Fragment
            new
            {
                Id = 497,
                RecipeOutputId = 125,
                RecipeInputId = 222,
            },
            new
            {
                Id = 498,
                RecipeOutputId = 125,
                RecipeInputId = 14,
            },
            new
            {
                Id = 499,
                RecipeOutputId = 125,
                RecipeInputId = 17,
            },
            new
            {
                Id = 500,
                RecipeOutputId = 125,
                RecipeInputId = 9,
            },
            //Glacial Fragment with Mystic Binding
            new
            {
                Id = 501,
                RecipeOutputId = 126,
                RecipeInputId = 223,
            },
            new
            {
                Id = 502,
                RecipeOutputId = 126,
                RecipeInputId = 15,
            },
            new
            {
                Id = 503,
                RecipeOutputId = 126,
                RecipeInputId = 17,
            },
            new
            {
                Id = 504,
                RecipeOutputId = 126,
                RecipeInputId = 9,
            },
            //Glacial Shard
            new
            {
                Id = 505,
                RecipeOutputId = 127,
                RecipeInputId = 224,
            },
            new
            {
                Id = 506,
                RecipeOutputId = 127,
                RecipeInputId = 14,
            },
            new
            {
                Id = 507,
                RecipeOutputId = 127,
                RecipeInputId = 19,
            },
            new
            {
                Id = 508,
                RecipeOutputId = 127,
                RecipeInputId = 9,
            },
            //Glacial Shard with Mystic Binding
            new
            {
                Id = 509,
                RecipeOutputId = 128,
                RecipeInputId = 225,
            },
            new
            {
                Id = 510,
                RecipeOutputId = 128,
                RecipeInputId = 15,
            },
            new
            {
                Id = 511,
                RecipeOutputId = 128,
                RecipeInputId = 19,
            },
            new
            {
                Id = 512,
                RecipeOutputId = 128,
                RecipeInputId = 9,
            },
            //Glacial Core
            new
            {
                Id = 513,
                RecipeOutputId = 129,
                RecipeInputId = 226,
            },
            new
            {
                Id = 514,
                RecipeOutputId = 129,
                RecipeInputId = 14,
            },
            new
            {
                Id = 515,
                RecipeOutputId = 129,
                RecipeInputId = 21,
            },
            new
            {
                Id = 516,
                RecipeOutputId = 129,
                RecipeInputId = 9,
            },
            //Glacial Core with Mystic Binding
            new
            {
                Id = 517,
                RecipeOutputId = 130,
                RecipeInputId = 227,
            },
            new
            {
                Id = 518,
                RecipeOutputId = 130,
                RecipeInputId = 15,
            },
            new
            {
                Id = 519,
                RecipeOutputId = 130,
                RecipeInputId = 21,
            },
            new
            {
                Id = 520,
                RecipeOutputId = 130,
                RecipeInputId = 9,
            },
            //Glacial Loadstone
            new
            {
                Id = 521,
                RecipeOutputId = 131,
                RecipeInputId = 228,
            },
            new
            {
                Id = 522,
                RecipeOutputId = 131,
                RecipeInputId = 14,
            },
            new
            {
                Id = 523,
                RecipeOutputId = 131,
                RecipeInputId = 23,
            },
            new
            {
                Id = 524,
                RecipeOutputId = 131,
                RecipeInputId = 9,
            },
            //Glacial Loadstone with Mystic Binding
            new
            {
                Id = 525,
                RecipeOutputId = 132,
                RecipeInputId = 228,
            },
            new
            {
                Id = 526,
                RecipeOutputId = 132,
                RecipeInputId = 15,
            },
            new
            {
                Id = 527,
                RecipeOutputId = 132,
                RecipeInputId = 23,
            },
            new
            {
                Id = 528,
                 RecipeOutputId = 132,
                RecipeInputId = 9,
            },
            #endregion
            #region Molten
            //Molten Fragment
            new
            {
                Id = 529,
                RecipeOutputId = 133,
                RecipeInputId = 229,
            },
            new
            {
                Id = 530,
                RecipeOutputId = 133,
                RecipeInputId = 14,
            },
            new
            {
                Id = 531,
                RecipeOutputId = 133,
                RecipeInputId = 17,
            },
            new
            {
                Id = 532,
                RecipeOutputId = 133,
                RecipeInputId = 9,
            },
            //Molten Fragment with Mystic Binding
            new
            {
                Id = 533,
                RecipeOutputId = 134,
                RecipeInputId = 230,
            },
            new
            {
                Id = 534,
                RecipeOutputId = 134,
                RecipeInputId = 15,
            },
            new
            {
                Id = 535,
                RecipeOutputId = 134,
                RecipeInputId = 17,
            },
            new
            {
                Id = 536,
                RecipeOutputId = 134,
                RecipeInputId = 9,
            },
            //Molten Shard
            new
            {
                Id = 537,
                RecipeOutputId = 135,
                RecipeInputId = 231,
            },
            new
            {
                Id = 538,
                RecipeOutputId = 135,
                RecipeInputId = 14,
            },
            new
            {
                Id = 539,
                RecipeOutputId = 135,
                RecipeInputId = 19,
            },
            new
            {
                Id = 540,
                RecipeOutputId = 135,
                RecipeInputId = 9,
            },
            //Molten Shard with Mystic Binding
            new
            {
                Id = 541,
                RecipeOutputId = 136,
                RecipeInputId = 232,
            },
            new
            {
                Id = 542,
                RecipeOutputId = 136,
                RecipeInputId = 15,
            },
            new
            {
                Id = 543,
                RecipeOutputId = 136,
                RecipeInputId = 19,
            },
            new
            {
                Id = 544,
                RecipeOutputId = 136,
                RecipeInputId = 9,
            },
            //Molten Core
            new
            {
                Id = 545,
                RecipeOutputId = 137,
                RecipeInputId = 233,
            },
            new
            {
                Id = 546,
                RecipeOutputId = 137,
                RecipeInputId = 14,
            },
            new
            {
                Id = 547,
                RecipeOutputId = 137,
                RecipeInputId = 21,
            },
            new
            {
                Id = 548,
                RecipeOutputId = 137,
                RecipeInputId = 9,
            },
            //Molten Core with Mystic Binding
            new
            {
                Id = 549,
                RecipeOutputId = 138,
                RecipeInputId = 234,
            },
            new
            {
                Id = 550,
                RecipeOutputId = 138,
                RecipeInputId = 15,
            },
            new
            {
                Id = 551,
                RecipeOutputId = 138,
                RecipeInputId = 21,
            },
            new
            {
                Id = 552,
                RecipeOutputId = 138,
                RecipeInputId = 9,
            },
            //Molten Loadstone
            new
            {
                Id = 553,
                RecipeOutputId = 139,
                RecipeInputId = 235,
            },
            new
            {
                Id = 554,
                RecipeOutputId = 139,
                RecipeInputId = 14,
            },
            new
            {
                Id = 555,
                RecipeOutputId = 139,
                RecipeInputId = 23,
            },
            new
            {
                Id = 556,
                RecipeOutputId = 139,
                RecipeInputId = 9,
            },
            //Molten Loadstone with Mystic Binding
            new
            {
                Id = 557,
                RecipeOutputId = 140,
                RecipeInputId = 235,
            },
            new
            {
                Id = 558,
                RecipeOutputId = 140,
                RecipeInputId = 15,
            },
            new
            {
                Id = 559,
                RecipeOutputId = 140,
                RecipeInputId = 23,
            },
            new
            {
                Id = 560,
                 RecipeOutputId = 140,
                RecipeInputId = 9,
            },
            #endregion
            #region Onyx
            //Onyx Fragment
            new
            {
                Id = 561,
                RecipeOutputId = 141,
                RecipeInputId = 236,
            },
            new
            {
                Id = 562,
                RecipeOutputId = 141,
                RecipeInputId = 14,
            },
            new
            {
                Id = 563,
                RecipeOutputId = 141,
                RecipeInputId = 17,
            },
            new
            {
                Id = 564,
                RecipeOutputId = 141,
                RecipeInputId = 9,
            },
            //Onyx Fragment with Mystic Binding
            new
            {
                Id = 565,
                RecipeOutputId = 142,
                RecipeInputId = 237,
            },
            new
            {
                Id = 566,
                RecipeOutputId = 142,
                RecipeInputId = 15,
            },
            new
            {
                Id = 567,
                RecipeOutputId = 142,
                RecipeInputId = 17,
            },
            new
            {
                Id = 568,
                RecipeOutputId = 142,
                RecipeInputId = 9,
            },
            //Onyx Shard
            new
            {
                Id = 569,
                RecipeOutputId = 143,
                RecipeInputId = 238,
            },
            new
            {
                Id = 570,
                RecipeOutputId = 143,
                RecipeInputId = 14,
            },
            new
            {
                Id = 571,
                RecipeOutputId = 143,
                RecipeInputId = 19,
            },
            new
            {
                Id = 572,
                RecipeOutputId = 143,
                RecipeInputId = 9,
            },
            //Onyx Shard with Mystic Binding
            new
            {
                Id = 573,
                RecipeOutputId = 144,
                RecipeInputId = 239,
            },
            new
            {
                Id = 574,
                RecipeOutputId = 144,
                RecipeInputId = 15,
            },
            new
            {
                Id = 575,
                RecipeOutputId = 144,
                RecipeInputId = 19,
            },
            new
            {
                Id = 576,
                RecipeOutputId = 144,
                RecipeInputId = 9,
            },
            //Onyx Core
            new
            {
                Id = 577,
                RecipeOutputId = 145,
                RecipeInputId = 240,
            },
            new
            {
                Id = 578,
                RecipeOutputId = 145,
                RecipeInputId = 14,
            },
            new
            {
                Id = 579,
                RecipeOutputId = 145,
                RecipeInputId = 21,
            },
            new
            {
                Id = 580,
                RecipeOutputId = 145,
                RecipeInputId = 9,
            },
            //Onyx Core with Mystic Binding
            new
            {
                Id = 581,
                RecipeOutputId = 146,
                RecipeInputId = 241,
            },
            new
            {
                Id = 582,
                RecipeOutputId = 146,
                RecipeInputId = 15,
            },
            new
            {
                Id = 583,
                RecipeOutputId = 146,
                RecipeInputId = 21,
            },
            new
            {
                Id = 584,
                RecipeOutputId = 146,
                RecipeInputId = 9,
            },
            //Onyx Loadstone
            new
            {
                Id = 585,
                RecipeOutputId = 147,
                RecipeInputId = 242,
            },
            new
            {
                Id = 586,
                RecipeOutputId = 147,
                RecipeInputId = 14,
            },
            new
            {
                Id = 587,
                RecipeOutputId = 147,
                RecipeInputId = 23,
            },
            new
            {
                Id = 588,
                RecipeOutputId = 147,
                RecipeInputId = 9,
            },
            //Onyx Loadstone with Mystic Binding
            new
            {
                Id = 589,
                RecipeOutputId = 148,
                RecipeInputId = 242,
            },
            new
            {
                Id = 590,
                RecipeOutputId = 148,
                RecipeInputId = 15,
            },
            new
            {
                Id = 591,
                RecipeOutputId = 148,
                RecipeInputId = 23,
            },
            new
            {
                Id = 592,
                 RecipeOutputId = 148,
                RecipeInputId = 9,
            },
            #endregion
            #endregion
        ];
    }
}
