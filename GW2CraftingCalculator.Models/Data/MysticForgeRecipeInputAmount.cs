using System.ComponentModel.DataAnnotations;

namespace GW2CraftCalculator.Models.Data;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public record MysticForgeRecipeInputAmount
{
    [Key]
    public int Id { get; set; }
    public required int Amount { get; set; }
    public ICollection<MysticForgeRecipeInput> RecipeInputs { get; set; }
}
