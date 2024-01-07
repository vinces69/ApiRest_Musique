using ApiRest_Musique_Bibliotheque.Models;

namespace ApiRest_Musique_Bibliotheque.Repositories
{
    public interface IUtilisateurRepository
    {
        Task<Utilisateur> CreateUtilisateurAsync(Utilisateur utilisateur);
        Task DeleteUtilisateurAsync(Utilisateur utilisateur);
        Task<IEnumerable<Utilisateur>> GetUtilisateursAsync();
        Task<Utilisateur> GetUtilisateurByIdAsync(string id);
        Task UpdateUtilisateurAsync(Utilisateur utilisateur);


    }
}
