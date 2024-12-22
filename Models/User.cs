using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ProjetEtudeDeCas.Models.TypesEnumeres;
using System.Data;

namespace ProjetEtudeDeCas.Models
{
    abstract public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [MinLength(3)]
        public string Password { get; set; }

        [Required]
        public string NomPrenom { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public virtual Role Role { get; set; }
    }


}
