using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class Fks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Verificacao");

            migrationBuilder.DropColumn(
                name: "Id_reserva",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Id_anuncio",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Mensagens");

            migrationBuilder.DropColumn(
                name: "Id_anuncio",
                table: "Mensagens");

            migrationBuilder.AddColumn<int>(
                name: "UtilizadorId_utilizador",
                table: "Verificacao",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservaId_reserva",
                table: "Transacoes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnuncioId_anuncio",
                table: "Reservas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UtilizadorId_utilizador",
                table: "Reservas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnuncioId_anuncio",
                table: "Mensagens",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UtilizadorId_utilizador",
                table: "Mensagens",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UtilizadorId_utilizador",
                table: "Faturacao",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verificacao_UtilizadorId_utilizador",
                table: "Verificacao",
                column: "UtilizadorId_utilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ReservaId_reserva",
                table: "Transacoes",
                column: "ReservaId_reserva");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AnuncioId_anuncio",
                table: "Reservas",
                column: "AnuncioId_anuncio");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UtilizadorId_utilizador",
                table: "Reservas",
                column: "UtilizadorId_utilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_AnuncioId_anuncio",
                table: "Mensagens",
                column: "AnuncioId_anuncio");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_UtilizadorId_utilizador",
                table: "Mensagens",
                column: "UtilizadorId_utilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Faturacao_UtilizadorId_utilizador",
                table: "Faturacao",
                column: "UtilizadorId_utilizador");

            migrationBuilder.AddForeignKey(
                name: "FK_Faturacao_Utilizador_UtilizadorId_utilizador",
                table: "Faturacao",
                column: "UtilizadorId_utilizador",
                principalTable: "Utilizador",
                principalColumn: "Id_utilizador",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagens_Anuncios_AnuncioId_anuncio",
                table: "Mensagens",
                column: "AnuncioId_anuncio",
                principalTable: "Anuncios",
                principalColumn: "Id_anuncio",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagens_Utilizador_UtilizadorId_utilizador",
                table: "Mensagens",
                column: "UtilizadorId_utilizador",
                principalTable: "Utilizador",
                principalColumn: "Id_utilizador",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Anuncios_AnuncioId_anuncio",
                table: "Reservas",
                column: "AnuncioId_anuncio",
                principalTable: "Anuncios",
                principalColumn: "Id_anuncio",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Utilizador_UtilizadorId_utilizador",
                table: "Reservas",
                column: "UtilizadorId_utilizador",
                principalTable: "Utilizador",
                principalColumn: "Id_utilizador",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Reservas_ReservaId_reserva",
                table: "Transacoes",
                column: "ReservaId_reserva",
                principalTable: "Reservas",
                principalColumn: "Id_reserva",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Verificacao_Utilizador_UtilizadorId_utilizador",
                table: "Verificacao",
                column: "UtilizadorId_utilizador",
                principalTable: "Utilizador",
                principalColumn: "Id_utilizador",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faturacao_Utilizador_UtilizadorId_utilizador",
                table: "Faturacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagens_Anuncios_AnuncioId_anuncio",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagens_Utilizador_UtilizadorId_utilizador",
                table: "Mensagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Anuncios_AnuncioId_anuncio",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Utilizador_UtilizadorId_utilizador",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Reservas_ReservaId_reserva",
                table: "Transacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Verificacao_Utilizador_UtilizadorId_utilizador",
                table: "Verificacao");

            migrationBuilder.DropIndex(
                name: "IX_Verificacao_UtilizadorId_utilizador",
                table: "Verificacao");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_ReservaId_reserva",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_AnuncioId_anuncio",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_UtilizadorId_utilizador",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Mensagens_AnuncioId_anuncio",
                table: "Mensagens");

            migrationBuilder.DropIndex(
                name: "IX_Mensagens_UtilizadorId_utilizador",
                table: "Mensagens");

            migrationBuilder.DropIndex(
                name: "IX_Faturacao_UtilizadorId_utilizador",
                table: "Faturacao");

            migrationBuilder.DropColumn(
                name: "UtilizadorId_utilizador",
                table: "Verificacao");

            migrationBuilder.DropColumn(
                name: "ReservaId_reserva",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "AnuncioId_anuncio",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "UtilizadorId_utilizador",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "AnuncioId_anuncio",
                table: "Mensagens");

            migrationBuilder.DropColumn(
                name: "UtilizadorId_utilizador",
                table: "Mensagens");

            migrationBuilder.DropColumn(
                name: "UtilizadorId_utilizador",
                table: "Faturacao");

            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Verificacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_reserva",
                table: "Transacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_anuncio",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Mensagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_anuncio",
                table: "Mensagens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
