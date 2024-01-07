using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest_Musique_Bibliotheque.Models
{

    [Table("utilisateur")]

    public class Utilisateur
    {
        [Key]
        public string MAILUTILISATEUR { get; set; }
        [Required]
        public string LOGINUTILISATEUR { get; set; }
        [Required]
        public string MDPUTILISATEUR { get; set; }
        [Required]
        public string NOMUTILISATEUR { get; set; }
        [Required]
        public string PRENOMUTILISATEUR { get; set; }
        [Required]
        public DateTime? DATENAISSUTILISATEUR { get; set; }
        
    }
}
