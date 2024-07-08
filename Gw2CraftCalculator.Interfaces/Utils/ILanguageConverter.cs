using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Interfaces.Utils;
public interface ILanguageConverter : IEnumConverter<Language, string>
{
    public Language ConvertFrom(string languageCode);
}
