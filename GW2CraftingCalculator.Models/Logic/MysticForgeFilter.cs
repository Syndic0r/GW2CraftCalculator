using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Models.Logic;
public record MysticForgeFilter
{
    private IEnumerable<ItemType>? _itemTypes;
    public IEnumerable<ItemType>? ItemTypes
    {
        get => _itemTypes;
        init => _itemTypes = value;
    }

    private IEnumerable<ItemGroup>? _itemGroups;
    public IEnumerable<ItemGroup>? ItemGroups
    {
        get => _itemGroups;
        init => _itemGroups = value;
    }

    private IEnumerable<ItemTier>? _itemTiers;
    public IEnumerable<ItemTier>? ItemTiers
    {
        get => _itemTiers;
        init => _itemTiers = value;
    }

    private IEnumerable<Rarity>? _rarities;
    public IEnumerable<Rarity>? Rarities
    {
        get => _rarities;
        init => _rarities = value;
    }

    private IEnumerable<string>? _itemNames;
    public IEnumerable<string>? ItemNames
    {
        get => _itemNames;
        init => _itemNames = value;
    }

    public bool TrySetItemTypes(IEnumerable<ItemType>? itemTypes)
    {
        if (itemTypes == null)
        {
            return false;
        }

        if (_itemTypes != null && _itemTypes.Any())
        {
            return false;
        }

        _itemTypes = itemTypes;
        return true;
    }

    public bool TrySetItemGroups(IEnumerable<ItemGroup>? itemGroups)
    {
        if (itemGroups == null)
        {
            return false;
        }

        if (_itemGroups != null && _itemGroups.Any())
        {
            return false;
        }

        _itemGroups = itemGroups;
        return true;
    }

    public bool TrySetRarities(IEnumerable<Rarity>? rarities)
    {
        if (rarities == null)
        {
            return false;
        }

        if (_rarities != null && _rarities.Any())
        {
            return false;
        }

        _rarities = rarities;
        return true;
    }

    public bool TrySetItemTiers(IEnumerable<ItemTier>? itemTiers)
    {
        if (itemTiers == null)
        {
            return false;
        }

        if (_itemTiers != null && _itemTiers.Any())
        {
            return false;
        }

        _itemTiers = itemTiers;
        return true;
    }

    public bool TrySetItemNames(IEnumerable<string>? itemNames)
    {
        if (itemNames == null)
        {
            return false;
        }

        if (_itemNames != null && _itemNames.Any())
        {
            return false;
        }

        _itemNames = itemNames;
        return true;
    }
}
