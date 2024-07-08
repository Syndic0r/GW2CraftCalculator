namespace GW2CraftCalculator.Models.Data;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public record VendorItem : Item
{
    public required int ItemAmount { get; set; }
    public ICollection<VendorCost> Cost { get; set; }
}
