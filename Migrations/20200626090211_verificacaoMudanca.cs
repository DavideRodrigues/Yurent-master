using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class VerificacaoMudanca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nif",
                table: "Verificacao");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Nif",
                table: "Verificacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

          
        }
    }
}
