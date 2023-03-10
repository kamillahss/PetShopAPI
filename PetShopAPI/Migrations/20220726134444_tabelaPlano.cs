using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShopAPI.Migrations
{
    public partial class tabelaPlano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanoId",
                table: "Tbl_Animal",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tbl_Plano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Plano", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Animal_PlanoId",
                table: "Tbl_Animal",
                column: "PlanoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Animal_Tbl_Plano_PlanoId",
                table: "Tbl_Animal",
                column: "PlanoId",
                principalTable: "Tbl_Plano",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Animal_Tbl_Plano_PlanoId",
                table: "Tbl_Animal");

            migrationBuilder.DropTable(
                name: "Tbl_Plano");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Animal_PlanoId",
                table: "Tbl_Animal");

            migrationBuilder.DropColumn(
                name: "PlanoId",
                table: "Tbl_Animal");
        }
    }
}
