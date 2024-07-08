using GW2CraftCalculator.Models.Enums;
using GW2CraftCalculator.Utils.Converters;
using Spectre.Console.Cli;
using System.ComponentModel;

namespace GW2CraftCalculator.ConsoleArguments.Settings;
public class DefaultSetting : EmptySetting
{
    [Description("Language that should be used for the Item names. Allowed values are [yellow2]german (de, deutsch)[/], [yellow2]english (en)[/], [yellow2]french (fr, français)[/]" +
        "[yellow2]spanish (es, español)[/], [yellow2]korean (ko, 한국어)[/], [yellow2]chinese (zh, 中文)[/]")]
    [CommandOption("-l|--language <LANGUAGE>")]
    [TypeConverter(typeof(LanguageConverter))]
    [DefaultValue(Language.English)]
    public Language Language { get; init; }
}
