namespace GW2CraftCalculator.Data.DataSeeding;
public class SalvageOutputs
{
    internal static IEnumerable<object> Get()
    {
        return
        [
            #region Dust
            //Crude
            new
            {
                Id = 1,
                ItemId = 24277,
                OutputAmount = 1.47M
            },
            
            //Basic, Copper-Fed
            new
            {
                Id = 2,
                ItemId = 24277,
                OutputAmount = 1.63M
            },
            //Fine
            new
            {
                Id = 3,
                ItemId = 24277,
                OutputAmount = 1.75M
            },
            //Journeyman, Runecrafter's
            new
            {
                Id = 4,
                ItemId = 24277,
                OutputAmount = 1.58M
            },
            //Master's, Mystic, Silver-Fed
            new
            {
                Id = 5,
                ItemId = 24277,
                OutputAmount = 1.85M
            },
            //Black Lion
            new
            {
                Id = 6,
                ItemId = 24277,
                OutputAmount = 2.04M
            },
            #endregion
            #region Luck
            //Fine
            new
            {
                Id = 7,
                ItemId = 45175,
                OutputAmount = 6.77M
            },
            new
            {
                Id = 8,
                ItemId = 45175,
                OutputAmount = 7.08M
            },
            new
            {
                Id = 9,
                ItemId = 45175,
                OutputAmount = 7.47M
            },
            new
            {
                Id = 10,
                ItemId = 45175,
                OutputAmount = 7.22M
            },
            new
            {
                Id = 11,
                ItemId = 45175,
                OutputAmount = 7.16M
            },
            new
            {
                Id = 12,
                ItemId = 45175,
                OutputAmount = 6.88M
            },
            //Masterwork
            new
            {
                Id = 13,
                ItemId = 45176,
                OutputAmount = 0.51M
            },
            new
            {
                Id = 14,
                ItemId = 45176,
                OutputAmount = 0.47M
            },
            new
            {
                Id = 15,
                ItemId = 45176,
                OutputAmount = 0.49M
            },
            new
            {
                Id = 16,
                ItemId = 45176,
                OutputAmount = 0.52M
            },
            //Rare
            new
            {
                Id = 17,
                ItemId = 45177,
                OutputAmount = 0.05M
            },
            //Exotic
            new
            {
                Id = 18,
                ItemId = 45178,
                OutputAmount = 0.01M
            },
            new
            {
                Id = 19,
                ItemId = 45178,
                OutputAmount = 0.02M
            }
            #endregion
        ];
    }
}
