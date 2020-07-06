using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class Fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UtilizadorId_utilizador",
                table: "Anuncios",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_UtilizadorId_utilizador",
                table: "Anuncios",
                column: "UtilizadorId_utilizador");

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncios_Utilizador_UtilizadorId_utilizador",
                table: "Anuncios",
                column: "UtilizadorId_utilizador",
                principalTable: "Utilizador",
                principalColumn: "Id_utilizador",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anuncios_Utilizador_UtilizadorId_utilizador",
                table: "Anuncios");

            migrationBuilder.DropIndex(
                name: "IX_Anuncios_UtilizadorId_utilizador",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "UtilizadorId_utilizador",
                table: "Anuncios");
        }
    }
}
