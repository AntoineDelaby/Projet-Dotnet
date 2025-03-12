using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetDotnet.Client.App.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarteBancaire",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCarte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteBancaire", x => x.Identifiant);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle_Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement_Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Identifiant);
                });

            migrationBuilder.CreateTable(
                name: "ClientParticulier",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexe = table.Column<int>(type: "int", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientParticulier", x => x.Identifiant);
                    table.ForeignKey(
                        name: "FK_ClientParticulier_Clients_Identifiant",
                        column: x => x.Identifiant,
                        principalTable: "Clients",
                        principalColumn: "Identifiant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientProfessionnel",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false),
                    Siret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatutJuridique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Libelle_AdresseSiege = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement_AdresseSiege = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codepostal_Siege = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville_Siege = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProfessionnel", x => x.Identifiant);
                    table.ForeignKey(
                        name: "FK_ClientProfessionnel_Clients_Identifiant",
                        column: x => x.Identifiant,
                        principalTable: "Clients",
                        principalColumn: "Identifiant",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarteBancaire");

            migrationBuilder.DropTable(
                name: "ClientParticulier");

            migrationBuilder.DropTable(
                name: "ClientProfessionnel");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
