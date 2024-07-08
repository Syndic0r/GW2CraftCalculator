using GW2CraftCalculator.Interfaces.Data;
using GW2CraftCalculator.Models.Data;
using GW2CraftCalculator.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GW2CraftCalculator.Data.Repositories;

public class ItemsRepository : IItemsRepository
{
    private readonly Gw2DataContext _gw2DbContext;
    private readonly ILogger<ItemsRepository> _logger;

    public ItemsRepository(IDbContextFactory<Gw2DataContext> contextFactory, ILogger<ItemsRepository> logger)
    {
        _gw2DbContext = contextFactory.CreateDbContext();
        _logger = logger;
    }

    public async Task<IReadOnlyCollection<MysticForgeRecipe>> GetMysticForgeRecipes()
    {
        _logger.LogDebug("Loading mystic forge recipes from database...");
        List<MysticForgeRecipe> recipes = await _gw2DbContext.MysticForgeRecipes
                                                                .Include(r => r.RecipeInput.InputAmount)
                                                                .Include(r => r.RecipeOutput.OutputAmount)
                                                                .Include(r => r.RecipeOutput.Item)
                                                                .Include(r => ((VendorItem)r.RecipeInput.Item).Cost)
                                                                .Include(r => r.RecipeInput.Item.SalvageOutputs)
                                                                .ToListAsync();
        _logger.LogDebug("Loaded mystic forge recipes: {count}", recipes.Count);
        return recipes.AsReadOnly();
    }

    public async Task<IReadOnlyCollection<SalvageRecipe>> GetSalvageRecipes(IEnumerable<Item> outputItems)
    {
        _logger.LogDebug("Loading salvage recipes from database for {outputItems}", string.Join(", ", outputItems.Select(i => i.Id)));
        IEnumerable<int> outputItemIds = outputItems.Select(oi => oi.Id);
        IEnumerable<int> salvageInputIds = await _gw2DbContext.SalvageRecipes
                                                                .Where(sr => outputItemIds.Contains(sr.SalvageOutput.Item.Id))
                                                                .Select(sr => sr.SalvageInput.Id)
                                                                .ToListAsync();
        _logger.LogDebug("Loaded salvage recipes input ids: {salvageInputIds}", string.Join(", ", salvageInputIds));

        List<SalvageRecipe> recipes = await _gw2DbContext.SalvageRecipes
                                                            .Where(sr => salvageInputIds.Contains(sr.SalvageInput.Id))
                                                            .Include(sr => sr.SalvageInput.Item)
                                                            .Include(sr => ((VendorItemSalvageKitInfinite)sr.SalvageInput.SalvageKit).Cost)
                                                            .Include(r => r.SalvageOutput.Item)
                                                            .ToListAsync();
        _logger.LogDebug("Loaded salvage recipes");

        return recipes.AsReadOnly();
    }


    public async Task<IList<CurrencyConversion>> GetCurrencyConversions()
    {
        _logger.LogDebug("Loading currency conversion from database...");
        List<CurrencyConversion> currencyConversions = await _gw2DbContext.CurrencyConversions.ToListAsync();
        _logger.LogDebug("Loaded currency conversion: {currencyConversions}", string.Join(", ", currencyConversions.Select(c => c.Id)));
        return currencyConversions;
    }

    public async Task<IReadOnlyDictionary<ItemType, IReadOnlyDictionary<ItemGroup, IReadOnlyDictionary<Rarity, IEnumerable<ItemTier>>>>> GetMysticForgeRecipeFilterValues(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var itemTypeGroups = await _gw2DbContext.Items
                                            .Where(i => i.RecipeOutputItems.Count != 0)
                                            .GroupBy(i => i.ItemType)
                                            .ToListAsync(cancellationToken);

        Dictionary<ItemType, IReadOnlyDictionary<ItemGroup, IReadOnlyDictionary<Rarity, IEnumerable<ItemTier>>>> itemSpecs = [];

        foreach (var itemTypeGroup in itemTypeGroups)
        {
            if (cancellationToken.IsCancellationRequested) break;
            Dictionary<ItemGroup, IReadOnlyDictionary<Rarity, IEnumerable<ItemTier>>> itemGroupMap = [];
            var itemGroups = itemTypeGroup.GroupBy(ig => ig.ItemGroup);
            foreach (var itemGroup in itemGroups)
            {
                if (cancellationToken.IsCancellationRequested) break;
                Dictionary<Rarity, IEnumerable<ItemTier>> raritiesMap = [];
                var rarities = itemGroup.GroupBy(it => it.Rarity);
                foreach (var rarity in rarities)
                {
                    if (cancellationToken.IsCancellationRequested) break;
                    IEnumerable<ItemTier> itemTiers = rarity.Select(r => r.Tier).Distinct();
                    raritiesMap.Add(rarity.Key, itemTiers);
                }
                itemGroupMap.Add(itemGroup.Key, raritiesMap.AsReadOnly());
            }
            itemSpecs.Add(itemTypeGroup.Key, itemGroupMap.AsReadOnly());
        }

        cancellationToken.ThrowIfCancellationRequested();

        return itemSpecs.AsReadOnly();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _gw2DbContext.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
