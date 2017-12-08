using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sgiq.Dados.Migrations
{
    public partial class nomeIndicador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Indicador",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Indicador_MetricaId",
                table: "Indicador",
                column: "MetricaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Indicador_Metrica_MetricaId",
                table: "Indicador",
                column: "MetricaId",
                principalTable: "Metrica",
                principalColumn: "MetricaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Indicador_Metrica_MetricaId",
                table: "Indicador");

            migrationBuilder.DropIndex(
                name: "IX_Indicador_MetricaId",
                table: "Indicador");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Indicador");
        }
    }
}
