using GW2CraftCalculator.Interfaces.Translation;
using GW2CraftCalculator.Interfaces.Utils;
using GW2CraftCalculator.Models.Enums;
using GW2CraftCalculator.Utils.Extensions;
using GW2CraftCalculator.Utils.Logging;
using Microsoft.Extensions.Logging;

namespace GW2CraftCalculator.Translation;
public class TranslationsProcessor : ITranslationsProcessor
{
    private readonly ILanguageConverter _languageConverter;
    private readonly ITranslationCodeConverter _translationCodeConverter;
    private readonly IItemGroupConverter _itemGroupConverter;
    private readonly IItemTypeConverter _itemTypeConverter;
    private readonly IRarityConverter _rarityConverter;
    private readonly IFileReader _fileReader;
    private readonly ILogger<TranslationsProcessor> _logger;

    private Dictionary<string, Dictionary<string, string>>? Translations { get; set; }
    private Dictionary<Currency, string>? CurrencyTranslations { get; set; }

    public TranslationsProcessor(ILanguageConverter languageConverter, ITranslationCodeConverter translationCodeConverter, IItemGroupConverter itemGroupConverter, 
                                IItemTypeConverter itemTypeConverter, IRarityConverter rarityConverter, IFileReader fileReader, ILogger<TranslationsProcessor> logger)
    {
        _languageConverter = languageConverter;
        _translationCodeConverter = translationCodeConverter;
        _itemGroupConverter = itemGroupConverter;
        _itemTypeConverter = itemTypeConverter;
        _rarityConverter = rarityConverter;
        _fileReader = fileReader;
        _logger = logger;
    }

    public string GetCurrencyTranslation(Currency currency)
    {
        ArgumentNullException.ThrowIfNull(CurrencyTranslations, nameof(currency));

        if (CurrencyTranslations.TryGetValue(currency, out string? result))
        {
            return result;
        }

        return "";
    }

    public void TrySetCurrencyTranslations(IEnumerable<KeyValuePair<int, string>> currencyTranslations, bool forceOverride = false)
    {
        foreach(KeyValuePair<int, string> translation in currencyTranslations)
        {
            TrySetCurrencyTranslation(translation.Key, translation.Value, forceOverride);
        }
    }

    public bool TrySetCurrencyTranslation(int currencyId, string translation, bool forceOverride = false)
    {
        if (!Enum.IsDefined(typeof(Currency), currencyId))
        {
            IEnumerable<string> configuredCurrencies = EnumExtensions.GetExpectedValues<Currency>();
            _logger.LogWarning("Currency {currencyId} is not defined. Existing Currencies: {currencies}", currencyId, configuredCurrencies.ConvertReadable());
            return false;
        }

        Currency currency = (Currency)currencyId;

        CurrencyTranslations ??= [];

        if (!CurrencyTranslations.TryGetValue(currency, out _))
        {
            CurrencyTranslations.Add(currency, translation);
            return true;
        }

        if (forceOverride) 
        {
            CurrencyTranslations[currency] = translation;
            return true;
        }

        return false;
    }

    public async Task<string> GetTranslation(TranslationCode translation, Language language)
    {
        return await GetTranslation(translation, language, default);
    }

    public async Task<string[]> GetTranslations(Language language, params TranslationCode[] translations)
    {
        string[] values = [];
        foreach (TranslationCode translation in translations)
        {
            string value = await GetTranslation(translation, language, default);
            values = values.Add(value);
        }
        return values;
    }

    public async Task<string> GetTranslation(TranslationCode translation, Language language, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Getting translation. Code: {translationCode} Language: {language}", translation.ToString(), language.ToString());
        string languageCode = GetCode(language, _languageConverter);
        string translationCode = GetCode(translation, _translationCodeConverter);
        _logger.LogDebug("Converted codes Translation: {translationCode} Language: {language}", translationCode.ToString(), languageCode.ToString());

        cancellationToken.ThrowIfCancellationRequested();
        Translations ??= await LoadTranslation(languageCode, cancellationToken);

        bool result = Translations.TryGetValue(languageCode, out Dictionary<string, string>? translationEntry);
        if (!result)
        {
            cancellationToken.ThrowIfCancellationRequested();
            translationEntry = await LoadTranslationFile(languageCode, cancellationToken);
            Translations.Add(languageCode, translationEntry);
        }

        string translationString = translationEntry![translationCode];
        _logger.LogDebug("Selected translation: {translation}", translationString);

        return translationString;
    }

    public async Task<string[]> GetTranslations(Language language, params ItemGroup[] translations)
    {
        string[] values = [];
        foreach(ItemGroup itemGroup in translations)
        {
            string value = await GetTranslation(itemGroup, language, default);
            values = values.Add(value);
        }
        return values;
    }

    public async Task<string> GetTranslation(ItemGroup translation, Language language, CancellationToken cancellationToken)
    {
        TranslationCode translationCode = GetCode(translation, _itemGroupConverter);
        return await GetTranslation(translationCode, language, cancellationToken);
    }

    public async Task<string[]> GetTranslations(Language language, params ItemType[] translations)
    {
        string[] values = [];
        foreach (ItemType itemType in translations)
        {
            string value = await GetTranslation(itemType, language, default);
            values = values.Add(value);
        }
        return values;
    }

    public async Task<string> GetTranslation(ItemType translation, Language language, CancellationToken cancellationToken)
    {
        TranslationCode translationCode = GetCode(translation, _itemTypeConverter);
        return await GetTranslation(translationCode, language, cancellationToken);
    }

    public async Task<string[]> GetTranslations(Language language, params Rarity[] translations)
    {
        string[] values = [];
        foreach (Rarity rarity in translations)
        {
            string value = await GetTranslation(rarity, language, default);
            values = values.Add(value);
        }
        return values;
    }

    public async Task<string> GetTranslation(Rarity translation, Language language, CancellationToken cancellationToken)
    {
        TranslationCode translationCode = GetCode(translation, _rarityConverter);
        return await GetTranslation(translationCode, language, cancellationToken);
    }

    private async Task<Dictionary<string, Dictionary<string, string>>> LoadTranslation(string languageCode, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Loading Translation. Code: {code}", languageCode);
        cancellationToken.ThrowIfCancellationRequested();
        Dictionary<string, string> translation = await LoadTranslationFile(languageCode, cancellationToken);
        return new Dictionary<string, Dictionary<string, string>>()
        {
            { languageCode, translation }
        };
    }
    
    private async Task<Dictionary<string, string>> LoadTranslationFile(string languageCode, CancellationToken cancellationToken)
    {
        string fileName = languageCode + ".json";
        cancellationToken.ThrowIfCancellationRequested();
        return await _fileReader.ReadFile<Dictionary<string, string>>(fileName, cancellationToken);
    }

    private static TReturn GetCode<TEnum, TReturn>(TEnum enumKey, IEnumConverter<TEnum, TReturn> enumConverter)
        where TEnum : Enum
    {
        try
        {
            return enumConverter.ConvertFrom(enumKey);
        }
        catch (InvalidOperationException ex)
        {
            const string format = "Key '{0}' is not implemented.";
            string message = string.Format(format, enumKey.ToString());
            throw new InvalidCastException(message, ex);
        }
    }


}
