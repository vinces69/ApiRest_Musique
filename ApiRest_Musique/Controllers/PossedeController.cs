using ApiRest_Musique_Bibliotheque.Models;
using ApiRest_Musique_Bibliotheque.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest_Musique.Controllers
{
    [Route("api/possede")]
    [ApiController]
    public class PossedeController : ControllerBase
    {
        private readonly IPossedeRepository _possedeRepo;
        private readonly ILogger<PossedeController> _logger;
        public PossedeController(IPossedeRepository possedeRepo, ILogger<PossedeController> logger)
        {
            _possedeRepo = possedeRepo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> AddStatus(Possede possede)
        {
            try
            {
                var newStatus = await _possedeRepo.CreateStatusAsync(possede);
                return CreatedAtAction(nameof(AddStatus), newStatus);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateStatus(Possede possedeToUpdate)
        {
            try
            {
                var existingStatus = await _possedeRepo.GetStatusByIdAsync(possedeToUpdate.IDALBUM, possedeToUpdate.MAILUTILISATEUR);
                if (existingStatus == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = "Status non trouvé"
                    });

                }
                existingStatus.IDALBUM = possedeToUpdate.IDALBUM;
                existingStatus.MAILUTILISATEUR = possedeToUpdate.MAILUTILISATEUR;
                existingStatus.VOULU = possedeToUpdate.VOULU;
                existingStatus.POSSEDE = possedeToUpdate.POSSEDE;
                existingStatus.DATEACHAT = possedeToUpdate.DATEACHAT;
                existingStatus.FAVORIALBUM = possedeToUpdate.FAVORIALBUM;
                await _possedeRepo.UpdateStatusAsync(existingStatus);
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                                       e.Message);
            }
        }
        [HttpDelete("{ida}/{idmail}")]
        public async Task<ActionResult> DeleteStatus(int ida,string idmail)
        {
            try
            {
                var existingStatus = await _possedeRepo.GetStatusByIdAsync(ida,idmail);
                if (existingStatus == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = "Status non trouvé"
                    });

                }

                await _possedeRepo.DeleteStatusAsync(existingStatus);
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
        public async Task<ActionResult> GetStatus()
        {
            try
            {
                var possede = await _possedeRepo.GetStatusAsync();

                return Ok(possede);
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

        [HttpGet("{ida}/{idmail}")]
        public async Task<ActionResult> GetStatus(int ida, string idmail)
        {
            try
            {
                var possede = await _possedeRepo.GetStatusByIdAsync(ida,idmail);
                if (possede == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = "Utilisateur non trouvé"
                    });

                }

                return Ok(possede);
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
