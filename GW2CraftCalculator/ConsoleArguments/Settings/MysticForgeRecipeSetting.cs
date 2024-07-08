using GW2CraftCalculator.Converters;
using Spectre.Console.Cli;
using System.ComponentModel;

namespace GW2CraftCalculator.ConsoleArguments.Settings;
public class MysticForgeRecipeSetting : DefaultSetting
{
    [Description("Specifies the filter that should be used.")]
    [CommandOption("-f|--filter [Filter]")]
    [TypeConverter(typeof(FilterConverter))]
    public FlagValue<Dictionary<string, IEnumerable<string>>> Filter { get; init; }
}
