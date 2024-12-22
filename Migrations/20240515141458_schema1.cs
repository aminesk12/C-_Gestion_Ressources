using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion.Migrations
{
    /// <inheritdoc />
    public partial class schema1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ressources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AffectationStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ressources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomPrenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Besoins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    RessourceId = table.Column<int>(type: "int", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Besoins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Besoins_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Besoins_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imprimante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vitesse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imprimante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imprimante_Ressources_Id",
                        column: x => x.Id,
                        principalTable: "Ressources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordinateur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Cpu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisqueDur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ecran = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordinateur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordinateur_Ressources_Id",
                        column: x => x.Id,
                        principalTable: "Ressources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomSociete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gerant = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fournisseur_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonneDepartement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NomDepartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RessourceId = table.Column<int>(type: "int", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonneDepartement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonneDepartement_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonneDepartement_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonneDepartement_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponsableRessources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsableRessources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponsableRessources_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FournisseurId = table.Column<int>(type: "int", nullable: false),
                    BesoinId = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offre_Besoins_BesoinId",
                        column: x => x.BesoinId,
                        principalTable: "Besoins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offre_Fournisseur_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administratif",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administratif", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administratif_PersonneDepartement_Id",
                        column: x => x.Id,
                        principalTable: "PersonneDepartement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enseignant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Laboratoire = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enseignant_PersonneDepartement_Id",
                        column: x => x.Id,
                        principalTable: "PersonneDepartement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChefDepartement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: false),
                    ResponsableRessourcesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefDepartement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChefDepartement_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChefDepartement_ResponsableRessources_ResponsableRessourcesId",
                        column: x => x.ResponsableRessourcesId,
                        principalTable: "ResponsableRessources",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChefDepartement_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Besoins_DepartementId",
                table: "Besoins",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Besoins_RessourceId",
                table: "Besoins",
                column: "RessourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ChefDepartement_DepartementId",
                table: "ChefDepartement",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_ChefDepartement_ResponsableRessourcesId",
                table: "ChefDepartement",
                column: "ResponsableRessourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_Offre_BesoinId",
                table: "Offre",
                column: "BesoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Offre_FournisseurId",
                table: "Offre",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonneDepartement_DepartementId",
                table: "PersonneDepartement",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonneDepartement_RessourceId",
                table: "PersonneDepartement",
                column: "RessourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administratif");

            migrationBuilder.DropTable(
                name: "ChefDepartement");

            migrationBuilder.DropTable(
                name: "Enseignant");

            migrationBuilder.DropTable(
                name: "Imprimante");

            migrationBuilder.DropTable(
                name: "Offre");

            migrationBuilder.DropTable(
                name: "Ordinateur");

            migrationBuilder.DropTable(
                name: "ResponsableRessources");

            migrationBuilder.DropTable(
                name: "PersonneDepartement");

            migrationBuilder.DropTable(
                name: "Besoins");

            migrationBuilder.DropTable(
                name: "Fournisseur");

            migrationBuilder.DropTable(
                name: "Departements");

            migrationBuilder.DropTable(
                name: "Ressources");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
