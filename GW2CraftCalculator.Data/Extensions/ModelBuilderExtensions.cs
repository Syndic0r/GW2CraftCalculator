using GW2CraftCalculator.Data.DataSeeding;
using GW2CraftCalculator.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace GW2CraftCalculator.Data.Extensions;

internal static class ModelBuilderExtensions
{
    internal static ModelBuilder SeedEntities(this ModelBuilder builder)
    {
        IEnumerable<Item> items = Items.Get();

        IEnumerable<object> vendorItems = VendorItems.Get();
        IEnumerable<object> vendorCosts = VendorItems.GetCosts();
        IEnumerable<VendorItemSalvageKit> salvageKits = VendorItems.GetSalvageKits();
        IEnumerable<VendorItemSalvageKitInfinite> salvageKitInfinites = VendorItems.GetSalvageKitInfinites();

        IEnumerable<MysticForgeRecipeOutputAmount> outputAmount = MysticForgeRecipeOutputs.GetAmounts();
        IEnumerable<object> outputItems = MysticForgeRecipeOutputs.Get();
        IEnumerable<MysticForgeRecipeInputAmount> inputAmount = MysticForgeRecipeInputs.GetAmounts();
        IEnumerable<object> inputItems = MysticForgeRecipeInputs.Get();
        IEnumerable<object> recipeMap = MysticForgeRecipes.Get();

        IEnumerable<object> salvageInputs = SalvageInputs.Get();
        IEnumerable<object> salvageOutputs = SalvageOutputs.Get();
        IEnumerable<object> salvageRecipes = SalvageRecipes.Get();

        IEnumerable<CurrencyConversion> currencyConversions = CurrencyConversions.Get();

        builder.Entity<Item>().HasData(items);
        builder.Entity<VendorItem>().HasData(vendorItems);
        builder.Entity<VendorCost>().HasData(vendorCosts);
        builder.Entity<VendorItemSalvageKit>().HasData(salvageKits);
        builder.Entity<VendorItemSalvageKitInfinite>().HasData(salvageKitInfinites);
        builder.Entity<MysticForgeRecipeOutputAmount>().HasData(outputAmount);
        builder.Entity<MysticForgeRecipeOutput>().HasData(outputItems);
        builder.Entity<MysticForgeRecipeInputAmount>().HasData(inputAmount);
        builder.Entity<MysticForgeRecipeInput>().HasData(inputItems);
        builder.Entity<MysticForgeRecipe>().HasData(recipeMap);
        builder.Entity<SalvageRecipeInput>().HasData(salvageInputs);
        builder.Entity<SalvageRecipeOutput>().HasData(salvageOutputs);
        builder.Entity<SalvageRecipe>().HasData(salvageRecipes);
        builder.Entity<CurrencyConversion>().HasData(currencyConversions);

        return builder;
    }
}
