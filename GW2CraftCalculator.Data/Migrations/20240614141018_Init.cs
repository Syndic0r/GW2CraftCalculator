using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GW2CraftCalculator.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Tier = table.Column<int>(type: "INTEGER", nullable: false),
                    Rarity = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemGroup = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemType = table.Column<int>(type: "INTEGER", nullable: false),
                    Specifications = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MysticForgeRecipeInputAmount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MysticForgeRecipeInputAmount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MysticForgeRecipeOutputAmount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MysticForgeRecipeOutputAmount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalvageRecipeOutput",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OutputAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalvageRecipeOutput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalvageRecipeOutput_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemAmount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorItem_Items_Id",
                        column: x => x.Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MysticForgeRecipeInputs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InputAmountId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MysticForgeRecipeInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MysticForgeRecipeInputs_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MysticForgeRecipeInputs_MysticForgeRecipeInputAmount_InputAmountId",
                        column: x => x.InputAmountId,
                        principalTable: "MysticForgeRecipeInputAmount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MysticForgeRecipeOutputs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OutputAmountId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MysticForgeRecipeOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MysticForgeRecipeOutputs_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MysticForgeRecipeOutputs_MysticForgeRecipeOutputAmount_OutputAmountId",
                        column: x => x.OutputAmountId,
                        principalTable: "MysticForgeRecipeOutputAmount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorCost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrencyType = table.Column<int>(type: "INTEGER", nullable: false),
                    VendorItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorCost_VendorItem_VendorItemId",
                        column: x => x.VendorItemId,
                        principalTable: "VendorItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorItemSalvageKit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    ChanceOfRareMaterials = table.Column<decimal>(type: "TEXT", nullable: false),
                    ChanceOfSalvagingUpgrades = table.Column<decimal>(type: "TEXT", nullable: false),
                    SalvageUpgradesType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorItemSalvageKit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorItemSalvageKit_VendorItem_Id",
                        column: x => x.Id,
                        principalTable: "VendorItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MysticForgeRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipeOutputId = table.Column<int>(type: "INTEGER", nullable: false),
                    RecipeInputId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MysticForgeRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MysticForgeRecipes_MysticForgeRecipeInputs_RecipeInputId",
                        column: x => x.RecipeInputId,
                        principalTable: "MysticForgeRecipeInputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MysticForgeRecipes_MysticForgeRecipeOutputs_RecipeOutputId",
                        column: x => x.RecipeOutputId,
                        principalTable: "MysticForgeRecipeOutputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalvageRecipeInput",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    SalvageKitId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalvageRecipeInput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalvageRecipeInput_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalvageRecipeInput_VendorItemSalvageKit_SalvageKitId",
                        column: x => x.SalvageKitId,
                        principalTable: "VendorItemSalvageKit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalvageRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SalvageOutputId = table.Column<int>(type: "INTEGER", nullable: false),
                    SalvageInputId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalvageRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalvageRecipes_SalvageRecipeInput_SalvageInputId",
                        column: x => x.SalvageInputId,
                        principalTable: "SalvageRecipeInput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalvageRecipes_SalvageRecipeOutput_SalvageOutputId",
                        column: x => x.SalvageOutputId,
                        principalTable: "SalvageRecipeOutput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MysticForgeRecipeInputs_InputAmountId",
                table: "MysticForgeRecipeInputs",
                column: "InputAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_MysticForgeRecipeInputs_ItemId",
                table: "MysticForgeRecipeInputs",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MysticForgeRecipeOutputs_ItemId",
                table: "MysticForgeRecipeOutputs",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MysticForgeRecipeOutputs_OutputAmountId",
                table: "MysticForgeRecipeOutputs",
                column: "OutputAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_MysticForgeRecipes_RecipeInputId",
                table: "MysticForgeRecipes",
                column: "RecipeInputId");

            migrationBuilder.CreateIndex(
                name: "IX_MysticForgeRecipes_RecipeOutputId",
                table: "MysticForgeRecipes",
                column: "RecipeOutputId");

            migrationBuilder.CreateIndex(
                name: "IX_SalvageRecipeInput_ItemId",
                table: "SalvageRecipeInput",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalvageRecipeInput_SalvageKitId",
                table: "SalvageRecipeInput",
                column: "SalvageKitId");

            migrationBuilder.CreateIndex(
                name: "IX_SalvageRecipeOutput_ItemId",
                table: "SalvageRecipeOutput",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalvageRecipes_SalvageInputId",
                table: "SalvageRecipes",
                column: "SalvageInputId");

            migrationBuilder.CreateIndex(
                name: "IX_SalvageRecipes_SalvageOutputId",
                table: "SalvageRecipes",
                column: "SalvageOutputId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorCost_VendorItemId",
                table: "VendorCost",
                column: "VendorItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MysticForgeRecipes");

            migrationBuilder.DropTable(
                name: "SalvageRecipes");

            migrationBuilder.DropTable(
                name: "VendorCost");

            migrationBuilder.DropTable(
                name: "MysticForgeRecipeInputs");

            migrationBuilder.DropTable(
                name: "MysticForgeRecipeOutputs");

            migrationBuilder.DropTable(
                name: "SalvageRecipeInput");

            migrationBuilder.DropTable(
                name: "SalvageRecipeOutput");

            migrationBuilder.DropTable(
                name: "MysticForgeRecipeInputAmount");

            migrationBuilder.DropTable(
                name: "MysticForgeRecipeOutputAmount");

            migrationBuilder.DropTable(
                name: "VendorItemSalvageKit");

            migrationBuilder.DropTable(
                name: "VendorItem");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
