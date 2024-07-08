using GW2CraftCalculator.Interfaces.Data;

namespace GW2CraftCalculator.Data.Repositories;

public class UserConfigurationRepository : IUserConfigurationRepository
{
    private readonly Gw2DataContext _context;

    public UserConfigurationRepository(Gw2DataContext context)
    {
        _context = context;
    }
}
