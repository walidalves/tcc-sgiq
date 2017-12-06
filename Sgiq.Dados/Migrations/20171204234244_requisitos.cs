using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sgiq.Dados.Migrations
{
    public partial class requisitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TipoRequisito",
                newName: "TipoRequisitoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TipoDado",
                newName: "TipoDadoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projeto",
                newName: "ProjetoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Condicao",
                newName: "CondicaoId");

            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    AtividadeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false),
                    DtInicioPrevista = table.Column<DateTime>(type: "datetime", nullable: false),
                    DtTerminoPrevista = table.Column<DateTime>(type: "datetime", nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    ProjetoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => x.AtividadeId);
                    table.ForeignKey(
                        name: "FK_Atividade_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requisito",
                columns: table => new
                {
                    RequisitoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProjetoId = table.Column<int>(nullable: false),
                    TipoRequisitoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisito", x => x.RequisitoId);
                    table.ForeignKey(
                        name: "FK_Requisito_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisito_TipoRequisito_TipoRequisitoId",
                        column: x => x.TipoRequisitoId,
                        principalTable: "TipoRequisito",
                        principalColumn: "TipoRequisitoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_ProjetoId",
                table: "Atividade",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisito_ProjetoId",
                table: "Requisito",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisito_TipoRequisitoId",
                table: "Requisito",
                column: "TipoRequisitoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atividade");

            migrationBuilder.DropTable(
                name: "Requisito");

            migrationBuilder.RenameColumn(
                name: "TipoRequisitoId",
                table: "TipoRequisito",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TipoDadoId",
                table: "TipoDado",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProjetoId",
                table: "Projeto",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CondicaoId",
                table: "Condicao",
                newName: "Id");
        }
    }
}
