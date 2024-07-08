using System.ComponentModel.DataAnnotations;

namespace GW2CraftCalculator.Models.Data;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public record SalvageRecipeInput
{
    [Key]
    public int Id { get; set; }
    public required Item Item { get; set; }
    public required VendorItemSalvageKit SalvageKit { get; set; }
    public ICollection<SalvageRecipe> SalvageRecipes { get; set; }
}
