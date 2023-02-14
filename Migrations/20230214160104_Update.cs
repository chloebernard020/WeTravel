using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeTravel.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appreciations_Comptes_CompteId",
                table: "Appreciations");

            migrationBuilder.DropForeignKey(
                name: "FK_Lieux_Comptes_CompteId1",
                table: "Lieux");

            migrationBuilder.DropForeignKey(
                name: "FK_Villes_Pays_PaysId",
                table: "Villes");

            migrationBuilder.DropIndex(
                name: "IX_Lieux_CompteId1",
                table: "Lieux");

            migrationBuilder.DropColumn(
                name: "Compte",
                table: "Visites");

            migrationBuilder.DropColumn(
                name: "CompteId1",
                table: "Lieux");

            migrationBuilder.AddColumn<int>(
                name: "CompteId",
                table: "Visites",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PaysId",
                table: "Villes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompteId",
                table: "Appreciations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Appreciations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Lien = table.Column<string>(type: "TEXT", nullable: false),
                    CompteId = table.Column<int>(type: "INTEGER", nullable: false),
                    LieuId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Comptes_CompteId",
                        column: x => x.CompteId,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Photos_Lieux_LieuId",
                        column: x => x.LieuId,
                        principalTable: "Lieux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visites_CompteId",
                table: "Visites",
                column: "CompteId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CompteId",
                table: "Photos",
                column: "CompteId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_LieuId",
                table: "Photos",
                column: "LieuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appreciations_Comptes_CompteId",
                table: "Appreciations",
                column: "CompteId",
                principalTable: "Comptes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Villes_Pays_PaysId",
                table: "Villes",
                column: "PaysId",
                principalTable: "Pays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visites_Comptes_CompteId",
                table: "Visites",
                column: "CompteId",
                principalTable: "Comptes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appreciations_Comptes_CompteId",
                table: "Appreciations");

            migrationBuilder.DropForeignKey(
                name: "FK_Villes_Pays_PaysId",
                table: "Villes");

            migrationBuilder.DropForeignKey(
                name: "FK_Visites_Comptes_CompteId",
                table: "Visites");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Visites_CompteId",
                table: "Visites");

            migrationBuilder.DropColumn(
                name: "CompteId",
                table: "Visites");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Appreciations");

            migrationBuilder.AddColumn<string>(
                name: "Compte",
                table: "Visites",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "PaysId",
                table: "Villes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "CompteId1",
                table: "Lieux",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompteId",
                table: "Appreciations",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Lieux_CompteId1",
                table: "Lieux",
                column: "CompteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appreciations_Comptes_CompteId",
                table: "Appreciations",
                column: "CompteId",
                principalTable: "Comptes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lieux_Comptes_CompteId1",
                table: "Lieux",
                column: "CompteId1",
                principalTable: "Comptes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Villes_Pays_PaysId",
                table: "Villes",
                column: "PaysId",
                principalTable: "Pays",
                principalColumn: "Id");
        }
    }
}
