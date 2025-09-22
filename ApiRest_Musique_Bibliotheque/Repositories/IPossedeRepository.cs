using ApiRest_Musique_Bibliotheque.Models;

namespace ApiRest_Musique_Bibliotheque.Repositories
{
    public interface IPossedeRepository
    {
        Task<Possede> CreateStatusAsync(Possede possede);
        Task DeleteStatusAsync(Possede possede);
        Task<IEnumerable<Possede>> GetStatusAsync();
        Task<Possede> GetStatusByIdAsync(int ida, string idemail);
        Task UpdateStatusAsync(Possede possede);


    }
}
