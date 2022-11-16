using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaDeCompras.API.Migrations
{
    public partial class RetirandoRelacionamentosAmbientesItens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Ambientes_AmbienteId",
                table: "Itens");

            migrationBuilder.DropIndex(
                name: "IX_Itens_AmbienteId",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "AmbienteId",
                table: "Itens");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AmbienteId",
                table: "Itens",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_AmbienteId",
                table: "Itens",
                column: "AmbienteId");

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
