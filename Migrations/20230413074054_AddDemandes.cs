using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeTravel.Migrations
{
    /// <inheritdoc />
    public partial class AddDemandes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompteDemandeurId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompteReceveurId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demandes_Comptes_CompteDemandeurId",
                        column: x => x.CompteDemandeurId,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Demandes_Comptes_CompteReceveurId",
                        column: x => x.CompteReceveurId,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Demandes_CompteDemandeurId",
                table: "Demandes",
                column: "CompteDemandeurId");

            migrationBuilder.CreateIndex(
                name: "IX_Demandes_CompteReceveurId",
                table: "Demandes",
                column: "CompteReceveurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demandes");
        }
    }
}
