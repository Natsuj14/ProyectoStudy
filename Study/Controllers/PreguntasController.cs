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

        // GET: api/Preguntums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pregunta>>> GetPregunta()
        {
          if (_context.Pregunta == null)
          {
              return NotFound();
          }
            return await _context.Pregunta.ToListAsync();
        }

        // GET: api/Preguntums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pregunta>> GetPreguntum(int id)
        {
          if (_context.Pregunta == null)
          {
              return NotFound();
          }
            var preguntum = await _context.Pregunta.FindAsync(id);

            if (preguntum == null)
            {
                return NotFound();
            }

            return preguntum;
        }

        // PUT: api/Preguntums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreguntum(int id, Pregunta preguntum)
        {
            if (id != preguntum.IdPregunta)
            {
                return BadRequest();
            }

            _context.Entry(preguntum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntumExists(id))
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

        // POST: api/Preguntums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pregunta>> PostPreguntum(Pregunta preguntum)
        {
          if (_context.Pregunta == null)
          {
              return Problem("Entity set 'StudyContext.Pregunta'  is null.");
          }
            _context.Pregunta.Add(preguntum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreguntum", new { id = preguntum.IdPregunta }, preguntum);
        }

        // DELETE: api/Preguntums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreguntum(int id)
        {
            if (_context.Pregunta == null)
            {
                return NotFound();
            }
            var preguntum = await _context.Pregunta.FindAsync(id);
            if (preguntum == null)
            {
                return NotFound();
            }

            _context.Pregunta.Remove(preguntum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreguntumExists(int id)
        {
            return (_context.Pregunta?.Any(e => e.IdPregunta == id)).GetValueOrDefault();
        }
    }
}
