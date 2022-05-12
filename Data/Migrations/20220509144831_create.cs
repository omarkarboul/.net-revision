using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    EquipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdressLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomEquipe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.EquipeId);
                });

            migrationBuilder.CreateTable(
                name: "Membres",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    Poste = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membres", x => x.Identifiant);
                });

            migrationBuilder.CreateTable(
                name: "Trophees",
                columns: table => new
                {
                    TropheeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeTrophee = table.Column<int>(type: "int", nullable: false),
                    Recomponse = table.Column<double>(type: "float", nullable: false),
                    DateTrophee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EquipeFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trophees", x => x.TropheeId);
                    table.ForeignKey(
                        name: "FK_Trophees_Equipes_EquipeFK",
                        column: x => x.EquipeFK,
                        principalTable: "Equipes",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contrats",
                columns: table => new
                {
                    DateContrat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EquipeId = table.Column<int>(type: "int", nullable: false),
                    Identifiant = table.Column<int>(type: "int", nullable: false),
                    DureeMois = table.Column<int>(type: "int", nullable: false),
                    Salaire = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrats", x => new { x.EquipeId, x.Identifiant, x.DateContrat });
                    table.ForeignKey(
                        name: "FK_Contrats_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrats_Membres_Identifiant",
                        column: x => x.Identifiant,
                        principalTable: "Membres",
                        principalColumn: "Identifiant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_Identifiant",
                table: "Contrats",
                column: "Identifiant");

            migrationBuilder.CreateIndex(
                name: "IX_Trophees_EquipeFK",
                table: "Trophees",
                column: "EquipeFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrats");

            migrationBuilder.DropTable(
                name: "Trophees");

            migrationBuilder.DropTable(
                name: "Membres");

            migrationBuilder.DropTable(
                name: "Equipes");
        }
    }
}
