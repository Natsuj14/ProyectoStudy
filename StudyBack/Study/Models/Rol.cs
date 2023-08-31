using System;
using System.Collections.Generic;

namespace Study.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? DescripcionRol { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();

    public virtual ICollection<RolPermiso> RolPermisos { get; set; } = new List<RolPermiso>();
}
