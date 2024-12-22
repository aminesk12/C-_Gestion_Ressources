using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetEtudeDeCas.Models
{
    [Table("Offre")]
    public class Offre
    {
        public int Id { get; set; }

        [ForeignKey("Fournisseur")]
        public int FournisseurId { get; set; } 
        public Fournisseur Fournisseur { get; set; }

        [ForeignKey("Besoin")]
        public int BesoinId { get; set; }
        public Besoin Besoin { get; set; }

        public double Prix { get; set; }
    }
}