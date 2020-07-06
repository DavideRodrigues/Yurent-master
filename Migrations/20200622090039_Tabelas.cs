using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class Tabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faturacao",
                columns: table => new
                {
                    Id_faturacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_utilizador = table.Column<int>(nullable: false),
                    Nome_completo = table.Column<string>(nullable: true),
                    Morada = table.Column<string>(nullable: true),
                    Codigo_postal = table.Column<string>(nullable: true),
                    Nif = table.Column<int>(nullable: false),
                    Iban = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturacao", x => x.Id_faturacao);
                });

            migrationBuilder.CreateTable(
                name: "Guardado",
                columns: table => new
                {
                    Id_guardado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_anuncio = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardado", x => x.Id_guardado);
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    Id_mensagem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_anuncio = table.Column<int>(nullable: false),
                    Fromseller = table.Column<bool>(nullable: false),
                    Conteudo = table.Column<string>(nullable: true),
                    Vista = table.Column<bool>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.Id_mensagem);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id_reserva = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_anuncio = table.Column<int>(nullable: false),
                    Id_utilizador = table.Column<int>(nullable: false),
                    Data_inicio = table.Column<DateTime>(nullable: false),
                    Data_fim = table.Column<DateTime>(nullable: false),
                    Preco = table.Column<float>(nullable: false),
                    Cancelado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id_reserva);
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    ID_transacoes = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_reserva = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.ID_transacoes);
                });

            migrationBuilder.CreateTable(
                name: "Verificacao",
                columns: table => new
                {
                    Id_verificacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_utilizador = table.Column<int>(nullable: false),
                    Telemovel = table.Column<string>(nullable: true),
                    Nif = table.Column<int>(nullable: false),
                    Num_cc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verificacao", x => x.Id_verificacao);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faturacao");

            migrationBuilder.DropTable(
                name: "Guardado");

            migrationBuilder.DropTable(
                name: "Mensagens");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Transacoes");

            migrationBuilder.DropTable(
                name: "Verificacao");
        }
    }
}
