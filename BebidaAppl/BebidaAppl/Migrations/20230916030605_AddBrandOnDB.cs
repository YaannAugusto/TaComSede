using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BebidaAppl.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandOnDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Drinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isBrandPrefer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_BrandId",
                table: "Drinks",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Brands_BrandId",
                table: "Drinks",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Brands_BrandId",
                table: "Drinks");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Drinks_BrandId",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Drinks");
        }
    }
}
