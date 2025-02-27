﻿// <auto-generated />
using System;
using Gestion.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gestion.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240516151015_schema6")]
    partial class schema6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetEtudeDeCas.Models.AppelOffre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("SendStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("AppelOffres");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Besoin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AppelOffreId")
                        .HasColumnType("int");

                    b.Property<int>("DepartementId")
                        .HasColumnType("int");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.Property<int>("RessourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppelOffreId");

                    b.HasIndex("DepartementId");

                    b.HasIndex("RessourceId");

                    b.ToTable("Besoins");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Departement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Budget")
                        .HasColumnType("float");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departements");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Motif", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FournisseurId")
                        .HasColumnType("int");

                    b.Property<int>("ResponsableRessourcesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FournisseurId");

                    b.HasIndex("ResponsableRessourcesId");

                    b.ToTable("Motif");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Offre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BesoinId")
                        .HasColumnType("int");

                    b.Property<int>("FournisseurId")
                        .HasColumnType("int");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BesoinId");

                    b.HasIndex("FournisseurId");

                    b.ToTable("Offre");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Ressource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AffectationStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ressources");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomPrenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Imprimante", b =>
                {
                    b.HasBaseType("ProjetEtudeDeCas.Models.Ressource");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resolution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vitesse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Imprimante");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Ordinateur", b =>
                {
                    b.HasBaseType("ProjetEtudeDeCas.Models.Ressource");

                    b.Property<string>("Cpu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisqueDur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ecran")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Ordinateur");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.ChefDepartement", b =>
                {
                    b.HasBaseType("ProjetEtudeDeCas.Models.User");

                    b.Property<int>("DepartementId")
                        .HasColumnType("int");

                    b.Property<int?>("ResponsableRessourcesId")
                        .HasColumnType("int");

                    b.HasIndex("DepartementId");

                    b.HasIndex("ResponsableRessourcesId");

                    b.ToTable("ChefDepartement");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Fournisseur", b =>
                {
                    b.HasBaseType("ProjetEtudeDeCas.Models.User");

                    b.Property<string>("Gerant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomSociete")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Fournisseur");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.PersonneDepartement", b =>
                {
                    b.HasBaseType("ProjetEtudeDeCas.Models.User");

                    b.Property<int?>("DepartementId")
                        .HasColumnType("int");

                    b.Property<string>("NomDepartment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RessourceId")
                        .HasColumnType("int");

                    b.HasIndex("DepartementId");

                    b.HasIndex("RessourceId");

                    b.ToTable("PersonneDepartement");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.ResponsableRessources", b =>
                {
                    b.HasBaseType("ProjetEtudeDeCas.Models.User");

                    b.ToTable("ResponsableRessources");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Administratif", b =>
                {
                    b.HasBaseType("ProjetEtudeDeCas.Models.PersonneDepartement");

                    b.ToTable("Administratif");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Enseignant", b =>
                {
                    b.HasBaseType("ProjetEtudeDeCas.Models.PersonneDepartement");

                    b.Property<string>("Laboratoire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Enseignant");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Besoin", b =>
                {
                    b.HasOne("ProjetEtudeDeCas.Models.AppelOffre", null)
                        .WithMany("Besoins")
                        .HasForeignKey("AppelOffreId");

                    b.HasOne("ProjetEtudeDeCas.Models.Departement", "Departement")
                        .WithMany()
                        .HasForeignKey("DepartementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetEtudeDeCas.Models.Ressource", "Ressource")
                        .WithMany()
                        .HasForeignKey("RessourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departement");

                    b.Navigation("Ressource");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Motif", b =>
                {
                    b.HasOne("ProjetEtudeDeCas.Models.Fournisseur", "Fournisseur")
                        .WithMany()
                        .HasForeignKey("FournisseurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetEtudeDeCas.Models.ResponsableRessources", "Responsable")
                        .WithMany()
                        .HasForeignKey("ResponsableRessourcesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fournisseur");

                    b.Navigation("Responsable");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Offre", b =>
                {
                    b.HasOne("ProjetEtudeDeCas.Models.Besoin", "Besoin")
                        .WithMany()
                        .HasForeignKey("BesoinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetEtudeDeCas.Models.Fournisseur", "Fournisseur")
                        .WithMany()
                        .HasForeignKey("FournisseurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Besoin");

                    b.Navigation("Fournisseur");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Imprimante", b =>
                {
                    b.HasOne("ProjetEtudeDeCas.Models.Ressource", null)
                        .WithOne()
                        .HasForeignKey("ProjetEtudeDeCas.Models.Imprimante", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Ordinateur", b =>
                {
                    b.HasOne("ProjetEtudeDeCas.Models.Ressource", null)
                        .WithOne()
                        .HasForeignKey("ProjetEtudeDeCas.Models.Ordinateur", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.ChefDepartement", b =>
                {
                    b.HasOne("ProjetEtudeDeCas.Models.Departement", "Departement")
                        .WithMany()
                        .HasForeignKey("DepartementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetEtudeDeCas.Models.User", null)
                        .WithOne()
                        .HasForeignKey("ProjetEtudeDeCas.Models.ChefDepartement", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetEtudeDeCas.Models.ResponsableRessources", null)
                        .WithMany("ListChefDepartement")
                        .HasForeignKey("ResponsableRessourcesId");

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Fournisseur", b =>
                {
                    b.HasOne("ProjetEtudeDeCas.Models.User", null)
                        .WithOne()
                        .HasForeignKey("ProjetEtudeDeCas.Models.Fournisseur", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.PersonneDepartement", b =>
                {
                    b.HasOne("ProjetEtudeDeCas.Models.Departement", null)
                        .WithMany("PersonnesDepartement")
                        .HasForeignKey("DepartementId");

                    b.HasOne("ProjetEtudeDeCas.Models.User", null)
                        .WithOne()
                        .HasForeignKey("ProjetEtudeDeCas.Models.PersonneDepartement", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetEtudeDeCas.Models.Ressource", "Ressource")
                        .WithMany()
                        .HasForeignKey("RessourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ressource");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.ResponsableRessources", b =>
                {
                    b.HasOne("ProjetEtudeDeCas.Models.User", null)
                        .WithOne()
                        .HasForeignKey("ProjetEtudeDeCas.Models.ResponsableRessources", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Administratif", b =>
                {
                    b.HasOne("ProjetEtudeDeCas.Models.PersonneDepartement", null)
                        .WithOne()
                        .HasForeignKey("ProjetEtudeDeCas.Models.Administratif", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Enseignant", b =>
                {
                    b.HasOne("ProjetEtudeDeCas.Models.PersonneDepartement", null)
                        .WithOne()
                        .HasForeignKey("ProjetEtudeDeCas.Models.Enseignant", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.AppelOffre", b =>
                {
                    b.Navigation("Besoins");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.Departement", b =>
                {
                    b.Navigation("PersonnesDepartement");
                });

            modelBuilder.Entity("ProjetEtudeDeCas.Models.ResponsableRessources", b =>
                {
                    b.Navigation("ListChefDepartement");
                });
#pragma warning restore 612, 618
        }
    }
}
