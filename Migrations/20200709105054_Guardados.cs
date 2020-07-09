using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class Guardados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guardados",
                columns: table => new
                {
                    Id_guardados = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadorId_utilizador = table.Column<int>(nullable: true),
                    AnunciosId_anuncio = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardados", x => x.Id_guardados);
                    table.ForeignKey(
                        name: "FK_Guardados_Anuncios_AnunciosId_anuncio",
                        column: x => x.AnunciosId_anuncio,
                        principalTable: "Anuncios",
                        principalColumn: "Id_anuncio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guardados_Utilizador_UtilizadorId_utilizador",
                        column: x => x.UtilizadorId_utilizador,
                        principalTable: "Utilizador",
                        principalColumn: "Id_utilizador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guardados_AnunciosId_anuncio",
                table: "Guardados",
                column: "AnunciosId_anuncio");

            migrationBuilder.CreateIndex(
                name: "IX_Guardados_UtilizadorId_utilizador",
                table: "Guardados",
                column: "UtilizadorId_utilizador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guardados");
        }
    }
}
