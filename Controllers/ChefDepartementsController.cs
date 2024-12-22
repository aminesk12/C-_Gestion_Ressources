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
    public class ChefDepartementsController : ControllerBase
    {
        private readonly DataContext _context;

        public ChefDepartementsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ChefDepartements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChefDepartement>>> GetChefDepartements()
        {
            return await _context.ChefDepartements.ToListAsync();
        }

        // GET: api/ChefDepartements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChefDepartement>> GetChefDepartement(int id)
        {
            var chefDepartement = await _context.ChefDepartements.FindAsync(id);

            if (chefDepartement == null)
            {
                return NotFound();
            }

            return chefDepartement;
        }

        // PUT: api/ChefDepartements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChefDepartement(int id, ChefDepartement chefDepartement)
        {
            if (id != chefDepartement.Id)
            {
                return BadRequest();
            }

            _context.Entry(chefDepartement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChefDepartementExists(id))
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

        // POST: api/ChefDepartements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChefDepartement>> PostChefDepartement(ChefDepartement chefDepartement)
        {
            _context.ChefDepartements.Add(chefDepartement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChefDepartement", new { id = chefDepartement.Id }, chefDepartement);
        }

        // DELETE: api/ChefDepartements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChefDepartement(int id)
        {
            var chefDepartement = await _context.ChefDepartements.FindAsync(id);
            if (chefDepartement == null)
            {
                return NotFound();
            }

            _context.ChefDepartements.Remove(chefDepartement);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // il faut realiser un endPoint pour recuperer touts les besoins d un departement specifier par DepartementId dans tableau de Besoins
        // GET: api/ChefDepartements/besoins/{DepartementId}
        [HttpGet("besoins/{DepartementId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetBesoinsDepartement(int DepartementId)
        {
            try
            {
                // Récupérer tous les besoins du département spécifié
                var besoins = await _context.Besoins
                    .Where(b => b.DepartementId == DepartementId)
                    .ToListAsync();

                if (besoins == null || !besoins.Any())
                {
                    return NotFound("Aucun besoin trouvé pour ce département.");
                }

                var besoinDetails = new List<object>();

                foreach (var besoin in besoins)
                {
                    // Récupérer la ressource associée au besoin
                    var ressource = await _context.Ressources
                        .FirstOrDefaultAsync(r => r.Id == besoin.RessourceId);

                    if (ressource != null)
                    {
                        // Vérifiez si la ressource est une imprimante
                        var imprimante = await _context.Imprimantes.FindAsync(ressource.Id);
                        if (imprimante != null)
                        {
                            besoinDetails.Add(new
                            {
                                besoin.Id,
                                besoin.Quantite,
                                besoin.RessourceId,
                                besoin.DepartementId,
                                RessourceType = "Imprimante",
                                imprimante.Marque,
                                imprimante.Resolution,
                                imprimante.Vitesse
                            });
                            continue;
                        }

                        // Vérifiez si la ressource est un ordinateur
                        var ordinateur = await _context.Ordinateurs.FindAsync(ressource.Id);
                        if (ordinateur != null)
                        {
                            besoinDetails.Add(new
                            {
                                besoin.Id,
                                besoin.Quantite,
                                besoin.RessourceId,
                                besoin.DepartementId,
                                RessourceType = "Ordinateur",
                                ordinateur.Cpu,
                                ordinateur.DisqueDur,
                                ordinateur.Ecran,
                                ordinateur.Marque,
                                ordinateur.Ram
                            });
                        }
                    }
                }

                return Ok(besoinDetails);
            }
            catch (Exception ex)
            {
                // Gérer l'exception ici
                return StatusCode(StatusCodes.Status500InternalServerError, "Une erreur s'est produite lors de la récupération des besoins.");
            }
        }

        // POST: api/ChefDepartements/envoyerBesoins
        [HttpPost("envoyerBesoins")]
        public async Task<ActionResult> EnvoyerBesoins()
        {
            try
            {
                // Récupérer tous les besoins depuis la table Besoins
                var besoins = await _context.Besoins.ToListAsync();

                if (besoins == null || !besoins.Any())
                {
                    return NotFound("Aucun besoin trouvé dans la base de données.");
                }

                // Créer un nouvel AppelOffre
                var appelOffre = new AppelOffre
                {
                    Date = DateTime.Now,
                    SendStatus = false,
                    Besoins = besoins
                };

                // Ajouter l'appel d'offre dans la base de données
                _context.AppelOffres.Add(appelOffre);
                await _context.SaveChangesAsync();

                return Ok("Les besoins ont été ajoutés à un nouvel appel d'offre.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Une erreur s'est produite lors de l'envoi des besoins.");
            }
        }


        private bool ChefDepartementExists(int id)
        {
            return _context.ChefDepartements.Any(e => e.Id == id);
        }
    }
}
