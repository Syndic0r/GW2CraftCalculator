using Spectre.Console.Cli;
using System.ComponentModel;

namespace GW2CraftCalculator.ConsoleArguments.Settings;

public class GuiSetting : DefaultSetting
{
    [Description("Specifies if you want to use a Filter. That skips the prompt to use a filter.")]
    [CommandOption("-f|--filter [Filter]")]
    public FlagValue<bool?> Filter { get; init; }
}
