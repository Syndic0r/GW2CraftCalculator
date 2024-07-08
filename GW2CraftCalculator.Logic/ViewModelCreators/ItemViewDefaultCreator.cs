using Gw2Sharp.WebApi.V2.Models;
using GW2CraftCalculator.Models.Data;
using Item = GW2CraftCalculator.Models.Data.Item;
using Gw2Item = Gw2Sharp.WebApi.V2.Models.Item;
using GW2CraftCalculator.Models.Logic;
using ItemType = GW2CraftCalculator.Models.Enums.ItemType;
using GW2CraftCalculator.Models.Enums;
using System.Linq;

namespace GW2CraftCalculator.Logic.ViewModelCreators;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class ItemViewDefaultCreator
{
    public ItemViewDefaultCreator(IEnumerable<MysticForgeRecipe> recipes,
                                              IEnumerable<SalvageRecipe> salvageRecipes,
                                              IEnumerable<CommercePrices>? prices,
                                              IEnumerable<Gw2Item>? items,
                                              IEnumerable<CurrencyConversion>? currencyConversions,
                                              MysticForgeFilter? filter)
    {
        Recipes = recipes;
        SalvageRecipes = salvageRecipes;
        Prices = prices;
        Items = items;
        CurrencyConversions = currencyConversions;
        Filter = filter;
    }

    private protected ItemViewDefaultCreator(ItemViewDefaultCreator creator)
    {
        Items = creator.Items;
        Prices = creator.Prices;
        Recipes = creator.Recipes;
        SalvageRecipes = creator.SalvageRecipes;
        CurrencyConversions = creator.CurrencyConversions;
        Filter = creator.Filter;
    }

    public MysticForgeFilter? Filter { get; set; }
    public IEnumerable<MysticForgeRecipe> Recipes { get; private set; }
    public IEnumerable<SalvageRecipe> SalvageRecipes { get; private set; }
    private protected IEnumerable<CommercePrices>? Prices { get; private set; }
    private protected IEnumerable<Gw2Item>? Items { get; private set; }
    private protected IEnumerable<CurrencyConversion>? CurrencyConversions { get; private set; }

    public ItemViewDefaultCreator Clone()
    {
        return new ItemViewDefaultCreator(this);
    }

    internal ItemViewDefaultCreator CacheClone(IEnumerable<CommercePrices>? prices, IEnumerable<Gw2Item>? items, IEnumerable<CurrencyConversion>? currencyConversions, MysticForgeFilter? filter)
    {
        return new ItemViewDefaultCreator(Recipes, SalvageRecipes, prices, items, currencyConversions, filter);
    }

    internal bool MatchItemType(ItemType itemType)
    {
        if (Filter == null || Filter.ItemTypes == null || !Filter.ItemTypes.Any())
        {
            return true;
        }
        return Filter.ItemTypes.Contains(itemType);
    }

    internal bool MatchItemGroup(ItemGroup itemGroup)
    {
        if (Filter == null || Filter.ItemGroups == null || !Filter.ItemGroups.Any())
        {
            return true;
        }
        return Filter.ItemGroups.Contains(itemGroup);
    }

    internal bool MatchRarity(Rarity rarity)
    {
        if (Filter == null || Filter.Rarities == null || !Filter.Rarities.Any())
        {
            return true;
        }
        return Filter.Rarities.Contains(rarity);
    }

    internal bool MatchTier(ItemTier tier)
    {
        if (Filter == null || Filter.ItemTiers == null || !Filter.ItemTiers.Any())
        {
            return true;
        }
        return Filter.ItemTiers.Contains(tier);
    }

    internal bool MatchItemName(int itemId)
    {
        if (Filter == null || Filter.ItemNames == null || !Filter.ItemNames.Any())
        {
            return true;
        }

        Gw2Item item = Items!.First(i => i.Id == itemId);

        foreach(string name in Filter.ItemNames)
        {
            if (item.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) 
                return true;
            if (item.Name.Replace(" ", "").Contains(name, StringComparison.OrdinalIgnoreCase)) 
                return true;
            if(item.Name.Replace(' ', '_').Contains(name, StringComparison.OrdinalIgnoreCase))
                return true;
        }

        return false;
    }

    public IEnumerable<int> SelectSalvageInputIds(int itemId)
    {
        IEnumerable<int> salvageInputIds = SalvageRecipes
                                            .Where(sr => sr.SalvageOutput.Item.Id == itemId)
                                            .Select(sr => sr.SalvageInput.Id);
        return salvageInputIds;
    }

    private protected CommercePrice? GetUnitPrice(Item item, bool isRoot = false)
    {
        ArgumentNullException.ThrowIfNull(Prices, nameof(Prices));
        CommercePrices? currentPrices = Prices.FirstOrDefault(p => p.Id == item.Id);
        CommercePrice? unitPrice;
        if (isRoot)
        {
            unitPrice = currentPrices?.Sells;
        }
        else
        {
            unitPrice = currentPrices?.Buys;
        }
        return unitPrice;
    }
}
