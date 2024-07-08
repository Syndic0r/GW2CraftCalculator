using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GW2CraftCalculator.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_CurrencyConversions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyConversions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseCurrencyAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseCurrencyType = table.Column<int>(type: "INTEGER", nullable: false),
                    ConversionCurrencyAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    ConversionCurrencyType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyConversions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CurrencyConversions",
                columns: new[] { "Id", "BaseCurrencyAmount", "BaseCurrencyType", "ConversionCurrencyAmount", "ConversionCurrencyType" },
                values: new object[] { 1, 1000, 3, 1000, 0 });

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyConversions");

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 10);
        }
    }
}
