using GW2CraftCalculator.Models.Enums;
using GW2CraftCalculator.Models.Logic;
using GW2CraftCalculator.Models.ViewModels;

namespace GW2CraftCalculator.Interfaces.Logic;

public interface ILogicProcessor
{
    public Task<IEnumerable<ItemView>> GetPricedRecipes(Language language, MysticForgeFilter? filter, int runConfig);
}
