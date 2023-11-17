using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BebidaAppl.Migrations
{
    /// <inheritdoc />
    public partial class AddShopCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopCartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ScId = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DrinkBebidaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_ShopCartItems_Drinks_DrinkBebidaId",
                        column: x => x.DrinkBebidaId,
                        principalTable: "Drinks",
                        principalColumn: "BebidaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItems_DrinkBebidaId",
                table: "ShopCartItems",
                column: "DrinkBebidaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopCartItems");
        }
    }
}
