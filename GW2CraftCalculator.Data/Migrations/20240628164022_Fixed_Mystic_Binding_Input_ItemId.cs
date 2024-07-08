using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GW2CraftCalculator.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_Mystic_Binding_Input_ItemId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MysticForgeRecipeInputs",
                keyColumn: "Id",
                keyValue: 15,
                column: "ItemId",
                value: 39125);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MysticForgeRecipeInputs",
                keyColumn: "Id",
                keyValue: 15,
                column: "ItemId",
                value: 19663);
        }
    }
}
