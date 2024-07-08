using System.Text.RegularExpressions;

namespace GW2CraftCalculator.Models.Exceptions;
public partial class ColorException : Exception
{
    public ColorException(string message) : base(message) { }

    public static void ThrowIfColorInvalidHexFormat(string color)
    {
        if (!HexColorRegex().IsMatch(color))
        {
            string message = $"Color {color} is not a valid Hex color format!";
            throw new ColorException(message);
        }
    }

    [GeneratedRegex("^#(?:[0-9a-fA-F]{3,4}){1,2}$")]
    private static partial Regex HexColorRegex();
}
