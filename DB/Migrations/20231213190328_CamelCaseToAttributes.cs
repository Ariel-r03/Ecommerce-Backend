using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class CamelCaseToAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_orderID",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_productID",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_brandID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_categoriesID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Characteristic_characteristicID",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Product",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Product",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Product",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Product",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Product",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "color",
                table: "Product",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "characteristicID",
                table: "Product",
                newName: "CharacteristicID");

            migrationBuilder.RenameColumn(
                name: "categoriesID",
                table: "Product",
                newName: "CategoriesID");

            migrationBuilder.RenameColumn(
                name: "brandID",
                table: "Product",
                newName: "BrandID");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "Product",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_characteristicID",
                table: "Product",
                newName: "IX_Product_CharacteristicID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_categoriesID",
                table: "Product",
                newName: "IX_Product_CategoriesID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_brandID",
                table: "Product",
                newName: "IX_Product_BrandID");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Person",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Person",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Person",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "personID",
                table: "Person",
                newName: "PersonID");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "OrderDetail",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderDetail",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "OrderDetail",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "discount",
                table: "OrderDetail",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "OrderDetail",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "orderID",
                table: "OrderDetail",
                newName: "OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_productID",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ProductID");

            migrationBuilder.RenameColumn(
                name: "total",
                table: "Order",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Order",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Order",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "orderID",
                table: "Order",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Characteristic",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "detail",
                table: "Characteristic",
                newName: "Detail");

            migrationBuilder.RenameColumn(
                name: "characteristicID",
                table: "Characteristic",
                newName: "CharacteristicID");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Categories",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "categoriesID",
                table: "Categories",
                newName: "CategoriesID");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Brand",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Brand",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "brandID",
                table: "Brand",
                newName: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderID",
                table: "OrderDetail",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_ProductID",
                table: "OrderDetail",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_BrandID",
                table: "Product",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "BrandID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoriesID",
                table: "Product",
                column: "CategoriesID",
                principalTable: "Categories",
                principalColumn: "CategoriesID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Characteristic_CharacteristicID",
                table: "Product",
                column: "CharacteristicID",
                principalTable: "Characteristic",
                principalColumn: "CharacteristicID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderID",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductID",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_BrandID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoriesID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Characteristic_CharacteristicID",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Product",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Product",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Product",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Product",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Product",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Product",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "CharacteristicID",
                table: "Product",
                newName: "characteristicID");

            migrationBuilder.RenameColumn(
                name: "CategoriesID",
                table: "Product",
                newName: "categoriesID");

            migrationBuilder.RenameColumn(
                name: "BrandID",
                table: "Product",
                newName: "brandID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Product",
                newName: "productID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CharacteristicID",
                table: "Product",
                newName: "IX_Product_characteristicID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoriesID",
                table: "Product",
                newName: "IX_Product_categoriesID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_BrandID",
                table: "Product",
                newName: "IX_Product_brandID");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Person",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Person",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Person",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Person",
                newName: "personID");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "OrderDetail",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderDetail",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderDetail",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "OrderDetail",
                newName: "discount");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "OrderDetail",
                newName: "productID");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "OrderDetail",
                newName: "orderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ProductID",
                table: "OrderDetail",
                newName: "IX_OrderDetail_productID");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Order",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Order",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Order",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Order",
                newName: "orderID");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Characteristic",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Detail",
                table: "Characteristic",
                newName: "detail");

            migrationBuilder.RenameColumn(
                name: "CharacteristicID",
                table: "Characteristic",
                newName: "characteristicID");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Categories",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "CategoriesID",
                table: "Categories",
                newName: "categoriesID");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Brand",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Brand",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "BrandID",
                table: "Brand",
                newName: "brandID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_orderID",
                table: "OrderDetail",
                column: "orderID",
                principalTable: "Order",
                principalColumn: "orderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_productID",
                table: "OrderDetail",
                column: "productID",
                principalTable: "Product",
                principalColumn: "productID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_brandID",
                table: "Product",
                column: "brandID",
                principalTable: "Brand",
                principalColumn: "brandID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_categoriesID",
                table: "Product",
                column: "categoriesID",
                principalTable: "Categories",
                principalColumn: "categoriesID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Characteristic_characteristicID",
                table: "Product",
                column: "characteristicID",
                principalTable: "Characteristic",
                principalColumn: "characteristicID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
