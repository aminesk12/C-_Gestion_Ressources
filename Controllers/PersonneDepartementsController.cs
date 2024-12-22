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
    public class PersonneDepartementsController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonneDepartementsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PersonneDepartements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonneDepartement>>> GetPersonneDepartement()
        {
            return await _context.PersonneDepartement.ToListAsync();
        }

        // GET: api/PersonneDepartements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonneDepartement>> GetPersonneDepartement(int id)
        {
            var personneDepartement = await _context.PersonneDepartement.FindAsync(id);

            if (personneDepartement == null)
            {
                return NotFound();
            }

            return personneDepartement;
        }

        // PUT: api/PersonneDepartements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonneDepartement(int id, PersonneDepartement personneDepartement)
        {
            if (id != personneDepartement.Id)
            {
                return BadRequest();
            }

            _context.Entry(personneDepartement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonneDepartementExists(id))
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

        // POST: api/PersonneDepartements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonneDepartement>> PostPersonneDepartement(PersonneDepartement personneDepartement)
        {
            _context.PersonneDepartement.Add(personneDepartement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonneDepartement", new { id = personneDepartement.Id }, personneDepartement);
        }

        // DELETE: api/PersonneDepartements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonneDepartement(int id)
        {
            var personneDepartement = await _context.PersonneDepartement.FindAsync(id);
            if (personneDepartement == null)
            {
                return NotFound();
            }

            _context.PersonneDepartement.Remove(personneDepartement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Ajouter Besoin
        // il faut recuperer DepartementId depuis session 
        // POST: api/Besoins/ajouter/imprimante/{quantite}/{marque}/{resolution}/{vitesse}/{departementId}
        // POST: api/Besoins/ajouter/imprimante/{quantite}/{marque}/{resolution}/{vitesse}/{idPersonne}
        [HttpPost("ajouter/imprimante/{quantite}/{marque}/{resolution}/{vitesse}/{idPersonne}")]
        public async Task<ActionResult<bool>> AddImprimante(int quantite, string marque, string resolution, string vitesse, int idPersonne)
        {
            try
            {
                // Récupérer le départementId à partir de la table PersonneDepartement en utilisant idPersonne
                var personneDepartement = await _context.PersonneDepartement.FirstOrDefaultAsync(pd => pd.Id == idPersonne);
                if (personneDepartement == null)
                {
                    return NotFound("Personne non trouvée");
                }
                var nameDepartement = personneDepartement.NomDepartment;
                var departement = await _context.Departements.FirstOrDefaultAsync(d => d.Nom == nameDepartement);
                if (departement == null)
                {
                    return NotFound("Département non trouvé");
                }
                var departementId = departement.Id;

                // Créer une nouvelle ressource d'imprimante
                var imprimante = new Imprimante
                {
                    Marque = marque,
                    Resolution = resolution,
                    Vitesse = vitesse
                };

                // Ajouter l'imprimante dans la base de données
                _context.Imprimantes.Add(imprimante);
                await _context.SaveChangesAsync();

                // Créer un nouveau besoin pour l'imprimante et l'associer au département
                var besoin = new Besoin
                {
                    Quantite = quantite,
                    RessourceId = imprimante.Id, // Utiliser directement l'ID de l'imprimante
                    DepartementId = departementId
                };

                // Ajouter le besoin dans la base de données
                _context.Besoins.Add(besoin);
                await _context.SaveChangesAsync();

                return true; // Ajout réussi
            }
            catch (Exception ex)
            {
                // Vous pouvez gérer l'exception ici ou simplement laisser passer
                // Retourner false en cas d'échec d'ajout
                return false;
            }
        }


        // POST: api/Besoins/ajouter/ordinateur/{quantite}/{cpu}/{disqueDur}/{ecran}/{marque}/{ram}/{idPersonne}
        [HttpPost("ajouter/ordinateur/{quantite}/{cpu}/{disqueDur}/{ecran}/{marque}/{ram}/{idPersonne}")]
        public async Task<ActionResult<bool>> AddOrdinateur(int quantite, string cpu, string disqueDur, string ecran, string marque, string ram, int idPersonne)
        {
            try
            {
                // Récupérer le départementId à partir de la table PersonneDepartement en utilisant idPersonne
                var personneDepartement = await _context.PersonneDepartement.FirstOrDefaultAsync(pd => pd.Id == idPersonne);
                if (personneDepartement == null)
                {
                    return NotFound("Personne non trouvée");
                }
                var nameDepartement = personneDepartement.NomDepartment;
                var departement = await _context.Departements.FirstOrDefaultAsync(d => d.Nom == nameDepartement);
                if (departement == null)
                {
                    return NotFound("Département non trouvé");
                }
                var departementId = departement.Id;

                // Créer un nouvel ordinateur
                var ordinateur = new Ordinateur
                {
                    Cpu = cpu,
                    DisqueDur = disqueDur,
                    Ecran = ecran,
                    Marque = marque,
                    Ram = ram
                };

                // Ajouter l'ordinateur dans la base de données
                _context.Ordinateurs.Add(ordinateur);
                await _context.SaveChangesAsync();

                // Créer un nouveau besoin pour l'ordinateur et l'associer au département
                var besoin = new Besoin
                {
                    Quantite = quantite,
                    RessourceId = ordinateur.Id,
                    DepartementId = departementId
                };

                // Ajouter le besoin dans la base de données
                _context.Besoins.Add(besoin);
                await _context.SaveChangesAsync();

                return true; // Ajout réussi
            }
            catch (Exception ex)
            {
                // Gérer l'exception ici ou simplement laisser passer
                // Retourner false en cas d'échec d'ajout
                return false;
            }
        }






        private bool PersonneDepartementExists(int id)
        {
            return _context.PersonneDepartement.Any(e => e.Id == id);
        }
    }
}
