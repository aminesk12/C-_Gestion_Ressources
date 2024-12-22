using Microsoft.EntityFrameworkCore;
using ProjetEtudeDeCas.Models;

namespace Gestion.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }
        public virtual DbSet<Ordinateur> Ordinateurs { get; set; }
        public virtual DbSet<Ressource> Ressources { get; set; }
        public DbSet<ProjetEtudeDeCas.Models.PersonneDepartement> PersonneDepartement { get; set; }
        public virtual DbSet<Besoin> Besoins { get; set; }
        public virtual DbSet<Departement> Departements { get; set; }
        public virtual DbSet<Enseignant> Enseignants { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Imprimante> Imprimantes { get; set; }
        public virtual DbSet<Offre> Offres { get; set; }
        public virtual DbSet<ResponsableRessources> ResponsableRessources { get; set; }
        public virtual DbSet<ChefDepartement> ChefDepartements { get; set; }
        public virtual DbSet<Administratif> Administratifs { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<AppelOffre> AppelOffres { get; set; }
        public virtual DbSet<Motif> Motifs { get; set; }

    }
}
