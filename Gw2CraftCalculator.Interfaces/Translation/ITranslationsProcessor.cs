using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Interfaces.Translation;
public interface ITranslationsProcessor
{
    public string GetCurrencyTranslation(Currency currency);

    public void TrySetCurrencyTranslations(IEnumerable<KeyValuePair<int, string>> currencyTranslations, bool forceOverride = false);

    public bool TrySetCurrencyTranslation(int currencyId, string translation, bool forceOverride = false);

    public Task<string> GetTranslation(TranslationCode translation, Language language);

    public Task<string[]> GetTranslations(Language language, params TranslationCode[] translations);

    public Task<string> GetTranslation(TranslationCode translation, Language language, CancellationToken cancellationToken);

    public Task<string[]> GetTranslations(Language language, params ItemGroup[] translations);

    public Task<string> GetTranslation(ItemGroup translation, Language language, CancellationToken cancellationToken);

    public Task<string[]> GetTranslations(Language language, params ItemType[] translations);

    public Task<string> GetTranslation(ItemType translation, Language language, CancellationToken cancellationToken);

    public Task<string[]> GetTranslations(Language language, params Rarity[] translations);

    public Task<string> GetTranslation(Rarity translation, Language language, CancellationToken cancellationToken);
}
