using System;
using System.Collections.Generic;

namespace Study.Models;

public partial class Area
{
    public int IdArea { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();

    public virtual ICollection<Prueba> Pruebas { get; set; } = new List<Prueba>();
}
