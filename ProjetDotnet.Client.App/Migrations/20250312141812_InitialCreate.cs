using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetDotnet.Client.App.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "CompteBancaire",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOuverture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Solde = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompteBancaire", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientParticulier",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "CarteBancaire",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCarte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompteBancaireId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteBancaire", x => x.Identifiant);
                    table.ForeignKey(
                        name: "FK_CarteBancaire_CompteBancaire_CompteBancaireId",
                        column: x => x.CompteBancaireId,
                        principalTable: "CompteBancaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Identifiant", "CodePostal", "Complement_Adresse", "Libelle_Adresse", "Mail", "Nom", "Ville" },
                values: new object[,]
                {
                    { 1, "94000", "", "12, rue des Oliviers", "bety@gmail.com", "BETY", "Creteil" },
                    { 2, "94120", "Digicode 1432", "125, rue LaFayette", "info@axa.fr", "AXA", "FONTENAY SOUS BOIS" },
                    { 3, "94300", "etage 2", "10, rue des Oliviers", "bodin@gmail.com", "BODIN", "Vincennes" },
                    { 4, "93500", "", "36, quai des Orfevres", "info@paul.fr", "PAUL", "ROISSY EN FRANCE" },
                    { 5, "94120", "", "15, rue de la Republique ", "berris@gmail.com", "BERRIS", "FONTENAY SOUS BOIS" },
                    { 6, "75002", "Bat.C", "32, rue E. Renan ", "info@primark.fr", "PRIMARK", "PARIS" },
                    { 7, "92100", "", "25, rue de la Paix ", "abenir@gmail.com", "ABENIR", "LA DEFENSE" },
                    { 8, "92100", "", "23, av P. Valery ", "info@zara.fr", "ZARA", "LA DEFENSE" },
                    { 9, "93500", "", "3, avenue des Parcs ", "bensaid@gmail.com", "BENSAID", "ROISSY EN France" },
                    { 10, "75003", "Fond de Cour", "15, place de la Bastille", "contact@leonidas.fr", "LEONIDAS", "Paris" },
                    { 11, "93200", "", "3, rue Lecourbe ", "ababou@gmail.com", "ABABOU", "BAGNOLET" }
                });

            migrationBuilder.InsertData(
                table: "CompteBancaire",
                columns: new[] { "Id", "ClientId", "DateOuverture", "Solde" },
                values: new object[,]
                {
                    { "1-1-BE-20250312-PE", 1, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { "10-1-LE-20250312-PR", 10, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { "11-1-AB-20250312-PE", 11, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { "2-1-AX-20250312-PR", 2, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { "3-1-BO-20250312-PE", 3, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { "3-2-BO-20250312-PR", 3, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { "4-1-PA-20250312-PR", 4, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { "5-1-BE-20250312-PE", 5, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { "6-1-PR-20250312-PR", 6, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { "7-1-AB-20250312-PE", 7, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { "8-1-ZA-20250312-PR", 8, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { "9-1-BE-20250312-PE", 9, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { "9-2-BE-20250312-PE", 9, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m }
                });

            migrationBuilder.InsertData(
                table: "CarteBancaire",
                columns: new[] { "Identifiant", "CompteBancaireId", "NumeroCarte" },
                values: new object[,]
                {
                    { 1, "1-1-BE-20250312-PE", "4974018502231257" },
                    { 2, "2-1-AX-20250312-PR", "4974018502231265" },
                    { 3, "3-1-BO-20250312-PE", "4974018502231216" },
                    { 4, "4-1-PA-20250312-PR", "4974018502231240" },
                    { 5, "5-1-BE-20250312-PE", "4974018502231273" },
                    { 6, "6-1-PR-20250312-PR", "4974018502231281" },
                    { 7, "7-1-AB-20250312-PE", "4974018502231208" },
                    { 8, "8-1-ZA-20250312-PR", "4974018502231224" },
                    { 9, "8-1-ZA-20250312-PR", "4974018502231232" }
                });

            migrationBuilder.InsertData(
                table: "ClientParticulier",
                columns: new[] { "Identifiant", "DateDeNaissance", "Prenom", "Sexe" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", "M" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1955), "Justin", "M" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1965), "Karine", "F" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1961), "Alevandra", "F" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1956), "Georgia", "F" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1950), "Teddy", "M" }
                });

            migrationBuilder.InsertData(
                table: "ClientProfessionnel",
                columns: new[] { "Identifiant", "Codepostal_Siege", "Complement_AdresseSiege", "Libelle_AdresseSiege", "Siret", "StatutJuridique", "Ville_Siege" },
                values: new object[,]
                {
                    { 2, "94120", "digicode 1432", "125,rue lafayette", "12548795641122", "SARL", "FONTENAY SOUS BOIS" },
                    { 4, "92060", "", "10, esplandade de la Defense", "87459564455444", "EURL", "LA DEFENSE" },
                    { 6, "75002", "Bat.C", "32, rue E. Renan", "08755897458455", "SARL", "PARIS" },
                    { 8, "92060", " Tour Franklin", "24, esplanade de la Defense", "65895874587854", "SA", "LA DEFENSE" },
                    { 10, "75008", "", "10, rue de la paix", "91235987456832", "SAS", "Paris" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarteBancaire_CompteBancaireId",
                table: "CarteBancaire",
                column: "CompteBancaireId");
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
                name: "CompteBancaire");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
