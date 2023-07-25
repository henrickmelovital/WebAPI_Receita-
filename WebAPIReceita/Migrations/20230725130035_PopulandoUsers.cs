using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIReceita.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Users (Username, Password)" +
                "VALUES ('henrick', 'henrick123')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Users");
        }
    }
}
