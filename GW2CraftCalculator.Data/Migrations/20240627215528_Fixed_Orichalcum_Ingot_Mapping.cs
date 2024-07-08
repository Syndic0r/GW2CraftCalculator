using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GW2CraftCalculator.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_Orichalcum_Ingot_Mapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MysticForgeRecipes",
                keyColumn: "Id",
                keyValue: 153,
                column: "RecipeInputId",
                value: 99);

            migrationBuilder.UpdateData(
                table: "MysticForgeRecipes",
                keyColumn: "Id",
                keyValue: 154,
                column: "RecipeInputId",
                value: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MysticForgeRecipes",
                keyColumn: "Id",
                keyValue: 153,
                column: "RecipeInputId",
                value: 84);

            migrationBuilder.UpdateData(
                table: "MysticForgeRecipes",
                keyColumn: "Id",
                keyValue: 154,
                column: "RecipeInputId",
                value: 85);
        }
    }
}
