using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjetEtudeDeCas.Models
{
    public class Departement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public double Budget { get; set; }

        public virtual List<PersonneDepartement> PersonnesDepartement { get; set; }
    }
}