using ApiRest_Musique_Bibliotheque.Models;
using ApiRest_Musique_Bibliotheque.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest_Musique.Controllers
{
    [Route("api/utilisateurs")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly IUtilisateurRepository _utilisateurRepo;
        private readonly ILogger<UtilisateurController> _logger;
        public UtilisateurController(IUtilisateurRepository utilisateurRepo, ILogger<UtilisateurController> logger)
        {
            _utilisateurRepo = utilisateurRepo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> AddUtilisateur(Utilisateur utilisateur)
        {
            try
            {
                var newUtilisateur = await _utilisateurRepo.CreateUtilisateurAsync(utilisateur);
                return CreatedAtAction(nameof(AddUtilisateur), newUtilisateur);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUtilisateur(Utilisateur utilisateurToUpdate)
        {
            try
            {
                var existingUtilisateur = await _utilisateurRepo.GetUtilisateurByIdAsync(utilisateurToUpdate.MAILUTILISATEUR);
                if (existingUtilisateur == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = "Utilisateur non trouvé"
                    });

                }
                existingUtilisateur.NOMUTILISATEUR = utilisateurToUpdate.NOMUTILISATEUR;
                existingUtilisateur.PRENOMUTILISATEUR = utilisateurToUpdate.PRENOMUTILISATEUR;
                existingUtilisateur.LOGINUTILISATEUR = utilisateurToUpdate.LOGINUTILISATEUR;
                existingUtilisateur.MDPUTILISATEUR = utilisateurToUpdate.MDPUTILISATEUR;
                existingUtilisateur.MAILUTILISATEUR = utilisateurToUpdate.MAILUTILISATEUR;
                existingUtilisateur.DATENAISSUTILISATEUR = utilisateurToUpdate.DATENAISSUTILISATEUR;
                await _utilisateurRepo.UpdateUtilisateurAsync(existingUtilisateur);
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                                       e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUtilisateur(string id)
        {
            try
            {
                var existingUtilisateur = await _utilisateurRepo.GetUtilisateurByIdAsync(id);
                if (existingUtilisateur == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = "Album non trouvé"
                    });

                }

                await _utilisateurRepo.DeleteUtilisateurAsync(existingUtilisateur);
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        StatusCode = 500,
                        message = e.Message
                    });
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAlbum()
        {
            try
            {
                var utilisateur = await _utilisateurRepo.GetUtilisateursAsync();

                return Ok(utilisateur);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        StatusCode = 500,
                        message = e.Message
                    });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUtilisateur(string id)
        {
            try
            {
                var utilisateur = await _utilisateurRepo.GetUtilisateurByIdAsync(id);
                if (utilisateur == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = "Utilisateur non trouvé"
                    });

                }

                return Ok(utilisateur);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        StatusCode = 500,
                        message = e.Message
                    });
            }
        }

    }
}
