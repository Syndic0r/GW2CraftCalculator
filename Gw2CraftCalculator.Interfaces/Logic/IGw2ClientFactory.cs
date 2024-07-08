using GW2CraftCalculator.Models.Enums;
using Gw2Sharp;

namespace GW2CraftCalculator.Interfaces.Logic;

public interface IGw2ClientFactory
{
    public IGw2Client CreateClient(Language language = Language.English);
}
