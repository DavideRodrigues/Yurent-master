using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class EmailTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Verificacao");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Verificacao",
                nullable: true);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Verificacao");

            

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Verificacao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
