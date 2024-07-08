using Gw2CraftCalculator.Interfaces.Utils;
using GW2CraftCalculator.Utils.Converters;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Globalization;

namespace GW2CraftCalculator.Converters;
public class FilterConverter : TypeConverter, IFilterConverter
{
    private readonly ILogger<BaseConverter> _logger;

    public FilterConverter(ILogger<BaseConverter> logger)
    {
        _logger = logger;
    }

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if (value is string stringValue)
        {
            return ConvertString(stringValue);
        }
        throw new NotSupportedException("Can't convert value to language code!");
    }

    public Dictionary<string, IEnumerable<string>> ConvertString(string value)
    {
        _logger.LogDebug("Converting filter string: {filterString}", value);
        string[] parts = value.Split(';');
        _logger.LogDebug("Filter parts: {parts}", string.Join(" -|- ", parts));

        Dictionary<string, IEnumerable<string>> filterValues = [];

        foreach (string part in parts)
        {
            if (string.IsNullOrEmpty(part))
            {
                continue;
            }

            string[] descriptionValues = part.Split('=');
            if (descriptionValues.Length != 2)
            {
                throw new InvalidCastException("Each filter part can only containe one '='");
            }
            _logger.LogDebug("Discriptor {discriptor} Values: {values}", descriptionValues[0], descriptionValues[1]);

            string[] values = descriptionValues[1].Split(',').Select(v => v.Trim()).ToArray();
            _logger.LogDebug("Filter values: {values}", string.Join(" -|- ", values));

            filterValues.Add(descriptionValues[0], values);
        }

        return filterValues;
    }
}
