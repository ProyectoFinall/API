using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multiconstrucciones_api.Models
{
    public class Proceso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClvProceso { get; set; }
        public String ProcesoNombre { get; set; }
    }
}
