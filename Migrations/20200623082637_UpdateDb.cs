using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Verificacao",
                table: "Verificacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mensagens",
                table: "Mensagens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guardado",
                table: "Guardado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faturacao",
                table: "Faturacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anuncios",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "Id_verificacao",
                table: "Verificacao");

            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Verificacao");

            migrationBuilder.DropColumn(
                name: "Num_cc",
                table: "Verificacao");

            migrationBuilder.DropColumn(
                name: "ID_transacoes",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "Id_reserva",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "Id_reserva",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Data_fim",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Data_inicio",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Id_anuncio",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Id_mensagem",
                table: "Mensagens");

            migrationBuilder.DropColumn(
                name: "Id_anuncio",
                table: "Mensagens");

            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Mensagens");


            migrationBuilder.DropColumn(
                name: "Id_anuncio",
                table: "Guardado");

            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Guardado");

            migrationBuilder.DropColumn(
                name: "Id_faturacao",
                table: "Faturacao");

            migrationBuilder.DropColumn(
                name: "Codigo_postal",
                table: "Faturacao");

            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Faturacao");

            migrationBuilder.DropColumn(
                name: "Nome_completo",
                table: "Faturacao");

            migrationBuilder.DropColumn(
                name: "Id_anuncio",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "Extensao_imagem",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "Id_utilizador",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "Preco_dia",
                table: "Anuncios");

            migrationBuilder.AddColumn<int>(
                name: "IdVerificacao",
                table: "Verificacao",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdUtilizador",
                table: "Verificacao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Numcc",
                table: "Verificacao",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTransacoes",
                table: "Transacoes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdReserva",
                table: "Transacoes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdReserva",
                table: "Reservas",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFim",
                table: "Reservas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicio",
                table: "Reservas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdAnuncio",
                table: "Reservas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUtilizador",
                table: "Reservas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMensagem",
                table: "Mensagens",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdAnuncio",
                table: "Mensagens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUtilizador",
                table: "Mensagens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAnuncio",
                table: "Guardado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUtilizador",
                table: "Guardado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdFaturacao",
                table: "Faturacao",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CodigoPostal",
                table: "Faturacao",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUtilizador",
                table: "Faturacao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NomeCompleto",
                table: "Faturacao",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdAnuncio",
                table: "Anuncios",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ExtensaoImagem",
                table: "Anuncios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUtilizador",
                table: "Anuncios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "PrecoDia",
                table: "Anuncios",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Verificacao",
                table: "Verificacao",
                column: "IdVerificacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes",
                column: "IdTransacoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas",
                column: "IdReserva");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mensagens",
                table: "Mensagens",
                column: "IdMensagem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guardado",
                table: "Guardado",
                column: "IdGuardado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faturacao",
                table: "Faturacao",
                column: "IdFaturacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anuncios",
                table: "Anuncios",
                column: "IdAnuncio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Verificacao",
                table: "Verificacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mensagens",
                table: "Mensagens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guardado",
                table: "Guardado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faturacao",
                table: "Faturacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anuncios",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "IdVerificacao",
                table: "Verificacao");

            migrationBuilder.DropColumn(
                name: "IdUtilizador",
                table: "Verificacao");

            migrationBuilder.DropColumn(
                name: "Numcc",
                table: "Verificacao");

            migrationBuilder.DropColumn(
                name: "IdTransacoes",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "IdReserva",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "IdReserva",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "DataFim",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "DataInicio",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "IdAnuncio",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "IdUtilizador",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "IdMensagem",
                table: "Mensagens");

            migrationBuilder.DropColumn(
                name: "IdAnuncio",
                table: "Mensagens");

            migrationBuilder.DropColumn(
                name: "IdUtilizador",
                table: "Mensagens");

            migrationBuilder.DropColumn(
                name: "IdGuardado",
                table: "Guardado");

            migrationBuilder.DropColumn(
                name: "IdAnuncio",
                table: "Guardado");

            migrationBuilder.DropColumn(
                name: "IdUtilizador",
                table: "Guardado");

            migrationBuilder.DropColumn(
                name: "IdFaturacao",
                table: "Faturacao");

            migrationBuilder.DropColumn(
                name: "CodigoPostal",
                table: "Faturacao");

            migrationBuilder.DropColumn(
                name: "IdUtilizador",
                table: "Faturacao");

            migrationBuilder.DropColumn(
                name: "NomeCompleto",
                table: "Faturacao");

            migrationBuilder.DropColumn(
                name: "IdAnuncio",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "ExtensaoImagem",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "IdUtilizador",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "PrecoDia",
                table: "Anuncios");

            migrationBuilder.AddColumn<int>(
                name: "Id_verificacao",
                table: "Verificacao",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Verificacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Num_cc",
                table: "Verificacao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_transacoes",
                table: "Transacoes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id_reserva",
                table: "Transacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_reserva",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_fim",
                table: "Reservas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_inicio",
                table: "Reservas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id_anuncio",
                table: "Reservas",
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
                name: "Id_mensagem",
                table: "Mensagens",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id_anuncio",
                table: "Mensagens",
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
                name: "Id_guardado",
                table: "Guardado",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id_anuncio",
                table: "Guardado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Guardado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_faturacao",
                table: "Faturacao",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Codigo_postal",
                table: "Faturacao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Faturacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nome_completo",
                table: "Faturacao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_anuncio",
                table: "Anuncios",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Extensao_imagem",
                table: "Anuncios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_utilizador",
                table: "Anuncios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Preco_dia",
                table: "Anuncios",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Verificacao",
                table: "Verificacao",
                column: "Id_verificacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes",
                column: "ID_transacoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas",
                column: "Id_reserva");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mensagens",
                table: "Mensagens",
                column: "Id_mensagem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guardado",
                table: "Guardado",
                column: "Id_guardado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faturacao",
                table: "Faturacao",
                column: "Id_faturacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anuncios",
                table: "Anuncios",
                column: "Id_anuncio");
        }
    }
}
