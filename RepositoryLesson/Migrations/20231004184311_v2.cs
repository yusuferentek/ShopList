using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLesson.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Lists_ListsId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ListsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ListsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Lists");

            migrationBuilder.CreateTable(
                name: "ShopListProductMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ShopListId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopListProductMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopListProductMapping_Lists_ShopListId",
                        column: x => x.ShopListId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShopListProductMapping_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopListProductMapping_ProductId",
                table: "ShopListProductMapping",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopListProductMapping_ShopListId",
                table: "ShopListProductMapping",
                column: "ShopListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopListProductMapping");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListsId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Lists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ListsId",
                table: "Products",
                column: "ListsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Lists_ListsId",
                table: "Products",
                column: "ListsId",
                principalTable: "Lists",
                principalColumn: "Id");
        }
    }
}
