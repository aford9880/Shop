using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class ShopCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Category_categoryID",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "desc",
                table: "Category",
                newName: "Desc");

            migrationBuilder.RenameColumn(
                name: "categoryName",
                table: "Category",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Category",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "shortDesc",
                table: "Car",
                newName: "ShortDesc");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Car",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "longDesc",
                table: "Car",
                newName: "LongDesc");

            migrationBuilder.RenameColumn(
                name: "isFavorite",
                table: "Car",
                newName: "IsFavorite");

            migrationBuilder.RenameColumn(
                name: "img",
                table: "Car",
                newName: "Img");

            migrationBuilder.RenameColumn(
                name: "categoryID",
                table: "Car",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "available",
                table: "Car",
                newName: "Available");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Car",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Car_categoryID",
                table: "Car",
                newName: "IX_Car_CategoryID");

            migrationBuilder.CreateTable(
                name: "ShopCartItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    carId = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    ShopCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopCartItem_Car_carId",
                        column: x => x.carId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItem_carId",
                table: "ShopCartItem",
                column: "carId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Category_CategoryID",
                table: "Car",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Category_CategoryID",
                table: "Car");

            migrationBuilder.DropTable(
                name: "ShopCartItem");

            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Category",
                newName: "desc");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Category",
                newName: "categoryName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Category",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ShortDesc",
                table: "Car",
                newName: "shortDesc");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Car",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "LongDesc",
                table: "Car",
                newName: "longDesc");

            migrationBuilder.RenameColumn(
                name: "IsFavorite",
                table: "Car",
                newName: "isFavorite");

            migrationBuilder.RenameColumn(
                name: "Img",
                table: "Car",
                newName: "img");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Car",
                newName: "categoryID");

            migrationBuilder.RenameColumn(
                name: "Available",
                table: "Car",
                newName: "available");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Car",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Car_CategoryID",
                table: "Car",
                newName: "IX_Car_categoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Category_categoryID",
                table: "Car",
                column: "categoryID",
                principalTable: "Category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
