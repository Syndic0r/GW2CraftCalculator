using GW2CraftCalculator.Models.Attributes;
using GW2CraftCalculator.Models.Colors;

namespace GW2CraftCalculator.Models.Enums;

public enum Currency
{
    [CurrencyColor(CustomColors.GOLD, CustomColors.SILVER, CustomColors.COPPER)]
    Coin = 1,
    [CurrencyColor(CustomColors.KARMA)]
    Karma = 2,
    [CurrencyColor(CustomColors.LAUREL)]
    Laurel = 3,
    [CurrencyColor(CustomColors.GEMS)]
    Gems = 4,
    [CurrencyColor(CustomColors.SPIRIT_SHARD)]
    SpiritShard = 23,
}
