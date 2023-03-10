using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShopAPI.Migrations
{
    public partial class Tbls_Veterinario_ContratoTralho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Contrato_Trabalho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dt_Contratacao = table.Column<DateTime>(type: "date", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoContrato = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Contrato_Trabalho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Veterinario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Especialidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContratoTrabalhoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Veterinario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Veterinario_Tbl_Contrato_Trabalho_ContratoTrabalhoId",
                        column: x => x.ContratoTrabalhoId,
                        principalTable: "Tbl_Contrato_Trabalho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Veterinario_ContratoTrabalhoId",
                table: "Tbl_Veterinario",
                column: "ContratoTrabalhoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Veterinario");

            migrationBuilder.DropTable(
                name: "Tbl_Contrato_Trabalho");
        }
    }
}
