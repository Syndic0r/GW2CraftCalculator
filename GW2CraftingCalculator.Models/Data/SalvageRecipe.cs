using System.ComponentModel.DataAnnotations;

namespace GW2CraftCalculator.Models.Data;
public record SalvageRecipe
{
    [Key]
    public int Id { get; set; }
    public required SalvageRecipeOutput SalvageOutput { get; set; }
    public required SalvageRecipeInput SalvageInput { get; set; }
}
