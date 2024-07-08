using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GW2CraftCalculator.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_Laurel_CurrencyConverstion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CurrencyConversions",
                columns: new[] { "Id", "BaseCurrencyAmount", "BaseCurrencyType", "ConversionCurrencyAmount", "ConversionCurrencyType" },
                values: new object[] { 2, 1, 2, 3000, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CurrencyConversions",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
