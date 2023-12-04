

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest_Musique_Bibliotheque.Models
{

    [Table("album")]
    public class Album
    {
        [Key]
        public int IDALBUM { get; set; }
        [Required]
        public string? NOMALBUM { get; set; }
        [Required]
        public string? DESCALBUM { get; set; }
        [Required]
        public string? ARTISTEALBUM { get; set; }
        [Required]
        public bool GROUPEALBUM { get; set; }
        public string? POCHETTEALBUM { get; set; }
        public string? COMPOSITEURALBUM { get; set; }




    }
}
