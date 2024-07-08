using GW2CraftCalculator.Models.Data;
using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Data.DataSeeding;
public class CurrencyConversions
{
    public static IEnumerable<CurrencyConversion> Get()
    {
        return
        [
            new CurrencyConversion()
            {
                Id = 1,
                BaseCurrencyAmount = 1000,
                BaseCurrencyType = Currency.Karma,
                ConversionCurrencyAmount = 1000,
                ConversionCurrencyType = Currency.Coin
            },
            new CurrencyConversion()
            {
                Id = 2,
                BaseCurrencyAmount = 1,
                BaseCurrencyType = Currency.Laurel,
                ConversionCurrencyAmount = 3000,
                ConversionCurrencyType = Currency.Coin
            }
        ];
    }
}
