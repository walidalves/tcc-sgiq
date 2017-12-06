using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sgiq.Dados.Migrations
{
    public partial class GerenciarMetricas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Indicador_Projeto_ProjetoId",
                table: "Indicador");

            migrationBuilder.DropForeignKey(
                name: "FK_Medida_Metrica_MetricaId",
                table: "Medida");

            migrationBuilder.DropForeignKey(
                name: "FK_Metrica_Medida_MedidaId",
                table: "Metrica");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Indicador_IndicadorId",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_IndicadorId",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Metrica_MedidaId",
                table: "Metrica");

            migrationBuilder.DropIndex(
                name: "IX_Medida_MetricaId",
                table: "Medida");

            migrationBuilder.DropIndex(
                name: "IX_Indicador_ProjetoId",
                table: "Indicador");

            migrationBuilder.DropColumn(
                name: "IndicadorId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "MedidaId",
                table: "Metrica");

            migrationBuilder.DropColumn(
                name: "MetricaId",
                table: "Medida");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "Indicador");

            migrationBuilder.CreateTable(
                name: "IndicadorProjeto",
                columns: table => new
                {
                    IndicadorId = table.Column<int>(nullable: false),
                    ProjetoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorProjeto", x => new { x.IndicadorId, x.ProjetoId });
                    table.ForeignKey(
                        name: "FK_IndicadorProjeto_Indicador_IndicadorId",
                        column: x => x.IndicadorId,
                        principalTable: "Indicador",
                        principalColumn: "IndicadorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicadorProjeto_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedidaMetrica",
                columns: table => new
                {
                    MedidaId = table.Column<int>(nullable: false),
                    MetricaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedidaMetrica", x => new { x.MedidaId, x.MetricaId });
                    table.ForeignKey(
                        name: "FK_MedidaMetrica_Medida_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Medida",
                        principalColumn: "MedidaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedidaMetrica_Metrica_MetricaId",
                        column: x => x.MetricaId,
                        principalTable: "Metrica",
                        principalColumn: "MetricaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorProjeto_ProjetoId",
                table: "IndicadorProjeto",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_MedidaMetrica_MetricaId",
                table: "MedidaMetrica",
                column: "MetricaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndicadorProjeto");

            migrationBuilder.DropTable(
                name: "MedidaMetrica");

            migrationBuilder.AddColumn<int>(
                name: "IndicadorId",
                table: "Projeto",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedidaId",
                table: "Metrica",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MetricaId",
                table: "Medida",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "Indicador",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_IndicadorId",
                table: "Projeto",
                column: "IndicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Metrica_MedidaId",
                table: "Metrica",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medida_MetricaId",
                table: "Medida",
                column: "MetricaId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicador_ProjetoId",
                table: "Indicador",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Indicador_Projeto_ProjetoId",
                table: "Indicador",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "ProjetoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medida_Metrica_MetricaId",
                table: "Medida",
                column: "MetricaId",
                principalTable: "Metrica",
                principalColumn: "MetricaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Metrica_Medida_MedidaId",
                table: "Metrica",
                column: "MedidaId",
                principalTable: "Medida",
                principalColumn: "MedidaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Indicador_IndicadorId",
                table: "Projeto",
                column: "IndicadorId",
                principalTable: "Indicador",
                principalColumn: "IndicadorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
