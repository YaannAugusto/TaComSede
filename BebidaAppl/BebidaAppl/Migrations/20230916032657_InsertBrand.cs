using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BebidaAppl.Migrations
{
    /// <inheritdoc />
    public partial class InsertBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT into Brands(Name, isBrandPrefer)" +
               "VALUES ('brahma', 0)");

            migrationBuilder.Sql("INSERT into Brands(Name, isBrandPrefer)" +
               "VALUES ('Antártica', 0)");

            migrationBuilder.Sql("INSERT into Brands(Name, isBrandPrefer)" +
               "VALUES ('Corona', 0)");

            migrationBuilder.Sql("INSERT into Brands(Name, isBrandPrefer)" +
               "VALUES ('Jose Cuerva', 0)");

            migrationBuilder.Sql("INSERT into Brands(Name, isBrandPrefer)" +
                "VALUES ('Smirnoff', 0)");

            migrationBuilder.Sql("INSERT into Brands(Name, isBrandPrefer)" +
                "VALUES ('Coca-cola', 0)");

            migrationBuilder.Sql("INSERT into Brands(Name, isBrandPrefer)" +
                "VALUES ('Pepsi', 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
