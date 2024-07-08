using GW2CraftCalculator.Models.Data;

namespace GW2CraftCalculator.Data.DataSeeding;

public class MysticForgeRecipeInputs
{
    internal static IEnumerable<object> Get()
    {
        return
        [
            #region Vendor Items
            #region Philosopher's Stones
            new
            {
                Id = 1,
                ItemId = 20796,
                InputAmountId = 1,
            },
            new
            {
                Id = 2,
                ItemId = 20796,
                InputAmountId = 2,
            },
            new
            {
                Id = 3,
                ItemId = 20796,
                InputAmountId = 3,
            },
            new
            {
                Id = 4,
                ItemId = 20796,
                InputAmountId = 4,
            },
            new
            {
                Id = 5,
                ItemId = 20796,
                InputAmountId = 5,
            },
            new
            {
                Id = 6,
                ItemId = 20796,
                InputAmountId = 6,
            },
            new
            {
                Id = 7,
                ItemId = 20796,
                InputAmountId = 7,
            },
            new
            {
                Id = 8,
                ItemId = 20796,
                InputAmountId = 8,
            },
            #endregion
            #region Mystic Crystal
            new
            {
                Id = 9,
                ItemId = 20799,
                InputAmountId = 1,
            },
            new
            {
                Id = 10,
                ItemId = 20799,
                InputAmountId = 2,
            },
            new
            {
                Id = 11,
                ItemId = 20799,
                InputAmountId = 3,
            },
            new
            {
                Id = 12,
                ItemId = 20799,
                InputAmountId = 4,
            },
            new
            {
                Id = 13,
                ItemId = 20799,
                InputAmountId = 5,
            },
            #endregion
            #region Elonian Wine
            new
            {
                Id = 14,
                ItemId = 19663,
                InputAmountId = 1,
            },
            #endregion
            #region Mystic Binding
            new
            {
                Id = 15,
                ItemId = 39125,
                InputAmountId = 1,
            },
            #endregion
            #endregion
            #region Dust as Promotion Item
            //T2
            new
            {
                Id = 16,
                ItemId = 24273,
                InputAmountId = 5,
            },
            //T3
            new
            {
                Id = 17,
                ItemId = 24274,
                InputAmountId = 1,
            },
            new
            {
                Id = 18,
                ItemId = 24274,
                InputAmountId = 5,
            },
            //T4
            new
            {
                Id = 19,
                ItemId = 24275,
                InputAmountId = 1,
            },
            new
            {
                Id = 20,
                ItemId = 24275,
                InputAmountId = 5,
            },
            //T5
            new
            {
                Id = 21,
                ItemId = 24276,
                InputAmountId = 1,
            },
            new
            {
                Id = 22,
                ItemId = 24276,
                InputAmountId = 5,
            },
            //T6
            new
            {
                Id = 23,
                ItemId = 24277,
                InputAmountId = 1,
            },
            new
            {
                Id = 24,
                ItemId = 24277,
                InputAmountId = 5,
            },
            #endregion
            #region Common Items
            #region Cloth
            //T1
            new
            {
                Id = 25,
                ItemId = 19718,
                InputAmountId = 10,
            },
            //T2
            new
            {
                Id = 26,
                ItemId = 19739,
                InputAmountId = 1,
            },
            new
            {
                Id = 27,
                ItemId = 19739,
                InputAmountId = 10,
            },
            //T3
            new
            {
                Id = 28,
                ItemId = 19741,
                InputAmountId = 1,
            },
            new
            {
                Id = 29,
                ItemId = 19741,
                InputAmountId = 10,
            },
            //T4
            new
            {
                Id = 30,
                ItemId = 19743,
                InputAmountId = 1,
            },
            new
            {
                Id = 31,
                ItemId = 19743,
                InputAmountId = 10,
            },
            //T5
            new
            {
                Id = 32,
                ItemId = 19748,
                InputAmountId = 1,
            },
            new
            {
                Id = 33,
                ItemId = 19748,
                InputAmountId = 10,
            },
            //T6
            new
            {
                Id = 34,
                ItemId = 19745,
                InputAmountId = 1,
            },
            #endregion
            #region Leather
            //T1
            new
            {
                Id = 35,
                ItemId = 19719,
                InputAmountId = 10,
            },
            //T2
            new
            {
                Id = 36,
                ItemId = 19728,
                InputAmountId = 1,
            },
            new
            {
                Id = 37,
                ItemId = 19728,
                InputAmountId = 10,
            },
            //T3
            new
            {
                Id = 38,
                ItemId = 19730,
                InputAmountId = 1,
            },
            new
            {
                Id = 39,
                ItemId = 19730,
                InputAmountId = 10,
            },
            //T4
            new
            {
                Id = 40,
                ItemId = 19731,
                InputAmountId = 1,
            },
            new
            {
                Id = 41,
                ItemId = 19731,
                InputAmountId = 10,
            },
            //T5
            new
            {
                Id = 42,
                ItemId = 19729,
                InputAmountId = 1,
            },
            new
            {
                Id = 43,
                ItemId = 19729,
                InputAmountId = 10,
            },
            //T6
            new
            {
                Id = 44,
                ItemId = 19732,
                InputAmountId = 1,
            },
            #endregion
            #region Metal
            //T1
            new
            {
                Id = 45,
                ItemId = 19697,
                InputAmountId = 10,
            },
            //T2
            //Iron
            new
            {
                Id = 46,
                ItemId = 19699,
                InputAmountId = 1,
            },
            new
            {
                Id = 47,
                ItemId = 19699,
                InputAmountId = 10,
            },
            //Silver
            new
            {
                Id = 48,
                ItemId = 19703,
                InputAmountId = 10,
            },
            //T3
            new
            {
                Id = 49,
                ItemId = 19698,
                InputAmountId = 1,
            },
            new
            {
                Id = 50,
                ItemId = 19698,
                InputAmountId = 10,
            },
            //T4
            new
            {
                Id = 51,
                ItemId = 19702,
                InputAmountId = 1,
            },
            new
            {
                Id = 52,
                ItemId = 19702,
                InputAmountId = 10,
            },
            //T5
            new
            {
                Id = 53,
                ItemId = 19700,
                InputAmountId = 1,
            },
            new
            {
                Id = 54,
                ItemId = 19700,
                InputAmountId = 10,
            },
            //T6
            new
            {
                Id = 55,
                ItemId = 19701,
                InputAmountId = 1,
            },
            #endregion
            #region Wood
            //T1
            new
            {
                Id = 56,
                ItemId = 19723,
                InputAmountId = 10,
            },
            //T2
            new
            {
                Id = 57,
                ItemId = 19726,
                InputAmountId = 1,
            },
            new
            {
                Id = 58,
                ItemId = 19726,
                InputAmountId = 10,
            },
            //T3
            new
            {
                Id = 59,
                ItemId = 19727,
                InputAmountId = 1,
            },
            new
            {
                Id = 60,
                ItemId = 19727,
                InputAmountId = 10,
            },
            //T4
            new
            {
                Id = 61,
                ItemId = 19724,
                InputAmountId = 1,
            },
            new
            {
                Id = 62,
                ItemId = 19724,
                InputAmountId = 10,
            },
            //T5
            new
            {
                Id = 63,
                ItemId = 19722,
                InputAmountId = 1,
            },
            new
            {
                Id = 64,
                ItemId = 19722,
                InputAmountId = 10,
            },
            //T6
            new
            {
                Id = 65,
                ItemId = 19725,
                InputAmountId = 1,
            },
            #endregion
            #endregion
            #region Refined Common Items
            #region Cloth
            //T1
            new
            {
                Id = 66,
                ItemId = 19720,
                InputAmountId = 10,
            },
            //T2
            new
            {
                Id = 67,
                ItemId = 19740,
                InputAmountId = 1,
            },
            new
            {
                Id = 68,
                ItemId = 19740,
                InputAmountId = 10,
            },
            //T3
            new
            {
                Id = 69,
                ItemId = 19742,
                InputAmountId = 1,
            },
            new
            {
                Id = 70,
                ItemId = 19742,
                InputAmountId = 10,
            },
            //T4
            new
            {
                Id = 71,
                ItemId = 19744,
                InputAmountId = 1,
            },
            new
            {
                Id = 72,
                ItemId = 19744,
                InputAmountId = 10,
            },
            //T5
            new
            {
                Id = 73,
                ItemId = 19747,
                InputAmountId = 1,
            },
            new
            {
                Id = 74,
                ItemId = 19747,
                InputAmountId = 10,
            },
            //T6
            new
            {
                Id = 75,
                ItemId = 19746,
                InputAmountId = 1,
            },
            #endregion
            #region Leather
            //T1
            new
            {
                Id = 76,
                ItemId = 19738,
                InputAmountId = 10,
            },
            //T2
            new
            {
                Id = 77,
                ItemId = 19733,
                InputAmountId = 1,
            },
            new
            {
                Id = 78,
                ItemId = 19733,
                InputAmountId = 10,
            },
            //T3
            new
            {
                Id = 79,
                ItemId = 19734,
                InputAmountId = 1,
            },
            new
            {
                Id = 80,
                ItemId = 19734,
                InputAmountId = 10,
            },
            //T4
            new
            {
                Id = 81,
                ItemId = 19736,
                InputAmountId = 1,
            },
            new
            {
                Id = 82,
                ItemId = 19736,
                InputAmountId = 10,
            },
            //T5
            new
            {
                Id = 83,
                ItemId = 19735,
                InputAmountId = 1,
            },
            new
            {
                Id = 84,
                ItemId = 19735,
                InputAmountId = 10,
            },
            //T6
            new
            {
                Id = 85,
                ItemId = 19737,
                InputAmountId = 1,
            },
            #endregion
            #region Metal
            //T1
            //Copper Ingot
            new
            {
                Id = 86,
                ItemId = 19680,
                InputAmountId = 10,
            },
            //Bronze Ingot
            new
            {
                Id = 87,
                ItemId = 19679,
                InputAmountId = 10,
            },
            //T2
            //Silver Ingot
            new
            {
                Id = 88,
                ItemId = 19687,
                InputAmountId = 1,
            },
            new
            {
                Id = 89,
                ItemId = 19687,
                InputAmountId = 10,
            },
            //Iron Ingot
            new
            {
                Id = 90,
                ItemId = 19683,
                InputAmountId = 1,
            },
            new
            {
                Id = 91,
                ItemId = 19683,
                InputAmountId = 10,
            },
            //T3
            //Steel Ingot
            new
            {
                Id = 92,
                ItemId = 19688,
                InputAmountId = 1,
            },
            //Gold Ingot
            new
            {
                Id = 93,
                ItemId = 19682,
                InputAmountId = 1,
            },
            new
            {
                Id = 94,
                ItemId = 19682,
                InputAmountId = 10,
            },
            //T4
            //Platinum Ingot
            new
            {
                Id = 95,
                ItemId = 19686,
                InputAmountId = 1,
            },
            new
            {
                Id = 96,
                ItemId = 19686,
                InputAmountId = 10,
            },
            //Darsteel Ingot
            new
            {
                Id = 97,
                ItemId = 19681,
                InputAmountId = 10,
            },
            //T5
            //Mithril Ingot
            new
            {
                Id = 98,
                ItemId = 19684,
                InputAmountId = 1,
            },
            new
            {
                Id = 99,
                ItemId = 19684,
                InputAmountId = 10,
            },
            //T6
            new
            {
                Id = 100,
                ItemId = 19685,
                InputAmountId = 1,
            },
            #endregion
            #region Wood
            //T1
            new
            {
                Id = 101,
                ItemId = 19710,
                InputAmountId = 10,
            },
            //T2
            new
            {
                Id = 102,
                ItemId = 19713,
                InputAmountId = 1,
            },
            new
            {
                Id = 103,
                ItemId = 19713,
                InputAmountId = 10,
            },
            //T3
            new
            {
                Id = 104,
                ItemId = 19714,
                InputAmountId = 1,
            },
            new
            {
                Id = 105,
                ItemId = 19714,
                InputAmountId = 10,
            },
            //T4
            new
            {
                Id = 106,
                ItemId = 19711,
                InputAmountId = 1,
            },
            new
            {
                Id = 107,
                ItemId = 19711,
                InputAmountId = 10,
            },
            //T5
            new
            {
                Id = 108,
                ItemId = 19709,
                InputAmountId = 1,
            },
            new
            {
                Id = 109,
                ItemId = 19709,
                InputAmountId = 10,
            },
            //T6
            new
            {
                Id = 110,
                ItemId = 19712,
                InputAmountId = 1,
            },
            #endregion
            #endregion
            #region Fine Items
            #region Bones
            //T1
            new
            {
                Id = 111,
                ItemId = 24342,
                InputAmountId = 9,
            },
            //T2
            new
            {
                Id = 112,
                ItemId = 24343,
                InputAmountId = 1,
            },
            new
            {
                Id = 113,
                ItemId = 24343,
                InputAmountId = 9,
            },
            //T3
            new
            {
                Id = 114,
                ItemId = 24344,
                InputAmountId = 1,
            },
            new
            {
                Id = 115,
                ItemId = 24344,
                InputAmountId = 9,
            },
            //T4
            new
            {
                Id = 116,
                ItemId = 24345,
                InputAmountId = 1,
            },
            new
            {
                Id = 117,
                ItemId = 24345,
                InputAmountId = 9,
            },
            //T5
            new
            {
                Id = 118,
                ItemId = 24341,
                InputAmountId = 1,
            },
            new
            {
                Id = 119,
                ItemId = 24341,
                InputAmountId = 9,
            },
            //T6
            new
            {
                Id = 120,
                ItemId = 24358,
                InputAmountId = 1,
            },
            #endregion
            #region Claws
            //T1
            new
            {
                Id = 121,
                ItemId = 24346,
                InputAmountId = 9,
            },
            //T2
            new
            {
                Id = 122,
                ItemId = 24347,
                InputAmountId = 1,
            },
            new
            {
                Id = 123,
                ItemId = 24347,
                InputAmountId = 9,
            },
            //T3
            new
            {
                Id = 124,
                ItemId = 24348,
                InputAmountId = 1,
            },
            new
            {
                Id = 125,
                ItemId = 24348,
                InputAmountId = 9,
            },
            //T4
            new
            {
                Id = 126,
                ItemId = 24349,
                InputAmountId = 1,
            },
            new
            {
                Id = 127,
                ItemId = 24349,
                InputAmountId = 9,
            },
            //T5
            new
            {
                Id = 128,
                ItemId = 24350,
                InputAmountId = 1,
            },
            new
            {
                Id = 129,
                ItemId = 24350,
                InputAmountId = 9,
            },
            //T6
            new
            {
                Id = 130,
                ItemId = 24351,
                InputAmountId = 1,
            },
            #endregion
            #region Dusts
            //T1
            new
            {
                Id = 131,
                ItemId = 24272,
                InputAmountId = 10,
            },
            //T2
            new
            {
                Id = 132,
                ItemId = 24273,
                InputAmountId = 1,
            },
            new
            {
                Id = 133,
                ItemId = 24273,
                InputAmountId = 10,
            },
            //T3,
            new
            {
                Id = 134,
                ItemId = 24274,
                InputAmountId = 10,
            },
            //T4
            new
            {
                Id = 135,
                ItemId = 24275,
                InputAmountId = 10,
            },
            //T5
            new
            {
                Id = 136,
                ItemId = 24276,
                InputAmountId = 10,
            },
            #endregion
            #region Fangs
            //T1
            new
            {
                Id = 137,
                ItemId = 24352,
                InputAmountId = 9,
            },
            //T2
            new
            {
                Id = 138,
                ItemId = 24353,
                InputAmountId = 1,
            },
            new
            {
                Id = 139,
                ItemId = 24353,
                InputAmountId = 9,
            },
            //T3
            new
            {
                Id = 140,
                ItemId = 24354,
                InputAmountId = 1,
            },
            new
            {
                Id = 141,
                ItemId = 24354,
                InputAmountId = 9,
            },
            //T4
            new
            {
                Id = 142,
                ItemId = 24355,
                InputAmountId = 1,
            },
            new
            {
                Id = 143,
                ItemId = 24355,
                InputAmountId = 9,
            },
            //T5
            new
            {
                Id = 144,
                ItemId = 24356,
                InputAmountId = 1,
            },
            new
            {
                Id = 145,
                ItemId = 24356,
                InputAmountId = 9,
            },
            //T6
            new
            {
                Id = 146,
                ItemId = 24357,
                InputAmountId = 1,
            },
            #endregion
            #region Scales
            //T1
            new
            {
                Id = 147,
                ItemId = 24284,
                InputAmountId = 9,
            },
            //T2
            new
            {
                Id = 148,
                ItemId = 24285,
                InputAmountId = 1,
            },
            new
            {
                Id = 149,
                ItemId = 24285,
                InputAmountId = 9,
            },
            //T3
            new
            {
                Id = 150,
                ItemId = 24286,
                InputAmountId = 1,
            },
            new
            {
                Id = 151,
                ItemId = 24286,
                InputAmountId = 9,
            },
            //T4
            new
            {
                Id = 152,
                ItemId = 24287,
                InputAmountId = 1,
            },
            new
            {
                Id = 153,
                ItemId = 24287,
                InputAmountId = 9,
            },
            //T5
            new
            {
                Id = 154,
                ItemId = 24288,
                InputAmountId = 1,
            },
            new
            {
                Id = 155,
                ItemId = 24288,
                InputAmountId = 9,
            },
            //T6
            new
            {
                Id = 156,
                ItemId = 24289,
                InputAmountId = 1,
            },
            #endregion
            #region Totems
            //T1
            new
            {
                Id = 157,
                ItemId = 24296,
                InputAmountId = 9,
            },
            //T2
            new
            {
                Id = 158,
                ItemId = 24297,
                InputAmountId = 1,
            },
            new
            {
                Id = 159,
                ItemId = 24297,
                InputAmountId = 9,
            },
            //T3
            new
            {
                Id = 160,
                ItemId = 24298,
                InputAmountId = 1,
            },
            new
            {
                Id = 161,
                ItemId = 24298,
                InputAmountId = 9,
            },
            //T4
            new
            {
                Id = 162,
                ItemId = 24363,
                InputAmountId = 1,
            },
            new
            {
                Id = 163,
                ItemId = 24363,
                InputAmountId = 9,
            },
            //T5
            new
            {
                Id = 164,
                ItemId = 24299,
                InputAmountId = 1,
            },
            new
            {
                Id = 165,
                ItemId = 24299,
                InputAmountId = 9,
            },
            //T6
            new
            {
                Id = 166,
                ItemId = 24300,
                InputAmountId = 1,
            },
            #endregion
            #region Venoms
            //T1
            new
            {
                Id = 167,
                ItemId = 24278,
                InputAmountId = 9,
            },
            //T2
            new
            {
                Id = 168,
                ItemId = 24279,
                InputAmountId = 1,
            },
            new
            {
                Id = 169,
                ItemId = 24279,
                InputAmountId = 9,
            },
            //T3
            new
            {
                Id = 170,
                ItemId = 24280,
                InputAmountId = 1,
            },
            new
            {
                Id = 171,
                ItemId = 24280,
                InputAmountId = 9,
            },
            //T4
            new
            {
                Id = 172,
                ItemId = 24281,
                InputAmountId = 1,
            },
            new
            {
                Id = 173,
                ItemId = 24281,
                InputAmountId = 9,
            },
            //T5
            new
            {
                Id = 174,
                ItemId = 24282,
                InputAmountId = 1,
            },
            new
            {
                Id = 175,
                ItemId = 24282,
                InputAmountId = 9,
            },
            //T6
            new
            {
                Id = 176,
                ItemId = 24283,
                InputAmountId = 1,
            },
            #endregion
            #region Bloods
            //T1
            new
            {
                Id = 177,
                ItemId = 24290,
                InputAmountId = 9,
            },
            //T2
            new
            {
                Id = 178,
                ItemId = 24291,
                InputAmountId = 1,
            },
            new
            {
                Id = 179,
                ItemId = 24291,
                InputAmountId = 9,
            },
            //T3
            new
            {
                Id = 180,
                ItemId = 24292,
                InputAmountId = 1,
            },
            new
            {
                Id = 181,
                ItemId = 24292,
                InputAmountId = 9,
            },
            //T4
            new
            {
                Id = 182,
                ItemId = 24293,
                InputAmountId = 1,
            },
            new
            {
                Id = 183,
                ItemId = 24293,
                InputAmountId = 9,
            },
            //T5
            new
            {
                Id = 184,
                ItemId = 24294,
                InputAmountId = 1,
            },
            new
            {
                Id = 185,
                ItemId = 24294,
                InputAmountId = 9,
            },
            //T6
            new
            {
                Id = 186,
                ItemId = 24295,
                InputAmountId = 1,
            },
            #endregion
            #endregion
            #region Rare Items
            #region Charged
            //T1
            new
            {
                Id = 187,
                ItemId = 24301,
                InputAmountId = 2,
            },
            new
            {
                Id = 188,
                ItemId = 24301,
                InputAmountId = 7,
            },
            //T2
            new
            {
                Id = 189,
                ItemId = 24302,
                InputAmountId = 2,
            },
            new
            {
                Id = 190,
                ItemId = 24302,
                InputAmountId = 6,
            },
            //T3
            new
            {
                Id = 191,
                ItemId = 24303,
                InputAmountId = 2,
            },
            new
            {
                Id = 192,
                ItemId = 24303,
                InputAmountId = 4,
            },
            //T4
            new
            {
                Id = 193,
                ItemId = 24304,
                InputAmountId = 2,
            },
            #endregion
            #region Corrupted
            //T1
            new
            {
                Id = 194,
                ItemId = 24336,
                InputAmountId = 2,
            },
            new
            {
                Id = 195,
                ItemId = 24336,
                InputAmountId = 7,
            },
            //T2
            new
            {
                Id = 196,
                ItemId = 24337,
                InputAmountId = 2,
            },
            new
            {
                Id = 197,
                ItemId = 24337,
                InputAmountId = 6,
            },
            //T3
            new
            {
                Id = 198,
                ItemId = 24338,
                InputAmountId = 2,
            },
            new
            {
                Id = 199,
                ItemId = 24338,
                InputAmountId = 4,
            },
            //T4
            new
            {
                Id = 200,
                ItemId = 24339,
                InputAmountId = 2,
            },
            #endregion
            #region Crystal
            //T1
            new
            {
                Id = 201,
                ItemId = 24326,
                InputAmountId = 2,
            },
            new
            {
                Id = 202,
                ItemId = 24326,
                InputAmountId = 7,
            },
            //T2
            new
            {
                Id = 203,
                ItemId = 24327,
                InputAmountId = 2,
            },
            new
            {
                Id = 204,
                ItemId = 24327,
                InputAmountId = 6,
            },
            //T3
            new
            {
                Id = 205,
                ItemId = 24328,
                InputAmountId = 2,
            },
            new
            {
                Id = 206,
                ItemId = 24328,
                InputAmountId = 4,
            },
            //T4
            new
            {
                Id = 207,
                ItemId = 24329,
                InputAmountId = 2,
            },
            #endregion
            #region Destroyer
            //T1
            new
            {
                Id = 208,
                ItemId = 24321,
                InputAmountId = 2,
            },
            new
            {
                Id = 209,
                ItemId = 24321,
                InputAmountId = 7,
            },
            //T2
            new
            {
                Id = 210,
                ItemId = 24322,
                InputAmountId = 2,
            },
            new
            {
                Id = 211,
                ItemId = 24322,
                InputAmountId = 6,
            },
            //T3
            new
            {
                Id = 212,
                ItemId = 24323,
                InputAmountId = 2,
            },
            new
            {
                Id = 213,
                ItemId = 24323,
                InputAmountId = 4,
            },
            //T4
            new
            {
                Id = 214,
                ItemId = 24324,
                InputAmountId = 2,
            },
            #endregion
            #region Essence
            //T1
            new
            {
                Id = 215,
                ItemId = 24331,
                InputAmountId = 2,
            },
            new
            {
                Id = 216,
                ItemId = 24331,
                InputAmountId = 7,
            },
            //T2
            new
            {
                Id = 217,
                ItemId = 24332,
                InputAmountId = 2,
            },
            new
            {
                Id = 218,
                ItemId = 24332,
                InputAmountId = 6,
            },
            //T3
            new
            {
                Id = 219,
                ItemId = 24333,
                InputAmountId = 2,
            },
            new
            {
                Id = 220,
                ItemId = 24333,
                InputAmountId = 4,
            },
            //T4
            new
            {
                Id = 221,
                ItemId = 24334,
                InputAmountId = 2,
            },
            #endregion
            #region Glacial
            //T1
            new
            {
                Id = 222,
                ItemId = 24316,
                InputAmountId = 2,
            },
            new
            {
                Id = 223,
                ItemId = 24316,
                InputAmountId = 7,
            },
            //T2
            new
            {
                Id = 224,
                ItemId = 24317,
                InputAmountId = 2,
            },
            new
            {
                Id = 225,
                ItemId = 24317,
                InputAmountId = 6,
            },
            //T3
            new
            {
                Id = 226,
                ItemId = 24318,
                InputAmountId = 2,
            },
            new
            {
                Id = 227,
                ItemId = 24318,
                InputAmountId = 4,
            },
            //T4
            new
            {
                Id = 228,
                ItemId = 24319,
                InputAmountId = 2,
            },
            #endregion
            #region Molten
            //T1
            new
            {
                Id = 229,
                ItemId = 24311,
                InputAmountId = 2,
            },
            new
            {
                Id = 230,
                ItemId = 24311,
                InputAmountId = 7,
            },
            //T2
            new
            {
                Id = 231,
                ItemId = 24312,
                InputAmountId = 2,
            },
            new
            {
                Id = 232,
                ItemId = 24312,
                InputAmountId = 6,
            },
            //T3
            new
            {
                Id = 233,
                ItemId = 24313,
                InputAmountId = 2,
            },
            new
            {
                Id = 234,
                ItemId = 24313,
                InputAmountId = 4,
            },
            //T4
            new
            {
                Id = 235,
                ItemId = 24314,
                InputAmountId = 2,
            },
            #endregion
            #region Onyx
            //T1
            new
            {
                Id = 236,
                ItemId = 24306,
                InputAmountId = 2,
            },
            new
            {
                Id = 237,
                ItemId = 24306,
                InputAmountId = 7,
            },
            //T2
            new
            {
                Id = 238,
                ItemId = 24307,
                InputAmountId = 2,
            },
            new
            {
                Id = 239,
                ItemId = 24307,
                InputAmountId = 6,
            },
            //T3
            new
            {
                Id = 240,
                ItemId = 24308,
                InputAmountId = 2,
            },
            new
            {
                Id = 241,
                ItemId = 24308,
                InputAmountId = 4,
            },
            //T4
            new
            {
                Id = 242,
                ItemId = 24309,
                InputAmountId = 2,
            },
            #endregion
            #endregion
        ];
    }

    internal static IEnumerable<MysticForgeRecipeInputAmount> GetAmounts()
    {
        return
        [
            new MysticForgeRecipeInputAmount()
            {
                Id = 1,
                Amount = 1
            },
            new MysticForgeRecipeInputAmount()
            {
                Id = 2,
                Amount = 2
            },
            new MysticForgeRecipeInputAmount()
            {
                Id = 3,
                Amount = 3
            },
            new MysticForgeRecipeInputAmount()
            {
                Id = 4,
                Amount = 4
            },
            new MysticForgeRecipeInputAmount()
            {
                Id = 5,
                Amount = 5
            },
            new MysticForgeRecipeInputAmount()
            {
                Id = 6,
                Amount = 6
            },
            new MysticForgeRecipeInputAmount()
            {
                Id = 7,
                Amount = 8
            },
            new MysticForgeRecipeInputAmount()
            {
                Id = 8,
                Amount = 10
            },
            new MysticForgeRecipeInputAmount()
            {
                Id = 9,
                Amount = 50
            },
            new MysticForgeRecipeInputAmount()
            {
                Id = 10,
                Amount = 250
            }
        ];
    }
}
