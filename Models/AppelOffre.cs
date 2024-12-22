using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjetEtudeDeCas.Models
{
    public class AppelOffre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool SendStatus { get; set; }
        public virtual List<Besoin> Besoins { get; set; }
    }
}