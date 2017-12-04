using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sgiq.Dados.Migrations
{
    public partial class parteinteressadaprojetoupdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParteInteressada",
                columns: table => new
                {
                    ParteInteressadaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Telefone = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParteInteressada", x => x.ParteInteressadaId);
                });

            migrationBuilder.CreateTable(
                name: "ParteInteressadaProjeto",
                columns: table => new
                {
                    ProjetoId = table.Column<int>(nullable: false),
                    ParteInteressadaId = table.Column<int>(nullable: false),
                    PapelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParteInteressadaProjeto", x => new { x.ProjetoId, x.ParteInteressadaId });
                    table.UniqueConstraint("AK_ParteInteressadaProjeto_ParteInteressadaId_ProjetoId", x => new { x.ParteInteressadaId, x.ProjetoId });
                    table.ForeignKey(
                        name: "FK_ParteInteressadaProjeto_Papel_PapelId",
                        column: x => x.PapelId,
                        principalTable: "Papel",
                        principalColumn: "PapelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParteInteressadaProjeto_ParteInteressada_ParteInteressadaId",
                        column: x => x.ParteInteressadaId,
                        principalTable: "ParteInteressada",
                        principalColumn: "ParteInteressadaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParteInteressadaProjeto_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParteInteressadaProjeto_PapelId",
                table: "ParteInteressadaProjeto",
                column: "PapelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParteInteressadaProjeto");

            migrationBuilder.DropTable(
                name: "ParteInteressada");
        }
    }
}
