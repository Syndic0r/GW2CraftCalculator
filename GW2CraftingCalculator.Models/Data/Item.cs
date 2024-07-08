using GW2CraftCalculator.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GW2CraftCalculator.Models.Data;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public record Item
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required ItemTier Tier { get; set; }
    public required Rarity Rarity { get; set; }
    public required ItemGroup ItemGroup { get; set; }
    public required ItemType ItemType { get; set; }
    public required ItemSpecifications Specifications { get; set; }
    public ICollection<MysticForgeRecipeOutput> RecipeOutputItems { get; set; }
    public ICollection<MysticForgeRecipeInput> RecipeInputItems { get; set; }
    public ICollection<SalvageRecipeInput> SalvageInputs { get; set; }
    public ICollection<SalvageRecipeOutput> SalvageOutputs { get; set; }

    public bool IsCommerceable()
    {
        return !((Specifications & ItemSpecifications.NotCommerceable) != 0);
    }

    public bool IsSalvageable()
    {
        return (SalvageOutputs?.Count ?? 0) != 0;
    }
}
    