using System;
using System.Collections.Generic;

namespace Study.Models;

public partial class RolPermiso
{
    public int IdRolPermiso { get; set; }

    public int? IdRol { get; set; }

    public int? IdModulo { get; set; }

    public bool? PermisoPost { get; set; }

    public bool? PermisoDelete { get; set; }

    public bool? PermisoGet { get; set; }

    public bool? PermisoPut { get; set; }

    public bool? PermisoGetById { get; set; }

    public virtual Modulo? IdModuloNavigation { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
