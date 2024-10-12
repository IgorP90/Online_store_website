using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class migration_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_WideCategories_WideCategoryId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_WideCategoryId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WideCategoryId1",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductWideCategory",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    WideCategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWideCategory", x => new { x.ProductsId, x.WideCategoriesId });
                    table.ForeignKey(
                        name: "FK_ProductWideCategory_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWideCategory_WideCategories_WideCategoriesId",
                        column: x => x.WideCategoriesId,
                        principalTable: "WideCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductWideCategory_WideCategoriesId",
                table: "ProductWideCategory",
                column: "WideCategoriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductWideCategory");

            migrationBuilder.AddColumn<int>(
                name: "WideCategoryId1",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_WideCategoryId1",
                table: "Products",
                column: "WideCategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_WideCategories_WideCategoryId1",
                table: "Products",
                column: "WideCategoryId1",
                principalTable: "WideCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
