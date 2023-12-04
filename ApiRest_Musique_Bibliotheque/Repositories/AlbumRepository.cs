using ApiRest_Musique_Bibliotheque.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiRest_Musique_Bibliotheque.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private AlbumContext _ctx;
        public AlbumRepository(AlbumContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<IEnumerable<Album>> GetAlbumsAsync()
        {
            var albums = _ctx.Albums.ToListAsync();
            return await albums;
        }

        public async Task<Album> GetAlbumsByIdAsync(int id)
        {
            return await _ctx.Albums.FindAsync(id);
        }

        public async Task<Album> CreateAlbumAsync(Album album)
        {
            _ctx.Albums.Add(album);
            await _ctx.SaveChangesAsync();
            return album;
        }

        public async Task UpdateAlbumAsync(Album album)
        {
            _ctx.Albums.Update(album);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAlbumAsync(Album album)
        {
            _ctx.Albums.Remove(album);
            await _ctx.SaveChangesAsync();
        }


    }
}
