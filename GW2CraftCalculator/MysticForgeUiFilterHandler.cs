using GW2CraftCalculator.Interfaces;
using GW2CraftCalculator.Interfaces.Data;
using GW2CraftCalculator.Interfaces.Translation;
using GW2CraftCalculator.Models.Enums;
using GW2CraftCalculator.Models.Logic;
using GW2CraftCalculator.Utils.Logging;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace GW2CraftCalculator;
public class MysticForgeUiFilterHandler : IMysticForgeUiFilterHandler
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private readonly ILogger<MysticForgeUiFilterHandler> _logger;
    private readonly IItemsRepository _itemsRepository;
    private readonly ITranslationsProcessor _translationsProcessor;

    private IReadOnlyDictionary<ItemType, IReadOnlyDictionary<ItemGroup, IReadOnlyDictionary<Rarity, IEnumerable<ItemTier>>>> _filters;

    private Dictionary<string, ItemType> _textItemTypeMapping;
    private Dictionary<string, ItemGroup> _textItemGroupMapping;
    private Dictionary<string, ItemTier> _textItemTierMapping;
    private Dictionary<string, Rarity> _textRarityMapping;

    private Dictionary<ItemType, string> _itemTypeTextMapping;
    private Dictionary<ItemGroup, string> _itemGroupTextMapping;
    private Dictionary<ItemTier, string> _itemTierTextMapping;
    private Dictionary<Rarity, string> _rarityTextMapping;

    private MysticForgeFilter? _currentFilter;
    private Dictionary<int, MysticForgeFilter> _oldFilterVersions;
    private int _currentFilterVersion;

    private bool _isSetup;

    public MysticForgeUiFilterHandler(ILogger<MysticForgeUiFilterHandler> logger, IItemsRepository itemsRepository, ITranslationsProcessor translationsProcessor)
    {
        _logger = logger;
        _itemsRepository = itemsRepository;
        _translationsProcessor = translationsProcessor;
        _isSetup = false;
        _currentFilterVersion = 0;
    }

    public async Task Setup(Language language, CancellationToken cancellationToken)
    {
        if (_isSetup)
        {
            return;
        }

        await InitFilterStructur(cancellationToken);

        HashSet<ItemType> itemTypes = [];
        HashSet<ItemGroup> itemGroups = [];
        HashSet<Rarity> rarities = [];
        HashSet<ItemTier> itemTiers = [];

        itemTypes.UnionWith(_filters.Keys);
        cancellationToken.ThrowIfCancellationRequested();
        foreach (var itemGroup in _filters.Values)
        {
            if (cancellationToken.IsCancellationRequested) break;
            itemGroups.UnionWith(itemGroup.Keys);
            foreach (var rarity in itemGroup.Values)
            {
                if (cancellationToken.IsCancellationRequested) break;
                rarities.UnionWith(rarity.Keys);
                foreach (var itemTier in rarity.Values)
                {
                    if (cancellationToken.IsCancellationRequested) break;
                    itemTiers.UnionWith(itemTier.OrderBy(t => (int)t));
                }
            }
        }

        cancellationToken.ThrowIfCancellationRequested();
        await SetupItemTypes(itemTypes, language, cancellationToken);
        await SetupItemGroup(itemGroups, language, cancellationToken);
        await SetupRarities(rarities, language, cancellationToken);
        SetupTiers(itemTiers, cancellationToken);
        _isSetup = true;
    }

    public async Task<IReadOnlyDictionary<string, IEnumerable<string>>> GetItemTypeFilterGroup(Language language, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await Setup(language, cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();
        _logger.LogDebug("Creating item type filter groups with language {language}", language.ToString());
        string itemTypesTranslation = await _translationsProcessor.GetTranslation(TranslationCode.ItemTypes, language, cancellationToken);

        Dictionary<string, IEnumerable<string>> filterGroup = new()
        {
            { itemTypesTranslation, _textItemTypeMapping.Keys }
        };

        _logger.LogDebug("Created filter groups {filterGroups}", filterGroup.ConvertReadable());

        return filterGroup.AsReadOnly();
    }

    public async Task<IReadOnlyDictionary<string, IEnumerable<string>>> GetItemGroupFilterGroup(Language language, IEnumerable<string> configuredFilters, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await Setup(language, cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();
        _logger.LogDebug("Creating item group filter groups with language {language}", language.ToString());
        Task<string> itemGroupTranslation = _translationsProcessor.GetTranslation(TranslationCode.ItemGroups, language, cancellationToken);

        ReadOnlyCollection<ItemType> configuredItemTypes = GetConfiguredValues(configuredFilters, _textItemTypeMapping, out _);

        HashSet<string> itemGroups = [];
        foreach(var itemType in GetMatchedValue(configuredItemTypes, _filters))
        {
            if (cancellationToken.IsCancellationRequested) break;
            IEnumerable<string> itemGoupTexts = _itemGroupTextMapping.Where(m => itemType.ContainsKey(m.Key)).Select(m => m.Value);
            itemGroups.UnionWith(itemGoupTexts);
        }

        cancellationToken.ThrowIfCancellationRequested();

        Dictionary<string, IEnumerable<string>> filterGroup = new()
        {
            { await itemGroupTranslation, itemGroups }
        };

        _logger.LogDebug("Created filter groups {filterGroups}", filterGroup.ConvertReadable());

        return filterGroup.AsReadOnly();
    }

    public async Task<IReadOnlyDictionary<string, IEnumerable<string>>> GetRarityFilterGroup(Language language, IEnumerable<string> configuredFilters, CancellationToken cancellationToken)
    {
        await Setup(language, cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();
        _logger.LogDebug("Creating item rarities filter groups with language {language}", language.ToString());
        Task<string> raritesTranslation = _translationsProcessor.GetTranslation(TranslationCode.Rarities, language, cancellationToken);

        ReadOnlyCollection<ItemType> configuredItemTypes = GetConfiguredValues(configuredFilters, _textItemTypeMapping, out _);
        ReadOnlyCollection<ItemGroup> configuredItemGroups = GetConfiguredValues(configuredFilters, _textItemGroupMapping, out _);

        HashSet<string> rarities = [];
        foreach (var itemType in GetMatchedValue(configuredItemTypes, _filters))
        {
            if (cancellationToken.IsCancellationRequested) break;
            foreach (var itemGroup in GetMatchedValue(configuredItemGroups, itemType))
            {
                if (cancellationToken.IsCancellationRequested) break;
                IEnumerable<string> itemRarityTexts = _rarityTextMapping.Where(m => itemGroup.ContainsKey(m.Key)).Select(m => m.Value);
                rarities.UnionWith(itemRarityTexts);
            }
        }

        cancellationToken.ThrowIfCancellationRequested();

        Dictionary<string, IEnumerable<string>> filterGroup = new()
        {
            { await raritesTranslation, rarities }
        };

        _logger.LogDebug("Created filter groups {filterGroups}", filterGroup.ConvertReadable());

        return filterGroup.AsReadOnly();
    }

    public async Task<IReadOnlyDictionary<string, IEnumerable<string>>> GetTierFilterGroup(Language language, IEnumerable<string> configuredFilters, CancellationToken cancellationToken)
    {
        await Setup(language, cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();
        _logger.LogDebug("Creating item tiers filter groups with language {language}", language.ToString());
        Task<string> tiersTranslation = _translationsProcessor.GetTranslation(TranslationCode.Tiers, language, cancellationToken);

        ReadOnlyCollection<ItemType> configuredItemTypes = GetConfiguredValues(configuredFilters, _textItemTypeMapping, out _);
        ReadOnlyCollection<ItemGroup> configuredItemGroups = GetConfiguredValues(configuredFilters, _textItemGroupMapping, out _);
        ReadOnlyCollection<Rarity> configuredRarities = GetConfiguredValues(configuredFilters, _textRarityMapping, out _);

        HashSet<string> tiers = [];
        foreach (var itemType in GetMatchedValue(configuredItemTypes, _filters))
        {
            if (cancellationToken.IsCancellationRequested) break;
            foreach (var itemGroup in GetMatchedValue(configuredItemGroups, itemType))
            {
                if (cancellationToken.IsCancellationRequested) break;
                foreach (var rarity in GetMatchedValue(configuredRarities, itemGroup))
                {
                    if (cancellationToken.IsCancellationRequested) break;
                    IEnumerable<string> itemTierTexts = _itemTierTextMapping.Where(m => rarity.Contains(m.Key)).Select(m => m.Value);
                    tiers.UnionWith(itemTierTexts);
                }
            }
        }

        cancellationToken.ThrowIfCancellationRequested();

        Dictionary<string, IEnumerable<string>> filterGroup = new()
        {
            { await tiersTranslation, tiers }
        };

        _logger.LogDebug("Created filter groups {filterGroups}", filterGroup.ConvertReadable());

        return filterGroup.AsReadOnly();
    }


    public MysticForgeFilter? GetFilter(int? filterVersion = null)
    {
        if (filterVersion == null)
        {
            return _currentFilter;
        }

        if (filterVersion > _currentFilterVersion)
        {
            return null;
        }

        if (filterVersion == _currentFilterVersion)
        {
            return _currentFilter;
        }

        if (!_oldFilterVersions.TryGetValue(filterVersion.Value, out MysticForgeFilter? filter))
        {
            return null;
        }

        return filter;
    }

    public async Task SetFilter(Language language, IEnumerable<string> configuredFilters, CancellationToken cancellationToken)
    {
        await Setup(language, cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();
        _logger.LogDebug("Setting filter. Values: {values}", configuredFilters.ConvertReadable());
        SetNewCurrentFilter(configuredFilters);
    }

    [MemberNotNull(nameof(_currentFilter))]
    private void SetNewCurrentFilter(IEnumerable<string> configuredFilters)
    {
        ReadOnlyCollection<ItemType> configuredItemTypes = GetConfiguredValues(configuredFilters, _textItemTypeMapping, out List<string> foundItemTypes);
        IEnumerable<string> filterWithoutItemTypes = configuredFilters.Except(foundItemTypes);
        ReadOnlyCollection<ItemGroup> configuredItemGroups = GetConfiguredValues(filterWithoutItemTypes, _textItemGroupMapping, out List<string> foundItemGroup);
        IEnumerable<string> filterWithoutItemTypesGroups = filterWithoutItemTypes.Except(foundItemGroup);
        ReadOnlyCollection<Rarity> configuredRarities = GetConfiguredValues(filterWithoutItemTypesGroups, _textRarityMapping, out List<string> foundRarities);
        IEnumerable<string> filterWithItemTiersNames = filterWithoutItemTypesGroups.Except(foundRarities);
        ReadOnlyCollection<ItemTier> configuredTiers = GetConfiguredItemTiers(filterWithItemTiersNames, out List<string> itemTiers);
        IEnumerable<string> configuredNames = filterWithItemTiersNames.Except(itemTiers);
        SetCurrentFilter(configuredItemTypes, configuredItemGroups, configuredRarities, configuredTiers, configuredNames, incrementVersion: true, overrideCurrent: true);
    }

    [MemberNotNull(nameof(_currentFilter))]
    private void SetCurrentFilter(IEnumerable<ItemType>? itemTypes = null, IEnumerable<ItemGroup>? itemGroups = null, 
                            IEnumerable<Rarity>? rarities = null, IEnumerable<ItemTier>? itemTiers = null, 
                            IEnumerable<string>? itemNames = null, bool incrementVersion = false, bool overrideCurrent = false)
    {
        if (incrementVersion && _currentFilterVersion > 0)
        {
            _oldFilterVersions ??= [];
            _oldFilterVersions.Add(_currentFilterVersion, _currentFilter!);
        }

        if (incrementVersion)
        {
            _currentFilterVersion += 1;
        }

        if (overrideCurrent)
        {
            _currentFilter = null;
        }

        if (_currentFilter == null)
        {
            _currentFilter = new()
            {
                ItemTypes = itemTypes ?? [],
                ItemGroups = itemGroups ?? [],
                Rarities = rarities ?? [],
                ItemTiers = itemTiers ?? [],
                ItemNames = itemNames ?? []
            };
            return;
        }

        _currentFilter.TrySetItemTypes(itemTypes);
        _currentFilter.TrySetItemGroups(itemGroups);
        _currentFilter.TrySetRarities(rarities);
        _currentFilter.TrySetItemTiers(itemTiers);
        _currentFilter.TrySetItemNames(itemNames);
    }

    private static IEnumerable<TValue> GetMatchedValue<TKey, TValue>(IEnumerable<TKey> configuredValues, IReadOnlyDictionary<TKey, TValue> filter) where TKey : struct, Enum
    {
        IEnumerable<TKey> keys;
        if (configuredValues.Any())
        {
            keys = filter.Keys.Where(configuredValues.Contains);
        }
        else
        {
            keys = filter.Keys;
        }

        foreach (var key in keys)
        {
            yield return filter[key];
        }
    }

    private static ReadOnlyCollection<T> GetConfiguredValues<T>(IEnumerable<string> filters, Dictionary<string, T> matchingDictionary, out List<string> foundValues) where T : struct, Enum
    {
        List<T> configuredTypes = [];
        foundValues = [];
        foreach (var entry in matchingDictionary)
        {
            string? foundValue = filters.FirstOrDefault(f => f.Equals(entry.Key, StringComparison.OrdinalIgnoreCase));
            if (foundValue != null)
            {
                configuredTypes.Add(entry.Value);
                foundValues.Add(foundValue);
                continue;
            }

            foundValue = filters.FirstOrDefault(f => f.Equals(entry.Key.Replace(" ", ""), StringComparison.OrdinalIgnoreCase));
            if (foundValue != null)
            {
                configuredTypes.Add(entry.Value);
                foundValues.Add(foundValue);
                continue;
            }

            foundValue = filters.FirstOrDefault(f => f.Equals(entry.Key.Replace(' ', '_'), StringComparison.OrdinalIgnoreCase));
            if (foundValue != null)
            {
                configuredTypes.Add(entry.Value);
                foundValues.Add(foundValue);
            }
        }
        return configuredTypes.AsReadOnly();
    }

    private ReadOnlyCollection<ItemTier> GetConfiguredItemTiers(IEnumerable<string> tierFilter, out List<string> foundValues)
    {
        List<ItemTier> configuredTiers = [];
        foundValues = [];
        foreach (var entry in _textItemTierMapping)
        {
            string? foundValue = tierFilter.FirstOrDefault(f => f.Equals(entry.Key, StringComparison.OrdinalIgnoreCase));
            if (foundValue != null)
            {
                configuredTiers.Add(entry.Value);
                foundValues.Add(foundValue);
                continue;
            }

            foundValue = tierFilter.FirstOrDefault(f => f.Equals(((int)entry.Value).ToString(), StringComparison.OrdinalIgnoreCase));
            if (foundValue != null)
            {
                configuredTiers.Add(entry.Value);
                foundValues.Add(foundValue);
            }
        }
        return configuredTiers.AsReadOnly();
    }

    private async Task InitFilterStructur(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _filters = await _itemsRepository.GetMysticForgeRecipeFilterValues(cancellationToken);
        _logger.LogDebug("Set filter structur {filterStructur}", _filters.ConvertReadable());
        ArgumentNullException.ThrowIfNull(_filters, nameof(_filters));
    }

    private async Task SetupItemTypes(IEnumerable<ItemType> itemTypes, Language language, CancellationToken cancellationToken)
    {
        _textItemTypeMapping = [];
        _itemTypeTextMapping = [];
        foreach (ItemType itemType in itemTypes)
        {
            if (cancellationToken.IsCancellationRequested) break;
            string translation = await _translationsProcessor.GetTranslation(itemType, language, cancellationToken);
            _textItemTypeMapping.Add(translation, itemType);
            _itemTypeTextMapping.Add(itemType, translation);
        }
    }

    private async Task SetupItemGroup(IEnumerable<ItemGroup> itemGroups, Language language, CancellationToken cancellationToken)
    {
        _textItemGroupMapping = [];
        _itemGroupTextMapping = [];
        foreach (ItemGroup itemGroup in itemGroups)
        {
            if (cancellationToken.IsCancellationRequested) break;
            string translation = await _translationsProcessor.GetTranslation(itemGroup, language, cancellationToken);
            _textItemGroupMapping.Add(translation, itemGroup);
            _itemGroupTextMapping.Add(itemGroup, translation);
        }
        cancellationToken.ThrowIfCancellationRequested();
    }

    private async Task SetupRarities(IEnumerable<Rarity> rarities, Language language, CancellationToken cancellationToken)
    {
        _textRarityMapping = [];
        _rarityTextMapping = [];
        foreach (Rarity rarity in rarities)
        {
            if (cancellationToken.IsCancellationRequested) break;
            string translation = await _translationsProcessor.GetTranslation(rarity, language, cancellationToken);
            _textRarityMapping.Add(translation, rarity);
            _rarityTextMapping.Add(rarity, translation);
        }
        cancellationToken.ThrowIfCancellationRequested();
    }

    private void SetupTiers(IEnumerable<ItemTier> itemTiers, CancellationToken cancellationToken)
    {
        _textItemTierMapping = [];
        _itemTierTextMapping = [];
        foreach (ItemTier itemTier in itemTiers)
        {
            if (cancellationToken.IsCancellationRequested) break;
            _textItemTierMapping.Add(itemTier.ToString(), itemTier);
            _itemTierTextMapping.Add(itemTier, itemTier.ToString());
        }
        cancellationToken.ThrowIfCancellationRequested();
    }
}
