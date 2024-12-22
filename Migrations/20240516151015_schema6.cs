using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion.Migrations
{
    /// <inheritdoc />
    public partial class schema6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motif",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponsableRessourcesId = table.Column<int>(type: "int", nullable: false),
                    FournisseurId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motif", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motif_Fournisseur_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction); // Changement ici
                    table.ForeignKey(
                        name: "FK_Motif_ResponsableRessources_ResponsableRessourcesId",
                        column: x => x.ResponsableRessourcesId,
                        principalTable: "ResponsableRessources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction); // Changement ici
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motif_FournisseurId",
                table: "Motif",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Motif_ResponsableRessourcesId",
                table: "Motif",
                column: "ResponsableRessourcesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motif");
        }
    }
}
