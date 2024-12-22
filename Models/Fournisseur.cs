using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetEtudeDeCas.Models
{
    [Table("Fournisseur")]
    public class Fournisseur: User
    {
     

        [Required]
        public string Lieu { get; set; }

        [Required]
        public string NomSociete { get; set; }
        
        [Required]
        public string Gerant { get; set; }
    }
}