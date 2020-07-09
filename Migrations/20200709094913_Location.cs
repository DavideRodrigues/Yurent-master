using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class Location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Localizacao",
                table: "Utilizador",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localizacao",
                table: "Utilizador");
        }
    }
}
