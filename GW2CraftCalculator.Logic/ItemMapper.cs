using AutoMapper;
using GW2CraftCalculator.Interfaces.Logic;

namespace GW2CraftCalculator.Logic;
public class ItemMapper : IItemMapper
{
    public IMapper Mapper { get; init; }
}
