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
    public class ModulosController : ControllerBase
    {
        private readonly StudyContext _context;

        public ModulosController(StudyContext context)
        {
            _context = context;
        }

        // GET: api/Modulo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modulo>>> GetModulos()
        {
            var modulos1 = await _context.Modulos.ToListAsync();

            var modulos = from modulo in modulos1
                          select new
                          {
                              modulo.IdModulo,
                              modulo.DescripcionMod
                          };


            return Ok(modulos.ToList());
        }

        // GET: api/Modulo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modulo>> GetModulo(int id)
        {
          if (_context.Modulos == null)
          {
              return NotFound();
          }
            var modulo = await _context.Modulos.FindAsync(id);

            if (modulo == null)
            {
                return NotFound();
            }

            return modulo;
        }

        // PUT: api/Modulo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModulo(int id, Modulo modulo)
        {
            if (id != modulo.IdModulo)
            {
                return BadRequest();
            }

            _context.Entry(modulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuloExists(id))
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

        // POST: api/Modulo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Modulo>> PostModulo(Modulo modulo)
        {
          if (_context.Modulos == null)
          {
              return Problem("Entity set 'StudyContext.Modulos'  is null.");
          }
            _context.Modulos.Add(modulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModulo", new { id = modulo.IdModulo }, modulo);
        }

        // DELETE: api/Modulo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModulo(int id)
        {
            if (_context.Modulos == null)
            {
                return NotFound();
            }
            var modulo = await _context.Modulos.FindAsync(id);
            if (modulo == null)
            {
                return NotFound();
            }

            _context.Modulos.Remove(modulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModuloExists(int id)
        {
            return (_context.Modulos?.Any(e => e.IdModulo == id)).GetValueOrDefault();
        }
    }
}
