using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BebidaAppl.Migrations
{
    /// <inheritdoc />
    public partial class InsertCategories : Migration
    {
        /// <inheritdoc />
        /// 

        /*
            Basicamente, adicionei essa migration para da um insert à novas categorias de bebidas.
            Poderia fazer direto no SQLServer mas decidi fazer primeiro desse jeito porque para mim fica mais organizado
            saber o que coloquei inicialmente;
        */

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(Name, Description) " +
                "VALUES('Cervejas', 'Aqui encontrará marcas nacionais de cerveja')");

            migrationBuilder.Sql("INSERT INTO Categories(Name, Description) " +
                "VALUES('Destilados', 'Aqui encontrará marcas nacionais de Destilados')");

            migrationBuilder.Sql("INSERT INTO Categories(Name, Description) " +
                "VALUES('Vinhos', 'Aqui encontrará marcas de Vinhos')");

            migrationBuilder.Sql("INSERT INTO Categories(Name, Description) " +
                "VALUES('Nao Alcoolicos', 'Aqui encontrará nebidas nao alcoolicas')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE from categories");
        }
    }
}
