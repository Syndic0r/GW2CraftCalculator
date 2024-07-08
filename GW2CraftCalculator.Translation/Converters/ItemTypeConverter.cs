using AutoMapper;
using GW2CraftCalculator.Interfaces.Translation;
using GW2CraftCalculator.Models.Enums;
using GW2CraftCalculator.Utils.Converters;
using GW2CraftCalculator.Utils.Extensions;
using Microsoft.Extensions.Logging;

namespace GW2CraftCalculator.Translation.Converters;
public class ItemTypeConverter : BaseConverter, IItemTypeConverter
{
    private readonly IMapper _mapper;
    private readonly ItemType[] _invalidItemTypes;
    public ItemTypeConverter(ILogger<BaseConverter> logger, IEnumMapper enumMapper) : base(logger)
    {
        _mapper = enumMapper.Mapper;
        _invalidItemTypes = 
        [
            ItemType.None
        ];
    }

    public TranslationCode ConvertFrom(ItemType value)
    {
        CheckItemTypeValue(value);
        return _mapper.Map<TranslationCode>(value);
    }

    private void CheckItemTypeValue(ItemType value)
    {
        if (_invalidItemTypes.Contains(value))
        {
            IEnumerable<string> expectedValues = EnumExtensions.GetExpectedValues(" - ", _invalidItemTypes);
            string messages = $"Invalid Item Type! Expected one item type of: {string.Join(", ", expectedValues)}";
            throw new InvalidCastException(messages);
        }
    }
}
