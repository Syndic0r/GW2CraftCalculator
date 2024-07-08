using GW2CraftCalculator.Models.Enums;

namespace GW2CraftCalculator.Models.ViewModels;
public class ItemView
{
    public ItemView()
    {
        _amount = 1;
    }

    public int Id { get; set; }
    public string DisplayName { get; set; }
    public string Name { get; set; }
    public ItemTier Tier { get; set; }
    public Rarity Rarity { get; set; }
    public ItemGroup ItemGroup { get; set; }
    public ItemType ItemType { get; set; }
    public ItemSpecifications Specifications { get; set; }

    public decimal Amount 
    { 
        get => ConvertValueFormat(_amount); 
        set => _amount = value; 
    }
    private decimal _amount;

    public decimal OverproducedAmount 
    { 
        get => ConvertValueFormat(_overproducedAmount); 
        private set => _overproducedAmount = value;  
    }
    private decimal _overproducedAmount;

    public ItemCostView Cost { get; set; }
    public HashSet<ItemView> ComposedItems { get; set; }

    public virtual Dictionary<Currency, decimal>? GetTotalValues()
    {
        if (ComposedItems == null)
        {
            KeyValuePair<Currency, decimal>? totalValue = GetTotalValue();
            if (totalValue == null)
            {
                return null;
            }

            return new Dictionary<Currency, decimal>([totalValue.Value]);
        }

        Dictionary<Currency, decimal> currentItemValue = [];

        foreach (ItemView itemView in ComposedItems)
        {
            Dictionary<Currency, decimal>? composedItemValues = itemView.GetTotalValues();

            if (composedItemValues == null)
            {
                continue;
            }

            foreach (KeyValuePair<Currency, decimal> composedItemValue in composedItemValues)
            {
                if (currentItemValue.TryGetValue(composedItemValue.Key, out decimal existingValue))
                {
                    currentItemValue[composedItemValue.Key] = existingValue + composedItemValue.Value;
                }
                else
                {
                    currentItemValue.Add(composedItemValue.Key, composedItemValue.Value);
                }
            }
        }

        return currentItemValue;
    }

    public virtual KeyValuePair<Currency, decimal>? GetTotalValue()
    {
        KeyValuePair<Currency, decimal>? itemPrice = GetPricePerItem();
        
        if (itemPrice == null)
        {
            return null;
        }

        decimal currentItemValue = itemPrice.Value.Value * (Amount + OverproducedAmount);
        return new KeyValuePair<Currency, decimal>(itemPrice.Value.Key, currentItemValue);
    }

    public virtual KeyValuePair<Currency, decimal>? GetTotalPrice()
    {
        KeyValuePair<Currency, decimal>? itemPrice = GetPricePerItem();

        if (itemPrice == null)
        {
            return null;
        }

        decimal currentItemValue = itemPrice.Value.Value * Amount;
        return new KeyValuePair<Currency, decimal>(itemPrice.Value.Key, currentItemValue);
    }

    public virtual KeyValuePair<Currency, decimal>? GetPricePerItem()
    {
        if (Cost == null)
        {
            return null;
        }

        return Cost.GetItemCost();
    }

    public bool IsProfitable()
    {
        KeyValuePair<Currency, decimal> profit = GetProfit();
        return profit.Value > 0;
    }

    public virtual KeyValuePair<Currency, decimal> GetProfit()
    {
        Dictionary<Currency, decimal>? itemValues = GetTotalValues();
        ArgumentNullException.ThrowIfNull(itemValues);

        KeyValuePair<Currency, decimal>? itemPrice = GetTotalPrice();
        ArgumentNullException.ThrowIfNull(itemPrice);

        if (itemValues.TryGetValue(itemPrice.Value.Key, out decimal itemValue))
        {
            decimal itemProfit = itemPrice.Value.Value - itemValue;
            return new KeyValuePair<Currency, decimal>(itemPrice.Value.Key, itemProfit);
        }

        return new KeyValuePair<Currency, decimal>(itemPrice.Value.Key, itemPrice.Value.Value);
    }

    public void SetOverproduceAmount(decimal produceAmount)
    {
        int factor = GetOverproduceFactor(produceAmount);
        decimal produced = produceAmount * factor;
        OverproducedAmount = produced - Amount;
    }

    public int GetOverproduceFactor(decimal produceAmount)
    {
        decimal overproduced = Amount % produceAmount;

        if (overproduced == Amount)
        {
            return 1;
        }

        if (overproduced != 0)
        {
            int overproduceFactor = (int)Math.Ceiling(Amount / produceAmount);
            return overproduceFactor;
        }

        return 1;
    }

    private static decimal ConvertValueFormat(decimal value)
    {
        decimal val = value - (int)value;
        if (val == 0)
        {
            return (int)value;
        }
        return value;
    }
}