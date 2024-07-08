using GW2CraftCalculator.Interfaces.Logic;
using GW2CraftCalculator.Interfaces.Utils;
using GW2CraftCalculator.Models.Enums;
using Gw2Sharp;
using Gw2Sharp.WebApi;

namespace GW2CraftCalculator.Logic.Factories;

public class Gw2ClientFactory : IGw2ClientFactory
{
    private readonly ILocaleConverter _localeConverter;

    public Gw2ClientFactory(ILocaleConverter localeConverter)
    {
        _localeConverter = localeConverter;
    }

    public IGw2Client CreateClient(Language language = Language.English)
    {
        Locale locale = _localeConverter.ConvertFrom(language);

        return new Gw2Client(new Connection(locale));
    }
}
