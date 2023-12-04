using ApiRest_Musique_Bibliotheque.Models;

namespace ApiRest_Musique_Bibliotheque.Repositories
{
    public interface IAlbumRepository
    {
        Task<Album> CreateAlbumAsync(Album album);
        Task DeleteAlbumAsync(Album album);
        Task<IEnumerable<Album>> GetAlbumsAsync();
        Task<Album> GetAlbumsByIdAsync(int id);
        Task UpdateAlbumAsync(Album album);
    }
}