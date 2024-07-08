using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GW2CraftCalculator.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_CurrencyIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CurrencyConversions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BaseCurrencyType", "ConversionCurrencyType" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "CurrencyConversions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BaseCurrencyType", "ConversionCurrencyType" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 1,
                column: "CurrencyType",
                value: 23);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 2,
                column: "CurrencyType",
                value: 23);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 3,
                column: "CurrencyType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 4,
                column: "CurrencyType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 5,
                column: "CurrencyType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 6,
                column: "CurrencyType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 7,
                column: "CurrencyType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 8,
                column: "CurrencyType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 9,
                column: "CurrencyType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 10,
                column: "CurrencyType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 11,
                column: "CurrencyType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 12,
                column: "CurrencyType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 13,
                column: "CurrencyType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 14,
                column: "CurrencyType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 15,
                column: "CurrencyType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 16,
                column: "CurrencyType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "VendorItemSalvageKitInfinite",
                keyColumn: "Id",
                keyValue: 44602,
                column: "CostPerUseCurrencyType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VendorItemSalvageKitInfinite",
                keyColumn: "Id",
                keyValue: 67027,
                column: "CostPerUseCurrencyType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VendorItemSalvageKitInfinite",
                keyColumn: "Id",
                keyValue: 89409,
                column: "CostPerUseCurrencyType",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CurrencyConversions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BaseCurrencyType", "ConversionCurrencyType" },
                values: new object[] { 3, 0 });

            migrationBuilder.UpdateData(
                table: "CurrencyConversions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BaseCurrencyType", "ConversionCurrencyType" },
                values: new object[] { 2, 0 });

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 1,
                column: "CurrencyType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 2,
                column: "CurrencyType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 3,
                column: "CurrencyType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 4,
                column: "CurrencyType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 5,
                column: "CurrencyType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 6,
                column: "CurrencyType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 7,
                column: "CurrencyType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 8,
                column: "CurrencyType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 9,
                column: "CurrencyType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 10,
                column: "CurrencyType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 11,
                column: "CurrencyType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 12,
                column: "CurrencyType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 13,
                column: "CurrencyType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 14,
                column: "CurrencyType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 15,
                column: "CurrencyType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VendorCost",
                keyColumn: "Id",
                keyValue: 16,
                column: "CurrencyType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "VendorItemSalvageKitInfinite",
                keyColumn: "Id",
                keyValue: 44602,
                column: "CostPerUseCurrencyType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VendorItemSalvageKitInfinite",
                keyColumn: "Id",
                keyValue: 67027,
                column: "CostPerUseCurrencyType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "VendorItemSalvageKitInfinite",
                keyColumn: "Id",
                keyValue: 89409,
                column: "CostPerUseCurrencyType",
                value: 0);
        }
    }
}
