using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Anuncios",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Verificacao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Transacoes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Reservas",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Faturacao",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Verificacao");

            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Reservas");


            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Faturacao");

        }
    }
}
