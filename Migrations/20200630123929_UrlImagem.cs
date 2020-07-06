using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class UrlImagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extensao_imagem",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "ImagemFile",
                table: "Anuncios");

            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "Anuncios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "Anuncios");

            migrationBuilder.AddColumn<string>(
                name: "Extensao_imagem",
                table: "Anuncios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagemFile",
                table: "Anuncios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
