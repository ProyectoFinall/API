using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multiconstrucciones_api.Models;

public partial class Obra
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClvObra { get; set; }

    public string NomObra { get; set; } = null!;

    public int CantidadVigas { get; set; }

    public DateTime FechaObra { get; set; }

    public int NumEmpleado { get; set; }

}
