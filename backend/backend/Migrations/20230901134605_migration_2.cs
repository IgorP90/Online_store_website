using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class migration_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "ShoppingСart",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoppingСart",
                newName: "ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ShoppingСart",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

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

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ShoppingСart",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ShoppingСart",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ShoppingСart",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
