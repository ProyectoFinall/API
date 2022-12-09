using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multiconstrucciones_api.Models;

public partial class Empleado
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int NumEmpleado { get; set; }

    public string NomEmpleado { get; set; } = null!;

    public string Apaterno { get; set; } = null!;

    public string Amaterno { get; set; } = null!;

    public string Puesto { get; set; } = null!;
}
