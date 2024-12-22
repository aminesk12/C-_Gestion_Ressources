using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjetEtudeDeCas.Models
{
    abstract public class Ressource
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        [Required]
        public Boolean AffectationStatus { get; set; }
    }
}