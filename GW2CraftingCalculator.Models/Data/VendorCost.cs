using GW2CraftCalculator.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GW2CraftCalculator.Models.Data;
public record VendorCost
{
    [Key]
    public int Id { get; set; }
    public required int Amount { get; set; }
    public required Currency CurrencyType { get; set; }

    public required VendorItem VendorItem { get; set; }
}
