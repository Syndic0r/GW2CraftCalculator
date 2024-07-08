using GW2CraftCalculator.Interfaces.Utils;
using GW2CraftCalculator.Models.Enums;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Globalization;

namespace GW2CraftCalculator.Utils.Converters;
public class LanguageConverter : BaseConverter, ILanguageConverter
{
    private readonly IDictionary<string, Language> _codeLanguageLookup;
    private readonly IDictionary<Language, string> _languageCodeLookup;

    public LanguageConverter(ILogger<LanguageConverter> logger) : base(logger)
    {
        _codeLanguageLookup = new Dictionary<string, Language>(StringComparer.OrdinalIgnoreCase)
        {
            { "de", Language.German },
            { "deutsch", Language.German },
            { "german", Language.German },
            { "en", Language.English },
            { "english", Language.English },
            { "fr", Language.French },
            { "french", Language.French },
            { "français", Language.French },
            { "es", Language.Spanish },
            { "español", Language.Spanish },
            { "spanish", Language.Spanish },
            { "ko", Language.Korean },
            { "korean", Language.Korean },
            { "한국어", Language.Korean },
            { "zh", Language.Chinese },
            { "chinese", Language.Chinese },
            { "中文", Language.Chinese },
        };

        _languageCodeLookup = new Dictionary<Language, string>()
        {
            { Language.German, "de" },
            { Language.English, "en" },
            { Language.French, "fr" },
            { Language.Spanish, "es" },
            { Language.Korean, "ko" },
            { Language.Chinese, "zh" }
        };
    }

    public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if (value is string stringValue)
        {
            return ConvertFrom(stringValue);
        }
        throw new NotSupportedException("Can't convert value to language code!");
    }

    public Language ConvertFrom(string languageCode)
    {
        return GetLookupValue(languageCode, "en", _codeLanguageLookup);
    }

    public string ConvertFrom(Language language)
    {
        return GetLookupValue(language, Language.English, _languageCodeLookup);
    }
}
