using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class AnuncioUtilizador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Anuncios",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Anuncios");
        }
    }
}
