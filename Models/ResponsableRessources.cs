using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetEtudeDeCas.Models
{
    [Table("ResponsableRessources")]
    public class ResponsableRessources: User
    {
      
        public virtual List<ChefDepartement> ListChefDepartement { get; set; }
    }
}