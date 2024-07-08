using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GW2CraftCalculator.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_venom_t3_tier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 24280,
                column: "Rarity",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 24280,
                column: "Rarity",
                value: 3);
        }
    }
}
