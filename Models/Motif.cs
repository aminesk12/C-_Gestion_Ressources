using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetEtudeDeCas.Models
{
    [Table("Motif")]
    public class Motif
    {
        public int Id { get; set; }

        [ForeignKey("Responsable")]
        public int ResponsableRessourcesId { get; set; }
        public ResponsableRessources Responsable { get; set; }

        [ForeignKey("Fournisseur")]
        public int FournisseurId { get; set; }
        public Fournisseur Fournisseur { get; set; }

        public DateTime Date { get; set; }
        public String Description { get; set; }
    }
}