using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeTravel.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Compte1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Compte2Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amities_Comptes_Compte1Id",
                        column: x => x.Compte1Id,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Amities_Comptes_Compte2Id",
                        column: x => x.Compte2Id,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favoris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompteId = table.Column<int>(type: "INTEGER", nullable: false),
                    LieuId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favoris_Comptes_CompteId",
                        column: x => x.CompteId,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoris_Lieux_LieuId",
                        column: x => x.LieuId,
                        principalTable: "Lieux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amities_Compte1Id",
                table: "Amities",
                column: "Compte1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Amities_Compte2Id",
                table: "Amities",
                column: "Compte2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Favoris_CompteId",
                table: "Favoris",
                column: "CompteId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoris_LieuId",
                table: "Favoris",
                column: "LieuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amities");

            migrationBuilder.DropTable(
                name: "Favoris");
        }
    }
}
