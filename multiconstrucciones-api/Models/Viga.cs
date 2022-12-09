using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multiconstrucciones_api.Models;

public partial class Viga
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClvViga { get; set; }

    [ForeignKey("ClvObra")]
    public int ClvObra { get; set; }

    public double LargoViga { get; set; }

    public double PesoViga { get; set; }

    public string Material { get; set; } = null!;

    public DateTime FechaViga { get; set; }

    public int NumEmpleado { get; set; }
    [ForeignKey("ClvDefecto")]
    public int? ClvDefecto { get; set; }
    [ForeignKey("ClvProceso")]
    public int? ClvProceso { get; set; }
}
