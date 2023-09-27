using System;
using System.Collections.Generic;

namespace Study.Models;

public partial class Estadistica
{
    public int IdEstadistica { get; set; }

    public int? IdUsuario { get; set; }

    public int? TotalPruebas { get; set; }

    public double? TiempoPromedio { get; set; }

    public double? Promedio { get; set; }

    public string? MejorMateria { get; set; }

    public string? PeorMateria { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
