using System;
using System.Collections.Generic;

namespace Study.Models;

public partial class Materia
{
    public int IdMateria { get; set; }

    public string? Nombre { get; set; }

    public int? IdArea { get; set; }

    public virtual Area? IdAreaNavigation { get; set; }

    public virtual ICollection<Tema> Temas { get; set; } = new List<Tema>();
}
