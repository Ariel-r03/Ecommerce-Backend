using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingCharacteristic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characteristic_Product_ProductID",
                table: "Characteristic");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Characteristic",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characteristic_Product_ProductID",
                table: "Characteristic",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characteristic_Product_ProductID",
                table: "Characteristic");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Characteristic",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Characteristic_Product_ProductID",
                table: "Characteristic",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID");
        }
    }
}
