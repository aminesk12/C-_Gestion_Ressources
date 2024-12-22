using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetEtudeDeCas.Models
{
    [Table("Enseignant")]
    public class Enseignant: PersonneDepartement
    {
        

        [Required]
        public string Laboratoire { get; set; }
    }
}