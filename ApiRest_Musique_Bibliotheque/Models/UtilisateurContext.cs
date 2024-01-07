using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApiRest_Musique_Bibliotheque.Models
{
    public class UtilisateurContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UtilisateurContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("bddlocal");
        }
        public DbSet<Utilisateur> Utilisateurs { get; set; }    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }


    }
}
