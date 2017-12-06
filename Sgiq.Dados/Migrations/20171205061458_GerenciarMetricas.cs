using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sgiq.Dados.Migrations
{
    public partial class GerenciarMetricas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndicadorId",
                table: "Projeto",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Indicador",
                columns: table => new
                {
                    IndicadorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 60, nullable: true),
                    MetricaId = table.Column<int>(nullable: false),
                    ProjetoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicador", x => x.IndicadorId);
                    table.ForeignKey(
                        name: "FK_Indicador_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MetaIndicador",
                columns: table => new
                {
                    MetaIndicadorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CondicaoId = table.Column<int>(nullable: false),
                    IndicadorId = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaIndicador", x => x.MetaIndicadorId);
                    table.ForeignKey(
                        name: "FK_MetaIndicador_Condicao_CondicaoId",
                        column: x => x.CondicaoId,
                        principalTable: "Condicao",
                        principalColumn: "CondicaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MetaIndicador_Indicador_IndicadorId",
                        column: x => x.IndicadorId,
                        principalTable: "Indicador",
                        principalColumn: "IndicadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicao",
                columns: table => new
                {
                    MedicaoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    MedidaId = table.Column<int>(nullable: false),
                    ProjetoId = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicao", x => x.MedicaoId);
                    table.ForeignKey(
                        name: "FK_Medicao_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Metrica",
                columns: table => new
                {
                    MetricaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Formula = table.Column<string>(maxLength: 250, nullable: false),
                    FrequenciaAfericaoId = table.Column<int>(nullable: false),
                    MedidaId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metrica", x => x.MetricaId);
                });

            migrationBuilder.CreateTable(
                name: "Medida",
                columns: table => new
                {
                    MedidaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MetricaId = table.Column<int>(nullable: true),
                    TipoDadoId = table.Column<int>(nullable: false),
                    VlrMaximo = table.Column<decimal>(nullable: false),
                    VlrMinimo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medida", x => x.MedidaId);
                    table.ForeignKey(
                        name: "FK_Medida_Metrica_MetricaId",
                        column: x => x.MetricaId,
                        principalTable: "Metrica",
                        principalColumn: "MetricaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_IndicadorId",
                table: "Projeto",
                column: "IndicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicador_ProjetoId",
                table: "Indicador",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicao_MedidaId",
                table: "Medicao",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicao_ProjetoId",
                table: "Medicao",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medida_MetricaId",
                table: "Medida",
                column: "MetricaId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaIndicador_CondicaoId",
                table: "MetaIndicador",
                column: "CondicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaIndicador_IndicadorId",
                table: "MetaIndicador",
                column: "IndicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Metrica_MedidaId",
                table: "Metrica",
                column: "MedidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Indicador_IndicadorId",
                table: "Projeto",
                column: "IndicadorId",
                principalTable: "Indicador",
                principalColumn: "IndicadorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicao_Medida_MedidaId",
                table: "Medicao",
                column: "MedidaId",
                principalTable: "Medida",
                principalColumn: "MedidaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Metrica_Medida_MedidaId",
                table: "Metrica",
                column: "MedidaId",
                principalTable: "Medida",
                principalColumn: "MedidaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Indicador_IndicadorId",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Metrica_Medida_MedidaId",
                table: "Metrica");

            migrationBuilder.DropTable(
                name: "Medicao");

            migrationBuilder.DropTable(
                name: "MetaIndicador");

            migrationBuilder.DropTable(
                name: "Indicador");

            migrationBuilder.DropTable(
                name: "Medida");

            migrationBuilder.DropTable(
                name: "Metrica");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_IndicadorId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "IndicadorId",
                table: "Projeto");
        }
    }
}
