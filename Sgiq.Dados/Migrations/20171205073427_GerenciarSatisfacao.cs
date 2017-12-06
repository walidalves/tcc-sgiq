using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sgiq.Dados.Migrations
{
    public partial class GerenciarSatisfacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvaliacaoProjeto",
                columns: table => new
                {
                    ProjetoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Chave = table.Column<string>(nullable: false),
                    DtAvaliacao = table.Column<DateTime>(nullable: false),
                    ParteInteressadaId = table.Column<int>(nullable: false),
                    VlrAvaliacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoProjeto", x => x.ProjetoId);
                    table.ForeignKey(
                        name: "FK_AvaliacaoProjeto_ParteInteressada_ParteInteressadaId",
                        column: x => x.ParteInteressadaId,
                        principalTable: "ParteInteressada",
                        principalColumn: "ParteInteressadaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoRequisito",
                columns: table => new
                {
                    RequisitoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DtAvaliacao = table.Column<DateTime>(nullable: false),
                    VlrAvaliacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoRequisito", x => x.RequisitoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoProjeto_ParteInteressadaId",
                table: "AvaliacaoProjeto",
                column: "ParteInteressadaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_AvaliacaoProjeto_ProjetoId",
                table: "Projeto",
                column: "ProjetoId",
                principalTable: "AvaliacaoProjeto",
                principalColumn: "ProjetoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requisito_AvaliacaoRequisito_RequisitoId",
                table: "Requisito",
                column: "RequisitoId",
                principalTable: "AvaliacaoRequisito",
                principalColumn: "RequisitoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_AvaliacaoProjeto_ProjetoId",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisito_AvaliacaoRequisito_RequisitoId",
                table: "Requisito");

            migrationBuilder.DropTable(
                name: "AvaliacaoProjeto");

            migrationBuilder.DropTable(
                name: "AvaliacaoRequisito");
        }
    }
}
