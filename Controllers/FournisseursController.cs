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
    public class FournisseursController : ControllerBase
    {
        private readonly DataContext _context;

        public FournisseursController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Fournisseurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fournisseur>>> GetFournisseurs()
        {
            return await _context.Fournisseurs.ToListAsync();
        }

        // GET: api/Fournisseurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fournisseur>> GetFournisseur(int id)
        {
            var fournisseur = await _context.Fournisseurs.FindAsync(id);

            if (fournisseur == null)
            {
                return NotFound();
            }

            return fournisseur;
        }

        // PUT: api/Fournisseurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFournisseur(int id, Fournisseur fournisseur)
        {
            if (id != fournisseur.Id)
            {
                return BadRequest();
            }

            _context.Entry(fournisseur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FournisseurExists(id))
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

        // POST: api/Fournisseurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fournisseur>> PostFournisseur(Fournisseur fournisseur)
        {
            _context.Fournisseurs.Add(fournisseur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFournisseur", new { id = fournisseur.Id }, fournisseur);
        }

        // DELETE: api/Fournisseurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFournisseur(int id)
        {
            var fournisseur = await _context.Fournisseurs.FindAsync(id);
            if (fournisseur == null)
            {
                return NotFound();
            }

            _context.Fournisseurs.Remove(fournisseur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Fournisseurs/AppelsOffresWithDetails
        // Récupère les appels d'offres avec leurs détails et les ressources associées à chaque besoin
        [HttpGet("AppelsOffresWithDetails")]
        public async Task<ActionResult<IEnumerable<object>>> GetAppelsOffresWithDetails()
        {
            var appelsOffresWithDetails = await _context.AppelOffres
                .Include(a => a.Besoins)
                    .ThenInclude(b => b.Ressource)
                .Where(a => a.SendStatus == true)
                .ToListAsync();

            var result = new List<object>();

            foreach (var appelOffre in appelsOffresWithDetails)
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


        private bool FournisseurExists(int id)
        {
            return _context.Fournisseurs.Any(e => e.Id == id);
        }
    }
}
