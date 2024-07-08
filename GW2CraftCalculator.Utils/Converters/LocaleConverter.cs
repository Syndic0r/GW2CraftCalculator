using GW2CraftCalculator.Interfaces.Utils;
using GW2CraftCalculator.Models.Enums;
using Gw2Sharp.WebApi;
using Microsoft.Extensions.Logging;

namespace GW2CraftCalculator.Utils.Converters;

public class LocaleConverter : BaseConverter, ILocaleConverter
{
    private readonly IDictionary<Language, Locale> _lookup;

    public LocaleConverter(ILogger<LocaleConverter> logger) : base(logger)
    {
        _lookup = new Dictionary<Language, Locale>()
        {
            { Language.German, Locale.German },
            { Language.English, Locale.English },
            { Language.French, Locale.French },
            { Language.Spanish, Locale.Spanish },
            { Language.Korean, Locale.Korean },
            { Language.Chinese, Locale.Chinese }
        };
    }

    public Locale ConvertFrom(Language language)
    {
        return GetLookupValue(language, Language.English, _lookup);
    }
}
