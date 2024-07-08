using GW2CraftCalculator.Models.Data;
using Gw2Sharp.WebApi.V2.Models;
using Gw2Item = Gw2Sharp.WebApi.V2.Models.Item;
using Item = GW2CraftCalculator.Models.Data.Item;
using Currency = GW2CraftCalculator.Models.Enums.Currency;

namespace GW2CraftCalculator.Logic.ViewModelCreators;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8601 // Possible null reference assignment.
public class ItemViewCreator<TCurrentItem> : ItemViewDefaultCreator where TCurrentItem : class
{
    public ItemViewCreator(ItemViewDefaultCreator creator) : base(creator)
    {
        IsRoot = false;
    }

    public ItemViewCreator(ItemViewCreator<TCurrentItem> creator) : base(creator)
    {
        IsRoot = false;
        CurrentItem = creator.CurrentItem;
    }

    public TCurrentItem CurrentItem { get; init; }

    public bool IsRoot { get; init; }

    public ItemViewCreator<T> Clone<T>(T? currentItem = default, bool isRoot = false) where T : class
    {
        if (currentItem == null && CurrentItem is T item)
        {
            currentItem = item;
        }

        return new ItemViewCreator<T>(this)
        {
            CurrentItem = currentItem,
            IsRoot = isRoot
        };
    }

    public Gw2Item GetGw2Item(Func<TCurrentItem, Item>? itemSelector = null)
    {
        Item item;
        if (itemSelector != null)
        {
            item = itemSelector.Invoke(CurrentItem);
        }
        else
        {
            item = GetCurrentItemConverted<Item>();
        }

        Gw2Item gw2Item = Items.First(i => i.Id == item.Id);
        return gw2Item;
    }

    public CommercePrice? GetUnitPrice(Func<TCurrentItem, Item>? itemSelector = null)
    {
        Item item;
        if (itemSelector != null)
        {
            item = itemSelector.Invoke(CurrentItem);
        }
        else
        {
            item = GetCurrentItemConverted<Item>();
        }
        return GetUnitPrice(item, IsRoot);
    }

    private protected decimal GetVendorCostGoldConverted(VendorCost vendorCost)
    {
        ArgumentNullException.ThrowIfNull(CurrencyConversions, nameof(CurrencyConversions));
        decimal vendorCostGoldConverted;
        if (vendorCost.CurrencyType != Currency.Coin)
        {
            CurrencyConversion? currencyConversion = CurrencyConversions.FirstOrDefault(cc => cc.BaseCurrencyType == vendorCost.CurrencyType && cc.ConversionCurrencyType == Currency.Coin);

            if (currencyConversion == null)
            {
                return 0;
            }

            decimal conversionFactor = (decimal)currencyConversion.BaseCurrencyAmount / currencyConversion.ConversionCurrencyAmount;
            vendorCostGoldConverted = vendorCost.Amount / conversionFactor;
        }
        else
        {
            vendorCostGoldConverted = vendorCost.Amount;
        }

        return vendorCostGoldConverted;
    }

    private protected T GetCurrentItemConverted<T>() where T : class
    {
        if (CurrentItem is not T item)
        {
            string message = $"Failed to convert '{nameof(CurrentItem)}' of Type '{CurrentItem.GetType()}' to Type '{typeof(T)}'.";
            throw new InvalidCastException(message);
        }
        return item;
    }
}
