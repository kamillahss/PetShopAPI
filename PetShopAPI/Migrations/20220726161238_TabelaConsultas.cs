using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShopAPI.Migrations
{
    public partial class TabelaConsultas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Consulta",
                columns: table => new
                {
                    VeterinarioId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Consulta", x => new { x.AnimalId, x.VeterinarioId, x.DataHora });
                    table.ForeignKey(
                        name: "FK_Tbl_Consulta_Tbl_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Tbl_Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Consulta_Tbl_Veterinario_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalTable: "Tbl_Veterinario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Consulta_VeterinarioId",
                table: "Tbl_Consulta",
                column: "VeterinarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Consulta");
        }
    }
}
