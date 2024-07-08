using GW2CraftCalculator.Interfaces.Logic;
using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Interfaces;
public interface IMysticForgeUiFilterHandler : IFilterProcessor
{
    public Task Setup(Language language, CancellationToken cancellationToken);
    public Task<IReadOnlyDictionary<string, IEnumerable<string>>> GetItemTypeFilterGroup(Language language, CancellationToken cancellationToken);
    public Task<IReadOnlyDictionary<string, IEnumerable<string>>> GetItemGroupFilterGroup(Language language, IEnumerable<string> configuredFilters, CancellationToken cancellationToken);
    public Task<IReadOnlyDictionary<string, IEnumerable<string>>> GetRarityFilterGroup(Language language, IEnumerable<string> configuredFilters, CancellationToken cancellationToken);
    public Task<IReadOnlyDictionary<string, IEnumerable<string>>> GetTierFilterGroup(Language language, IEnumerable<string> configuredFilters, CancellationToken cancellationToken);
}
