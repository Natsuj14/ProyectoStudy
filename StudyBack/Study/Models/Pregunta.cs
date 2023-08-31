using System;
using System.Collections.Generic;

namespace Study.Models;

public partial class Pregunta
{
    public int IdPregunta { get; set; }

    public int? IdTema { get; set; }

    public string? Enunciado { get; set; }

    public string? Respuesta { get; set; }

    public string? OpcionA { get; set; }

    public string? OpcionB { get; set; }

    public string? OpcionC { get; set; }

    public virtual Tema? IdTemaNavigation { get; set; }
}
