using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetEtudeDeCas.Models;
using Gestion.Data;
using System.Threading.Tasks;

namespace Gestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly DataContext _context;

        public AccountsController(DataContext context)
        {
            _context = context;
        }

        // POST: api/Accounts/ChefDepartementLogin
        [HttpPost("ChefDepartementLogin")]
        public async Task<ActionResult<User>> ChefDepartementLogin(string login, string password)
        {
            var user = await _context.ChefDepartements.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
            if (user == null)
            {
                return NotFound("Utilisateur non trouvé ou mot de passe incorrect.");
            }
            return Ok(user);
        }

        // POST: api/Accounts/PersonneDepartementLogin
        [HttpPost("PersonneDepartementLogin")]
        public async Task<ActionResult<User>> PersonneDepartementLogin(string login, string password)
        {
            var user = await _context.PersonneDepartement.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
            if (user == null)
            {
                return NotFound("Utilisateur non trouvé ou mot de passe incorrect.");
            }
            return Ok(user);
        }

        // POST: api/Accounts/ResponsableRessourcesLogin
        [HttpPost("ResponsableRessourcesLogin")]
        public async Task<ActionResult<User>> ResponsableRessourcesLogin(string login, string password)
        {
            var user = await _context.ResponsableRessources.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
            if (user == null)
            {
                return NotFound("Utilisateur non trouvé ou mot de passe incorrect.");
            }
            return Ok(user);
        }

        // POST: api/Accounts/FournisseurLogin
        [HttpPost("FournisseurLogin")]
        public async Task<ActionResult<User>> FournisseurLogin(string login, string password)
        {
            var user = await _context.Fournisseurs.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
            if (user == null)
            {
                return NotFound("Utilisateur non trouvé ou mot de passe incorrect.");
            }
            return Ok(user);
        }
    }
}
