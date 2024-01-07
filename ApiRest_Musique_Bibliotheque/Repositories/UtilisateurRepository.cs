using ApiRest_Musique_Bibliotheque.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiRest_Musique_Bibliotheque.Repositories
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private UtilisateurContext _ctx;
        public UtilisateurRepository(UtilisateurContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Utilisateur>> GetUtilisateursAsync()
        {
            var utilisateurs = _ctx.Utilisateurs.ToListAsync();
            return await utilisateurs;
        }

        public async Task<Utilisateur> GetUtilisateurByIdAsync(string id)
        {
            return await _ctx.Utilisateurs.FindAsync(id);
        }
        public async Task<Utilisateur> CreateUtilisateurAsync(Utilisateur utilisateur)
        {
            _ctx.Utilisateurs.Add(utilisateur);
            await _ctx.SaveChangesAsync();
            return utilisateur;
        }

        public async Task UpdateUtilisateurAsync(Utilisateur utilisateur)
        {
            _ctx.Utilisateurs.Update(utilisateur);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteUtilisateurAsync(Utilisateur utilisateur)
        {
            _ctx.Utilisateurs.Remove(utilisateur);
            await _ctx.SaveChangesAsync();
        }

             
    }
}
