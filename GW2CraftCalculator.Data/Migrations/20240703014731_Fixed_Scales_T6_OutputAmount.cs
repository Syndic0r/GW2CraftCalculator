using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GW2CraftCalculator.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_Scales_T6_OutputAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MysticForgeRecipeOutputs",
                keyColumn: "Id",
                keyValue: 69,
                column: "OutputAmountId",
                value: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MysticForgeRecipeOutputs",
                keyColumn: "Id",
                keyValue: 69,
                column: "OutputAmountId",
                value: 6);
        }
    }
}
