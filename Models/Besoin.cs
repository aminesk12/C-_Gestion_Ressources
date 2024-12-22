using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetEtudeDeCas.Models
{
    public class Besoin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Quantite { get; set; }

        [ForeignKey("Ressource")]
        public int RessourceId { get; set; }
        public virtual Ressource Ressource { get; set; }

        [ForeignKey("Departement")]
        public int DepartementId { get; set; }
        public virtual Departement Departement { get; set; }
    }
}