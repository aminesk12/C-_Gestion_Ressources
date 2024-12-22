using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetEtudeDeCas.Models
{
    [Table("ChefDepartement")]
    public class ChefDepartement: User
    {
     
        [ForeignKey("Departement")]
        public int DepartementId { get; set; }
        public virtual Departement Departement { get; set; }
    }
}