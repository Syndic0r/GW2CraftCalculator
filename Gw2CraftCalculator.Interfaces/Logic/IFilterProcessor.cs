using GW2CraftCalculator.Models.Enums;
using GW2CraftCalculator.Models.Logic;

namespace GW2CraftCalculator.Interfaces.Logic;
public interface IFilterProcessor
{
    public Task SetFilter(Language language, IEnumerable<string> configuredFilters, CancellationToken cancellationToken);
    public MysticForgeFilter? GetFilter(int? filterVersion = null);
}
