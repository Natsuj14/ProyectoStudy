using System;
using System.Collections.Generic;

namespace Study.Models;

public partial class Tema
{
    public int IdTema { get; set; }

    public int? IdMateria { get; set; }

    public string? Nombre { get; set; }

    public string? Contenido { get; set; }

    public virtual Materia? IdMateriaNavigation { get; set; }

    public virtual ICollection<Pregunta> Pregunta { get; set; } = new List<Pregunta>();
}
