using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sgiq.Dados.Migrations
{
    public partial class projeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SituacaoProjeto",
                newName: "SituacaoProjetoId");

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustoEstimado = table.Column<decimal>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    SituacaoProjetoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projeto_SituacaoProjeto_SituacaoProjetoId",
                        column: x => x.SituacaoProjetoId,
                        principalTable: "SituacaoProjeto",
                        principalColumn: "SituacaoProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_SituacaoProjetoId",
                table: "Projeto",
                column: "SituacaoProjetoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.RenameColumn(
                name: "SituacaoProjetoId",
                table: "SituacaoProjeto",
                newName: "Id");
        }
    }
}
