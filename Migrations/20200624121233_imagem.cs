using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class imagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemFile",
                table: "Anuncios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemFile",
                table: "Anuncios");
        }
    }
}
