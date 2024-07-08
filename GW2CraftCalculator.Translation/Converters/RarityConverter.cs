using AutoMapper;
using GW2CraftCalculator.Interfaces.Translation;
using GW2CraftCalculator.Models.Enums;
using GW2CraftCalculator.Utils.Converters;
using Microsoft.Extensions.Logging;

namespace GW2CraftCalculator.Translation.Converters;
public class RarityConverter : BaseConverter, IRarityConverter
{
    private readonly IMapper _mapper;
    public RarityConverter(ILogger<BaseConverter> logger, IEnumMapper enumMapper) : base(logger)
    {
        _mapper = enumMapper.Mapper;
    }

    public TranslationCode ConvertFrom(Rarity value)
    {
        return _mapper.Map<TranslationCode>(value);
    }
}
