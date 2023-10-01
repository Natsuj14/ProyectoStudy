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
    public class IngresoController : ControllerBase
    {
        private readonly StudyContext _context;

        public IngresoController(StudyContext context)
        {
            _context = context;
        }

        // GET: api/Ingreso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingreso>>> GetIngresos()
        {
            var ingreso = await _context.Ingresos.ToListAsync();
            var usuario = await _context.Usuarios.ToListAsync();

            var ingresos = from Ingresos
                        in ingreso
                        join Usuarios
                        in usuario
                        on Ingresos.IdIngreso equals Usuarios.IdUsuario

                        select new
                        {
                            Ingresos.IdIngreso,
                            Usuarios.Nickname,
                            Ingresos.Fecha,
                            Ingresos.Tipo
                        };

            return Ok(ingresos.ToList());
        }

        // GET: api/Ingreso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingreso>> GetIngreso(int id)
        {
          if (_context.Ingresos == null)
          {
              return NotFound();
          }
            var ingreso = await _context.Ingresos.FindAsync(id);

            if (ingreso == null)
            {
                return NotFound();
            }

            return ingreso;
        }

        // PUT: api/Ingreso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngreso(int id, Ingreso ingreso)
        {
            if (id != ingreso.IdIngreso)
            {
                return BadRequest();
            }

            _context.Entry(ingreso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngresoExists(id))
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

        // POST: api/Ingreso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingreso>> PostIngreso(Ingreso ingreso)
        {
          if (_context.Ingresos == null)
          {
              return Problem("Entity set 'StudyContext.Ingresos'  is null.");
          }
            _context.Ingresos.Add(ingreso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngreso", new { id = ingreso.IdIngreso }, ingreso);
        }

        // DELETE: api/Ingreso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngreso(int id)
        {
            if (_context.Ingresos == null)
            {
                return NotFound();
            }
            var ingreso = await _context.Ingresos.FindAsync(id);
            if (ingreso == null)
            {
                return NotFound();
            }

            _context.Ingresos.Remove(ingreso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngresoExists(int id)
        {
            return (_context.Ingresos?.Any(e => e.IdIngreso == id)).GetValueOrDefault();
        }
    }
}
