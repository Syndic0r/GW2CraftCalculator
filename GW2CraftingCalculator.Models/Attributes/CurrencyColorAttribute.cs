using GW2CraftCalculator.Models.Exceptions;

namespace GW2CraftCalculator.Models.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class CurrencyColorAttribute : Attribute
{
    public CurrencyColorAttribute(params string[] colors)
    {
        foreach (string color in colors)
        {
            ColorException.ThrowIfColorInvalidHexFormat(color);
        }
        Colors = colors;
    }

    public string[] Colors { get; }
}
