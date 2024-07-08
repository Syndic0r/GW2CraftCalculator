using GW2CraftCalculator.Models.Data;
using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Interfaces.Data;

public interface IItemsRepository : IDisposable
{

    public Task<IReadOnlyCollection<MysticForgeRecipe>> GetMysticForgeRecipes();

    public Task<IReadOnlyCollection<SalvageRecipe>> GetSalvageRecipes(IEnumerable<Item> outputItems);

    public Task<IList<CurrencyConversion>> GetCurrencyConversions();

    public Task<IReadOnlyDictionary<ItemType, IReadOnlyDictionary<ItemGroup, IReadOnlyDictionary<Rarity, IEnumerable<ItemTier>>>>> GetMysticForgeRecipeFilterValues(CancellationToken cancellationToken);
}
