using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sgiq.Dados.Migrations
{
    public partial class metrica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Metrica",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FrequenciaAfericao",
                columns: table => new
                {
                    FrequenciaAfericaoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrequenciaAfericao", x => x.FrequenciaAfericaoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Metrica_FrequenciaAfericaoId",
                table: "Metrica",
                column: "FrequenciaAfericaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medida_TipoDadoId",
                table: "Medida",
                column: "TipoDadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medida_TipoDado_TipoDadoId",
                table: "Medida",
                column: "TipoDadoId",
                principalTable: "TipoDado",
                principalColumn: "TipoDadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Metrica_FrequenciaAfericao_FrequenciaAfericaoId",
                table: "Metrica",
                column: "FrequenciaAfericaoId",
                principalTable: "FrequenciaAfericao",
                principalColumn: "FrequenciaAfericaoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medida_TipoDado_TipoDadoId",
                table: "Medida");

            migrationBuilder.DropForeignKey(
                name: "FK_Metrica_FrequenciaAfericao_FrequenciaAfericaoId",
                table: "Metrica");

            migrationBuilder.DropTable(
                name: "FrequenciaAfericao");

            migrationBuilder.DropIndex(
                name: "IX_Metrica_FrequenciaAfericaoId",
                table: "Metrica");

            migrationBuilder.DropIndex(
                name: "IX_Medida_TipoDadoId",
                table: "Medida");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Metrica");
        }
    }
}
