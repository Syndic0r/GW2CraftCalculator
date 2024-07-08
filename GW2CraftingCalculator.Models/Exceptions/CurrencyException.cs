using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Utils.Exceptions;
public class CurrencyException : Exception
{
    public CurrencyException(string? message) : base(message) { }

    public static void ThrowIfGold(Currency currency)
    {
        if (currency == Currency.Coin)
        {
            IEnumerable<string> otherCurrencies = GetExpectedValues(Currency.Coin);

            string message = $"Invalid Gold Currency! Expected one currencies of: {string.Join(", ", otherCurrencies)}";
            throw new CurrencyException(message);
        }
    }

    public static IEnumerable<string> GetExpectedValues(params Currency[] excludeValues)
    {
        IEnumerable<string> expectedEnumValues = Enum.GetValues<Currency>()
                                                    .Where(v => !excludeValues.Contains(v))
                                                    .Select(v => $"{(int)v} - {v}");
        return expectedEnumValues;
    }
}
