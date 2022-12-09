using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multiconstrucciones_api.Models
{
    public class Defectos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClvDefecto { get; set; }
        public string Descripcion { get; set; }
    }
}
