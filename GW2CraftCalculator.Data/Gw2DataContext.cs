using GW2CraftCalculator.Data.Extensions;
using GW2CraftCalculator.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace GW2CraftCalculator.Data;

public class Gw2DataContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<MysticForgeRecipeOutput> MysticForgeRecipeOutputs { get; set; }
    public DbSet<MysticForgeRecipeInput> MysticForgeRecipeInputs { get; set; }
    public DbSet<MysticForgeRecipe> MysticForgeRecipes { get; set; }
    public DbSet<SalvageRecipe> SalvageRecipes { get; set; }
    public DbSet<CurrencyConversion> CurrencyConversions { get; set; }

    public Gw2DataContext(DbContextOptions<Gw2DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().UseTptMappingStrategy();

        modelBuilder.Entity<MysticForgeRecipeOutputAmount>()
            .Property(ia => ia.Amount)
            .HasConversion<decimal>();

        modelBuilder.Entity<VendorItemSalvageKit>()
            .Property(sk => sk.ChanceOfRareMaterials)
            .HasConversion<decimal>();

        modelBuilder.Entity<VendorItemSalvageKit>()
            .Property(sk => sk.ChanceOfSalvagingUpgrades)
            .HasConversion<decimal>();

        modelBuilder.Entity<SalvageRecipeOutput>()
            .Property(sk => sk.OutputAmount)
            .HasConversion<decimal>();

        modelBuilder.SeedEntities();
    }
}
