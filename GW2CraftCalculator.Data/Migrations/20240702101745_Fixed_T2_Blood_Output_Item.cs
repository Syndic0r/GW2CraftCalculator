using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GW2CraftCalculator.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_T2_Blood_Output_Item : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MysticForgeRecipeOutputs",
                keyColumn: "Id",
                keyValue: 80,
                column: "ItemId",
                value: 24291);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MysticForgeRecipeOutputs",
                keyColumn: "Id",
                keyValue: 80,
                column: "ItemId",
                value: 24283);
        }
    }
}
