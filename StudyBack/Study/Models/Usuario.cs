using System;
using System.Collections.Generic;

namespace Study.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int? IdPersona { get; set; }

    public string? Nickname { get; set; }

    public string? Contraseña { get; set; }

    public virtual ICollection<Estadistica> Estadisticas { get; set; } = new List<Estadistica>();

    public virtual Persona? IdPersonaNavigation { get; set; }

    public virtual ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();

    public virtual ICollection<Prueba> Pruebas { get; set; } = new List<Prueba>();
}
