using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class ProductTableModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Characteristic_CharacteristicID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CharacteristicID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CharacteristicID",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Characteristic",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characteristic_ProductID",
                table: "Characteristic",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Characteristic_Product_ProductID",
                table: "Characteristic",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characteristic_Product_ProductID",
                table: "Characteristic");

            migrationBuilder.DropIndex(
                name: "IX_Characteristic_ProductID",
                table: "Characteristic");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Characteristic");

            migrationBuilder.AddColumn<int>(
                name: "CharacteristicID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CharacteristicID",
                table: "Product",
                column: "CharacteristicID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Characteristic_CharacteristicID",
                table: "Product",
                column: "CharacteristicID",
                principalTable: "Characteristic",
                principalColumn: "CharacteristicID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
