using System;
using System.Collections.Generic;

namespace Study.Models;

public partial class Ingreso
{
    public int IdIngreso { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Tipo { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
