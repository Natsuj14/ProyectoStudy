using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Models;

namespace Study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntasController : ControllerBase
    {
        private readonly StudyContext _context;

        public PreguntasController(StudyContext context)
        {
            _context = context;
        }

        // GET: api/Pregunta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pregunta>>> GetPregunta()
        {
            var preguntas1 = await _context.Pregunta.ToListAsync();
            var temas = await _context.Temas.ToListAsync();

            var preguntas = from pregunta in preguntas1
                           join tema in temas on pregunta.IdTema equals tema.IdTema
                           select new
                           {
                               pregunta.IdPregunta,
                               tema = tema.Nombre,
                               pregunta.Enunciado,
                               pregunta.Respuesta,
                               pregunta.OpcionA,
                               pregunta.OpcionB,
                               pregunta.OpcionC,
                           };


            return Ok(preguntas.ToList());
        }

        // GET: api/Pregunta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pregunta>> GetPregunta(int id)
        {
          if (_context.Pregunta == null)
          {
              return NotFound();
          }
            var pregunta = await _context.Pregunta.FindAsync(id);

            if (pregunta == null)
            {
                return NotFound();
            }

            return pregunta;
        }

        // PUT: api/Pregunta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPregunta(int id, Pregunta pregunta)
        {
            if (id != pregunta.IdPregunta)
            {
                return BadRequest();
            }

            _context.Entry(pregunta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pregunta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pregunta>> PostPregunta(Pregunta pregunta)
        {
          if (_context.Pregunta == null)
          {
              return Problem("Entity set 'StudyContext.Pregunta'  is null.");
          }
            _context.Pregunta.Add(pregunta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPregunta", new { id = pregunta.IdPregunta }, pregunta);
        }

        // DELETE: api/Pregunta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePregunta(int id)
        {
            if (_context.Pregunta == null)
            {
                return NotFound();
            }
            var pregunta = await _context.Pregunta.FindAsync(id);
            if (pregunta == null)
            {
                return NotFound();
            }

            _context.Pregunta.Remove(pregunta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreguntaExists(int id)
        {
            return (_context.Pregunta?.Any(e => e.IdPregunta == id)).GetValueOrDefault();
        }
    }
}
