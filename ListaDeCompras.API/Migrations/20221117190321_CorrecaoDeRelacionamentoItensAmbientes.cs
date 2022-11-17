using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaDeCompras.API.Migrations
{
    public partial class CorrecaoDeRelacionamentoItensAmbientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Ambientes_AmbienteId",
                table: "Itens");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Ambientes_AmbienteId",
                table: "Itens",
                column: "AmbienteId",
                principalTable: "Ambientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Ambientes_AmbienteId",
                table: "Itens");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Ambientes_AmbienteId",
                table: "Itens",
                column: "AmbienteId",
                principalTable: "Ambientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
