using ApiRest_Musique_Bibliotheque.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiRest_Musique_Bibliotheque.Repositories
{
    public class PossedeRepository : IPossedeRepository
    {
        private PossedeContext _ctx;
        public PossedeRepository(PossedeContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Possede>> GetStatusAsync()
        {
            var status = _ctx.Possedes.ToListAsync();
            return await status;
        }

        public async Task<Possede> GetStatusByIdAsync(int id,string email)
        {
            return await _ctx.Possedes.FindAsync(id,email);
        }
        public async Task<Possede> CreateStatusAsync(Possede possede)
        {
            _ctx.Possedes.Add(possede);
            await _ctx.SaveChangesAsync();
            return possede;
        }

        public async Task UpdateStatusAsync(Possede possede)
        {
            _ctx.Possedes.Update(possede);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteStatusAsync(Possede possede)
        {
            _ctx.Possedes.Remove(possede);
            await _ctx.SaveChangesAsync();
        }

             
    }
}
