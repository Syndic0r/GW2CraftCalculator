using AutoMapper;
using GW2CraftCalculator.Interfaces.Translation;

namespace GW2CraftCalculator.Translation;
public class EnumMapper : IEnumMapper
{
    public IMapper Mapper { get; init; }
}
