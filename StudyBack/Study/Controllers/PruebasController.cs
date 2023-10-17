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
    public class PruebaController : ControllerBase
    {
        private readonly StudyContext _context;

        public PruebaController(StudyContext context)
        {
            _context = context;
        }

        // GET: api/Prueba
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prueba>>> GetPruebas()
        {
            var prueba = await _context.Pruebas.ToListAsync();
            var usuario = await _context.Usuarios.ToListAsync();
            var area = await _context.Areas.ToListAsync();
            var pruebas =

                from Pruebas
                in prueba
                join Usuarios
                in usuario
                on Pruebas.IdUsuario equals Usuarios.IdUsuario
                join Areas
                in area
                on Pruebas.IdArea equals Areas.IdArea

                        select new
          {
                            Pruebas.IdPrueba,
                            Usuarios.Nickname,
                            Pruebas.Duracion,
                            Pruebas.CantidadPreguntas,
                            Pruebas.Calificacion,
                            Pruebas.FechaPrueba,
                            Areas.Nombre
                        };

            return Ok(pruebas.ToList());
        }

        // GET: api/Prueba/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prueba>> GetPrueba(int id)
        {
          if (_context.Pruebas == null)
          {
              return NotFound();
          }
            var prueba = await _context.Pruebas.FindAsync(id);

            if (prueba == null)
            {
                return NotFound();
            }

            return prueba;
        }

        // PUT: api/Prueba/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrueba(int id, Prueba prueba)
        {
            if (id != prueba.IdPrueba)
            {
                return BadRequest();
            }

            _context.Entry(prueba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PruebaExists(id))
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

        // POST: api/Prueba
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prueba>> PostPrueba(Prueba prueba)
        {
          if (_context.Pruebas == null)
          {
              return Problem("Entity set 'StudyContext.Pruebas'  is null.");
          }
            _context.Pruebas.Add(prueba);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrueba", new { id = prueba.IdPrueba }, prueba);
        }

        // DELETE: api/Prueba/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrueba(int id)
        {
            if (_context.Pruebas == null)
            {
                return NotFound();
            }
            var prueba = await _context.Pruebas.FindAsync(id);
            if (prueba == null)
            {
                return NotFound();
            }

            _context.Pruebas.Remove(prueba);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PruebaExists(int id)
        {
            return (_context.Pruebas?.Any(e => e.IdPrueba == id)).GetValueOrDefault();
        }
    }
}
