using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Repository.Migrations
{
    /// <inheritdoc />
    public partial class mg_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ConversionFactor",
                table: "Units",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "StockedProductUnitMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    stockedProductId = table.Column<int>(type: "int", nullable: false),
                    unitId = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockedProductUnitMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockedProductUnitMaps_StockedProducts_stockedProductId",
                        column: x => x.stockedProductId,
                        principalTable: "StockedProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockedProductUnitMaps_Units_unitId",
                        column: x => x.unitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "EnventoryUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69a4c3bf-84cf-4ba4-9502-bedb88dd5dd1", "AQAAAAIAAYagAAAAEBgHHvjrrCv1InN5yq1CHnUX40MkFULPVS//D7Ti9kjHlobZQBQev3vOEotGtBwRow==", "f3091c37-97b6-4441-a1f6-ff43b4025b3a" });

            migrationBuilder.CreateIndex(
                name: "IX_StockedProductUnitMaps_stockedProductId",
                table: "StockedProductUnitMaps",
                column: "stockedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockedProductUnitMaps_unitId",
                table: "StockedProductUnitMaps",
                column: "unitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockedProductUnitMaps");

            migrationBuilder.DropColumn(
                name: "ConversionFactor",
                table: "Units");

            migrationBuilder.UpdateData(
                table: "EnventoryUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f96261b-cd9b-407b-8e32-aa67a60b092e", "AQAAAAIAAYagAAAAEE7KgfiMGu5s1JHHGAruq/RIB9T73v6MjChhsd+VlCNh0VwCE7qclXQQOyUu0pFzHA==", "69e661a7-4eeb-465f-8474-65d73fabce00" });
        }
    }
}
