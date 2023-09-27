using System;
using System.Collections.Generic;

namespace Study.Models;

public partial class Prueba
{
    public int IdPrueba { get; set; }

    public int? IdUsuario { get; set; }

    public double? Duracion { get; set; }

    public int? CantidadPreguntas { get; set; }

    public double? Calificacion { get; set; }

    public DateTime? FechaPrueba { get; set; }

    public int? IdArea { get; set; }

    public virtual Area? IdAreaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
