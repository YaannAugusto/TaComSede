using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BebidaAppl.Migrations
{
    /// <inheritdoc />
    public partial class InsertDrinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
              migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            */

            migrationBuilder.Sql("INSERT into Drinks(Name, Price, Description,	IsBebidaPrefer,	ImageUrl,	ImageThumbnailUrl,	InStock,	CategoryId,	BrandId)" +
                "Values('Duplo Malte', 3.99, 'Brahma Duplo Malte 500ml', 1, 'D:/.NET6/BebidaApp/BebidaAppl/BebidaAppl/wwwroot/ImageDink/duplo malte.png', 'D:/.NET6/BebidaApp/BebidaAppl/BebidaAppl/wwwroot/ImageDink/duplo malte.png', 1, 1, 1)");

            migrationBuilder.Sql("INSERT into Drinks(Name, Price, Description,	IsBebidaPrefer,	ImageUrl,	ImageThumbnailUrl,	InStock,	CategoryId,	BrandId)" +
                "Values('Brahma', 2.50, 'Brahma lata 350ml', 0, 'D:/.NET6/BebidaApp/BebidaAppl/BebidaAppl/wwwroot/ImageDink/brahmaOr.png', 'D:/.NET6/BebidaApp/BebidaAppl/BebidaAppl/wwwroot/ImageDink/brahmaOr.png', 0, 1, 1)");

            migrationBuilder.Sql("INSERT into Drinks(Name, Price, Description,	IsBebidaPrefer,	ImageUrl,	ImageThumbnailUrl,	InStock,	CategoryId,	BrandId)" +
                "Values('Smirnoff', 35.00, 'vodka smirnoff 1L', 1, 'D:/.NET6/BebidaApp/BebidaAppl/BebidaAppl/wwwroot/ImageDink/smirnof.png', 'D:/.NET6/BebidaApp/BebidaAppl/BebidaAppl/wwwroot/ImageDink/smirnof.png', 1, 2, 5)");

            migrationBuilder.Sql("INSERT into Drinks(Name, Price, Description,	IsBebidaPrefer,	ImageUrl,	ImageThumbnailUrl,	InStock,	CategoryId,	BrandId)" +
                "Values('Blue Label Smirnoff', 37.00, 'vodka blue smirnoff 1L', 0, 'D:/.NET6/BebidaApp/BebidaAppl/BebidaAppl/wwwroot/ImageDink/smirnofblue.png', 'D:/.NET6/BebidaApp/BebidaAppl/BebidaAppl/wwwroot/ImageDink/smirnofblue.png',1,2, 5)");

            migrationBuilder.Sql("INSERT into Drinks(Name, Price, Description,	IsBebidaPrefer,	ImageUrl,	ImageThumbnailUrl,	InStock,	CategoryId,	BrandId)" +
                "Values('Coca-cola', 10.00, 'Coca-cola 2L', 1, 'D:/.NET6/BebidaApp/BebidaAppl/BebidaAppl/wwwroot/ImageDink/coca.png', 'D:/.NET6/BebidaApp/BebidaAppl/BebidaAppl/wwwroot/ImageDink/coca.png',  1, 4, 6)");

            
            //migrationBuilder.Sql("INSERT into Drinks(Name, Price, Description,	IsBebidaPrefer,	ImageUrl,	ImageThumbnailUrl,	InStock,	CategoryId,	BrandId)" +
            //"Values('', 3.99, '', 0, '', '',  0, 1, 1)");

        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            /*
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            */
        }
    }
}
