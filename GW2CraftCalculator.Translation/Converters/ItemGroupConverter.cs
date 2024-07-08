using AutoMapper;
using GW2CraftCalculator.Interfaces.Translation;
using GW2CraftCalculator.Models.Enums;
using GW2CraftCalculator.Utils.Converters;
using GW2CraftCalculator.Utils.Extensions;
using Microsoft.Extensions.Logging;

namespace GW2CraftCalculator.Translation.Converters;
public class ItemGroupConverter : BaseConverter, IItemGroupConverter
{
    private readonly IMapper _mapper;

    private readonly ItemGroup[] _invalidItemGroups;

    public ItemGroupConverter(ILogger<BaseConverter> logger, IEnumMapper enumMapper) : base(logger) 
    {
        _mapper = enumMapper.Mapper;
        _invalidItemGroups =
        [
            ItemGroup.None,
            ItemGroup.Luck
        ];
    }

    public TranslationCode ConvertFrom(ItemGroup value)
    {
        CheckItemGroupValue(value);
        return _mapper.Map<TranslationCode>(value);
    }

    private void CheckItemGroupValue(ItemGroup value)
    {
        if (_invalidItemGroups.Contains(value))
        {
            IEnumerable<string> expectedValues = EnumExtensions.GetExpectedValues(" - ", _invalidItemGroups);
            string messages = $"Invalid Item Group! Expected one item group of: {string.Join(", ", expectedValues)}";
            throw new InvalidCastException(messages);
        }
    }
}
