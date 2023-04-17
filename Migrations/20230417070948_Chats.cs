using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeTravel.Migrations
{
    /// <inheritdoc />
    public partial class Chats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Compte1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Compte2Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversations_Comptes_Compte1Id",
                        column: x => x.Compte1Id,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conversations_Comptes_Compte2Id",
                        column: x => x.Compte2Id,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Mess = table.Column<string>(type: "TEXT", nullable: false),
                    CompteEnvoyeurId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompteReceveurId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Comptes_CompteEnvoyeurId",
                        column: x => x.CompteEnvoyeurId,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Comptes_CompteReceveurId",
                        column: x => x.CompteReceveurId,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_Compte1Id",
                table: "Conversations",
                column: "Compte1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_Compte2Id",
                table: "Conversations",
                column: "Compte2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CompteEnvoyeurId",
                table: "Messages",
                column: "CompteEnvoyeurId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CompteReceveurId",
                table: "Messages",
                column: "CompteReceveurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
