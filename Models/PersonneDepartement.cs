using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetEtudeDeCas.Models
{
    [Table("PersonneDepartement")]
    public class PersonneDepartement : User
    {

        public string NomDepartment { get; set; }

        [ForeignKey("Ressource")]
        public int RessourceId { get; set; }
        public virtual Ressource Ressource { get; set; }
    }
}