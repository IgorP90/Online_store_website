using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class migration_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShoppingСart_ProductId",
                table: "ShoppingСart",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingСart_Products_ProductId",
                table: "ShoppingСart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingСart_Products_ProductId",
                table: "ShoppingСart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingСart_ProductId",
                table: "ShoppingСart");
        }
    }
}
