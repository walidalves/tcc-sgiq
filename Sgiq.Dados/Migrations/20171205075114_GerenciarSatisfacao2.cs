using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sgiq.Dados.Migrations
{
    public partial class GerenciarSatisfacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_AvaliacaoProjeto_ProjetoId",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisito_AvaliacaoRequisito_RequisitoId",
                table: "Requisito");

            migrationBuilder.AlterColumn<int>(
                name: "RequisitoId",
                table: "AvaliacaoRequisito",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "AvaliacaoProjeto",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoProjeto_Projeto_ProjetoId",
                table: "AvaliacaoProjeto",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "ProjetoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoRequisito_Requisito_RequisitoId",
                table: "AvaliacaoRequisito",
                column: "RequisitoId",
                principalTable: "Requisito",
                principalColumn: "RequisitoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoProjeto_Projeto_ProjetoId",
                table: "AvaliacaoProjeto");

            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoRequisito_Requisito_RequisitoId",
                table: "AvaliacaoRequisito");

            migrationBuilder.AlterColumn<int>(
                name: "RequisitoId",
                table: "AvaliacaoRequisito",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "AvaliacaoProjeto",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

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
    }
}
