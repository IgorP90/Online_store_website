using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class migration_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_NarrowCategories_NarrowCategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "NarrowCategoryId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_NarrowCategories_NarrowCategoryId",
                table: "Products",
                column: "NarrowCategoryId",
                principalTable: "NarrowCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_NarrowCategories_NarrowCategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "NarrowCategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_NarrowCategories_NarrowCategoryId",
                table: "Products",
                column: "NarrowCategoryId",
                principalTable: "NarrowCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
