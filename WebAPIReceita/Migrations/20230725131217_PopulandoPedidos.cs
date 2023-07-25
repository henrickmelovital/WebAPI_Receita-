using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIReceita.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoPedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Pedido (CNPJ, Resultado)" +
                "VALUES (42294845000187, 'teste')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Pedido");
        }
    }
}
