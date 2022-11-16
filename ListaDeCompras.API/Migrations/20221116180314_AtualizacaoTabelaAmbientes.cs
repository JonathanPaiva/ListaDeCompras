using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaDeCompras.API.Migrations
{
    public partial class AtualizacaoTabelaAmbientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Ambientes_SetorId",
                table: "Itens");

            migrationBuilder.RenameColumn(
                name: "SetorId",
                table: "Itens",
                newName: "AmbienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Itens_SetorId",
                table: "Itens",
                newName: "IX_Itens_AmbienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Ambientes_AmbienteId",
                table: "Itens",
                column: "AmbienteId",
                principalTable: "Ambientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Ambientes_AmbienteId",
                table: "Itens");

            migrationBuilder.RenameColumn(
                name: "AmbienteId",
                table: "Itens",
                newName: "SetorId");

            migrationBuilder.RenameIndex(
                name: "IX_Itens_AmbienteId",
                table: "Itens",
                newName: "IX_Itens_SetorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Ambientes_SetorId",
                table: "Itens",
                column: "SetorId",
                principalTable: "Ambientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
