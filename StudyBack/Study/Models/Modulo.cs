using System;
using System.Collections.Generic;

namespace Study.Models;

public partial class Modulo
{
    public int IdModulo { get; set; }

    public string? DescripcionMod { get; set; }

    public virtual ICollection<RolPermiso> RolPermisos { get; set; } = new List<RolPermiso>();
}
