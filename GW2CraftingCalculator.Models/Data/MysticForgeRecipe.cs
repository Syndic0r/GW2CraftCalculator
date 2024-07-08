using System.ComponentModel.DataAnnotations;

namespace GW2CraftCalculator.Models.Data;

public record MysticForgeRecipe
{
    [Key]
    public int Id { get; set; }
    public required MysticForgeRecipeOutput RecipeOutput { get; set; }
    public required MysticForgeRecipeInput RecipeInput { get; set; }
}
