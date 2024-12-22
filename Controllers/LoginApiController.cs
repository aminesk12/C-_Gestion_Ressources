using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestion.Data;
using ProjetEtudeDeCas.Models;

namespace Gestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        private readonly DataContext _context;

        public LoginApiController(DataContext context)
        {
            _context = context;
        }

        // GET: api/LoginApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/LoginApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/LoginApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LoginApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/LoginApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // GET: api/LoginApi/login/password
        [HttpGet("{login}/{password}")]
        public async Task<ActionResult<User>> GetUser(string login, string password)
        {
            // Recherche de l'utilisateur dans la base de données en fonction du nom d'utilisateur et du mot de passe
            var user = await _context.User.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);

            if (user == null)
            {
                // Si aucun utilisateur correspondant n'est trouvé, retourner NotFound
                return NotFound();
            }

            // Si un utilisateur correspondant est trouvé, le retourner
            return user;
        }

    

    private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
