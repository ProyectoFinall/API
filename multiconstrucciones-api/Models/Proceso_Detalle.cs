using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multiconstrucciones_api.Models
{
    public class Proceso_Detalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClvObra { get; set; }
        public int ClvViga { get; set; }
        public int ClvProceso { get; set; }
        public DateTime FechaProcesoInicia { get; set; }
        public DateTime FechaProcesoSalida { get; set; }
        [ForeignKey("numEmpleado")]
        public int NumEmpleado { get; set; }
        public int PesoViga { get; set; }
    }
}
