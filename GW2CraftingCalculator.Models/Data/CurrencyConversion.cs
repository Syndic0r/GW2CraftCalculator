using GW2CraftCalculator.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GW2CraftCalculator.Models.Data;
public record CurrencyConversion
{
    [Key]
    public int Id { get; set; }
    public required int BaseCurrencyAmount { get; set; }
    public required Currency BaseCurrencyType { get; set; }
    public required int ConversionCurrencyAmount { get; set; }
    public required Currency ConversionCurrencyType { get; set; }
}
