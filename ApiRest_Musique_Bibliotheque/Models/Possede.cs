

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest_Musique_Bibliotheque.Models
{

    [Table("possede")]
    public class Possede
    {
        
        public int IDALBUM { get; set; }
        [Required]
        public string MAILUTILISATEUR { get; set; }
        [Required]

        public bool VOULU { get; set; }
        public bool POSSEDE { get; set; }
        public DateTime? DATEACHAT { get; set; }
        public bool FAVORIALBUM { get; set; }
        

    }
}
