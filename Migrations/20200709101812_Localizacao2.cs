using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class Localizacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localizacao",
                table: "Utilizador");

            migrationBuilder.AddColumn<string>(
                name: "Localizacao",
                table: "Anuncios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localizacao",
                table: "Anuncios");

            migrationBuilder.AddColumn<string>(
                name: "Localizacao",
                table: "Utilizador",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
