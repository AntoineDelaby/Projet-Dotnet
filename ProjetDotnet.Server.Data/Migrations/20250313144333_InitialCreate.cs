using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetDotnet.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumCarte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOperation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Devise = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historique", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoriqueErreur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumCarte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOperation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Devise = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriqueErreur", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historique");

            migrationBuilder.DropTable(
                name: "HistoriqueErreur");
        }
    }
}
