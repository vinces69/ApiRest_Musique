using ApiRest_Musique_Bibliotheque.Models;

namespace ApiRest_Musique_Bibliotheque.Repositories
{
    public class IUtilisateurRepository
    {
        Task<Utilisateur> CreateUtilisateurAsync(Utilisateur utilisateur);
        Task DeleteUtilisateurAsync(Utilisateur utilisateur);
        Task<IEnumerable<Utilisateur utilisateur>> GetUtilisateursAsync();
        Task<Utilisateur utilisateur> GetUtilisateurByIdAsync(int id);
        Task UpdateUtilisateurAsync(Utilisateur utilisateur);


    }
}
