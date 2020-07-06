using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class RefreshDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Verificacao");

            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Mensagens");

            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Faturacao");

            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Anuncios");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Verificacao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Reservas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Mensagens",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Faturacao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Anuncios",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Verificacao");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Mensagens");


            migrationBuilder.DropColumn(
                name: "Id",
                table: "Faturacao");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Anuncios");

            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Verificacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Mensagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Faturacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Anuncios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
