using ApiRest_Musique_Bibliotheque.Models;
using ApiRest_Musique_Bibliotheque.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest_Musique.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepo;
        private readonly ILogger<AlbumController> _logger;
        public AlbumController(IAlbumRepository albumRepo, ILogger<AlbumController> logger)
        {
            _albumRepo = albumRepo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> AddAlbum(Album album)
        {
            try
            {
                var newAlbum = await _albumRepo.CreateAlbumAsync(album);
                return CreatedAtAction(nameof(AddAlbum), newAlbum);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateAlbum(Album albumToUpdate)
        {
            try
            {
                var existingAlbum = await _albumRepo.GetAlbumsByIdAsync(albumToUpdate.IDALBUM);
                if (existingAlbum == null)
                {
                    return NotFound(new{
                    StatusCode=404,
                    message = "Album non trouvé"
                    });                 
                        
                }
                existingAlbum.NOMALBUM = albumToUpdate.NOMALBUM;
                existingAlbum.POCHETTEALBUM = albumToUpdate.POCHETTEALBUM;
                existingAlbum.DESCALBUM = albumToUpdate.DESCALBUM;
                existingAlbum.GROUPEALBUM = albumToUpdate.GROUPEALBUM;
                existingAlbum.COMPOSITEURALBUM = albumToUpdate.COMPOSITEURALBUM;
                existingAlbum.ARTISTEALBUM = albumToUpdate.ARTISTEALBUM;
                await _albumRepo.UpdateAlbumAsync(existingAlbum);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAlbum(int id)
        {
            try
            {
                var existingAlbum = await _albumRepo.GetAlbumsByIdAsync(id);
                if (existingAlbum == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = "Album non trouvé"
                    });

                }
                
                await _albumRepo.DeleteAlbumAsync(existingAlbum);
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
                var album = await _albumRepo.GetAlbumsAsync();
                
                return Ok(album);
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
        public async Task<ActionResult> GetAlbum(int id)
        {
            try
            {
                var album = await _albumRepo.GetAlbumsByIdAsync(id);
                if (album == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = "Album non trouvé"
                    });

                }

                return Ok(album);
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
