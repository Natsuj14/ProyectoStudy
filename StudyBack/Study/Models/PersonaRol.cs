using System;
using System.Collections.Generic;

namespace Study.Models;

public partial class PersonaRol
{
    public int IdPersona { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Edad { get; set; }

    public string? Genero { get; set; }

    public string? Correo { get; set; }

    public string? DescripcionRol { get; set; }

}

