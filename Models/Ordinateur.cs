using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetEtudeDeCas.Models
{
    [Table("Ordinateur")]
    public class Ordinateur: Ressource
    {
        [Required]
        public string Cpu { get; set; }

        [Required]
        public string DisqueDur { get; set; }

        [Required]
        public string Ecran { get; set; }

        [Required]
        public string Marque { get; set; }

        [Required]
        public string Ram { get; set; }
    }
}