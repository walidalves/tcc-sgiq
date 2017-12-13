using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sgiq.Dados.Migrations
{
    public partial class atualizarPkProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_SituacaoProjeto_SituacaoProjetoId",
                table: "Projeto");

            migrationBuilder.AlterColumn<int>(
                name: "SituacaoProjetoId",
                table: "Projeto",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_SituacaoProjeto_SituacaoProjetoId",
                table: "Projeto",
                column: "SituacaoProjetoId",
                principalTable: "SituacaoProjeto",
                principalColumn: "SituacaoProjetoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_SituacaoProjeto_SituacaoProjetoId",
                table: "Projeto");

            migrationBuilder.AlterColumn<int>(
                name: "SituacaoProjetoId",
                table: "Projeto",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_SituacaoProjeto_SituacaoProjetoId",
                table: "Projeto",
                column: "SituacaoProjetoId",
                principalTable: "SituacaoProjeto",
                principalColumn: "SituacaoProjetoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
