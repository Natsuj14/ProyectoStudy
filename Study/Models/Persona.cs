using System;
using System.Collections.Generic;

namespace Study.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public int? IdRol { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public int? Edad { get; set; }

    public int? Cc { get; set; }

    public string? Genero { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
