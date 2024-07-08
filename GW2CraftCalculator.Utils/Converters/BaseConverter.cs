using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Globalization;

namespace GW2CraftCalculator.Utils.Converters;
public abstract class BaseConverter : TypeConverter
{
    private readonly ILogger<BaseConverter> _logger;

    protected BaseConverter(ILogger<BaseConverter> logger)
    {
        _logger = logger;
    }

    protected TSearchedValue GetLookupValue<TSearchKey, TSearchedValue>(TSearchKey searchedKey, TSearchKey fallbackKey, IDictionary<TSearchKey, TSearchedValue> lookup)
        where TSearchKey : notnull
    {
        try
        {
            return GetLookupValue(searchedKey, lookup);
        }
        catch (InvalidOperationException)
        {
            const string logMessage = "The key '{searchedKey}' is not a valid! Falling back to fallback key '{fallbackKey}'...";
            _logger.LogWarning(logMessage, searchedKey.ToString(), fallbackKey.ToString());
            return GetLookupValue(fallbackKey, lookup);
        }
    }

    protected TSearchedValue GetLookupValue<TSearchKey, TSearchedValue>(TSearchKey searchKey, IDictionary<TSearchKey, TSearchedValue> lookup) where TSearchKey : notnull
    {
        bool result = lookup.TryGetValue(searchKey, out TSearchedValue? foundValue);
        if (result)
        {
            _logger.LogDebug("Found value '{foundValue}' for key '{searchKey}'.", foundValue?.ToString(), searchKey.ToString());
            return foundValue!;
        }

        const string format = "The key '{0}' is not valid!";
        string message = string.Format(CultureInfo.InvariantCulture, format, searchKey.ToString());
        throw new InvalidOperationException(message);
    }
}
