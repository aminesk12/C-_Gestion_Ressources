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
    public class ResponsableRessourcesController : ControllerBase
    {
        private readonly DataContext _context;

        public ResponsableRessourcesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ResponsableRessources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponsableRessources>>> GetResponsableRessources()
        {
            return await _context.ResponsableRessources.ToListAsync();
        }

        // GET: api/ResponsableRessources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponsableRessources>> GetResponsableRessources(int id)
        {
            var responsableRessources = await _context.ResponsableRessources.FindAsync(id);

            if (responsableRessources == null)
            {
                return NotFound();
            }

            return responsableRessources;
        }

        // PUT: api/ResponsableRessources/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponsableRessources(int id, ResponsableRessources responsableRessources)
        {
            if (id != responsableRessources.Id)
            {
                return BadRequest();
            }

            _context.Entry(responsableRessources).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResponsableRessourcesExists(id))
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

        // POST: api/ResponsableRessources
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponsableRessources>> PostResponsableRessources(ResponsableRessources responsableRessources)
        {
            _context.ResponsableRessources.Add(responsableRessources);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResponsableRessources", new { id = responsableRessources.Id }, responsableRessources);
        }

        // DELETE: api/ResponsableRessources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponsableRessources(int id)
        {
            var responsableRessources = await _context.ResponsableRessources.FindAsync(id);
            if (responsableRessources == null)
            {
                return NotFound();
            }

            _context.ResponsableRessources.Remove(responsableRessources);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // GET: api/AppelOffresWithDetails
        [HttpGet("AppelOffresWithDetails")]
        public async Task<ActionResult<IEnumerable<object>>> GetAppelOffresWithDetails()
        {
            var appelOffresWithDetails = await _context.AppelOffres
                .Include(a => a.Besoins)
                    .ThenInclude(b => b.Ressource)
                .ToListAsync();

            var result = new List<object>();

            foreach (var appelOffre in appelOffresWithDetails)
            {
                var besoinDetails = new List<object>();

                foreach (var besoin in appelOffre.Besoins)
                {
                    object ressourceDetails = null;

                    if (besoin.Ressource is Imprimante)
                    {
                        var imprimante = _context.Imprimantes.Find(besoin.RessourceId);
                        if (imprimante != null)
                        {
                            ressourceDetails = new
                            {
                                Type = "Imprimante",
                                Marque = imprimante.Marque,
                                Resolution = imprimante.Resolution,
                                Vitesse = imprimante.Vitesse
                            };
                        }
                    }
                    else if (besoin.Ressource is Ordinateur)
                    {
                        var ordinateur = _context.Ordinateurs.Find(besoin.RessourceId);
                        if (ordinateur != null)
                        {
                            ressourceDetails = new
                            {
                                Type = "Ordinateur",
                                CPU = ordinateur.Cpu,
                                DisqueDur = ordinateur.DisqueDur,
                                Ecran = ordinateur.Ecran,
                                Marque = ordinateur.Marque,
                                RAM = ordinateur.Ram
                            };
                        }
                    }

                    var besoinDetail = new
                    {
                        Id = besoin.Id,
                        Quantite = besoin.Quantite,
                        Ressource = ressourceDetails
                    };

                    besoinDetails.Add(besoinDetail);
                }

                var appelOffreDetail = new
                {
                    Id = appelOffre.Id,
                    Date = appelOffre.Date,
                    Besoins = besoinDetails
                };

                result.Add(appelOffreDetail);
            }

            return result;
        }
        // je doit faire un endpoint pour valider ou bien rejeter l OFFRE
        // scenario suivant :
        // une fois accepter send Status recoit = true
        // PUT: api/ResponsableRessources/{id}/{response}
        // Met à jour l'offre avec l'ID spécifié en acceptant ou rejetant
        [HttpPut("latest/{response}")]
        public async Task<IActionResult> PutResponsableRessourcesLatest(bool response)
        {
            try
            {
                // Sélectionner le dernier ID de la base de données AppelOffres
                var dernierId = await _context.AppelOffres
                    .OrderByDescending(a => a.Id)
                    .Select(a => a.Id)
                    .FirstOrDefaultAsync();

                var appelOffre = await _context.AppelOffres.FindAsync(dernierId);

                if (appelOffre == null)
                {
                    return NotFound();
                }

                appelOffre.SendStatus = response;

                _context.Entry(appelOffre).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur lors de la mise à jour de l'offre.");
            }
        }

        private bool ResponsableRessourcesExists(int id)
        {
            return _context.ResponsableRessources.Any(e => e.Id == id);
        }
    }
}
