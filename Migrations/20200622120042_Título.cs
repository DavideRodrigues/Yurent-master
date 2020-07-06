using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class Título : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Anuncios");

            migrationBuilder.AddColumn<string>(
                name: "Título",
                table: "Anuncios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Título",
                table: "Anuncios");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Anuncios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
