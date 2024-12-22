using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetEtudeDeCas.Models
{
    [Table("Imprimante")]
    public class Imprimante: Ressource
    {
        [Required]
        public string Marque { get; set; }

        [Required]
        public string Resolution { get; set; }

        [Required]
        public string Vitesse { get; set; }
    }
}