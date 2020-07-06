using Microsoft.EntityFrameworkCore.Migrations;

namespace YURent.Migrations
{
    public partial class TentativaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Faturacao",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Faturacao_Id",
                table: "Faturacao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faturacao_AspNetUsers_Id",
                table: "Faturacao",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faturacao_AspNetUsers_Id",
                table: "Faturacao");

            migrationBuilder.DropIndex(
                name: "IX_Faturacao_Id",
                table: "Faturacao");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Faturacao",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
