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
    public class MateriaController : ControllerBase
    {
        private readonly StudyContext _context;

        public MateriaController(StudyContext context)
        {
            _context = context;
        }

        // GET: api/Materia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materia>>> GetMateria()
        {
            var materias1 = await _context.Materia.ToListAsync();
            var areas = await _context.Areas.ToListAsync();

            var materias = from materia in materias1
                           join area in areas on materia.IdArea equals area.IdArea
                           select new
                           {
                            materia.IdArea,
                            materia.Nombre,
                            area = area.Nombre
                           };


            return Ok(materias.ToList());
        }

        // GET: api/Materia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetMateria(int id)
        {
          if (_context.Materia == null)
          {
              return NotFound();
          }
            var materia = await _context.Materia.FindAsync(id);

            if (materia == null)
            {
                return NotFound();
            }

            return materia;
        }

        // PUT: api/Materia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria(int id, Materia materia)
        {
            if (id != materia.IdMateria)
            {
                return BadRequest();
            }

            _context.Entry(materia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriaExists(id))
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

        // POST: api/Materia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Materia>> PostMateria(Materia materia)
        {
          if (_context.Materia == null)
          {
              return Problem("Entity set 'StudyContext.Materia'  is null.");
          }
            _context.Materia.Add(materia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMateria", new { id = materia.IdMateria }, materia);
        }

        // DELETE: api/Materia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMateria(int id)
        {
            if (_context.Materia == null)
            {
                return NotFound();
            }
            var materia = await _context.Materia.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }

            _context.Materia.Remove(materia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MateriaExists(int id)
        {
            return (_context.Materia?.Any(e => e.IdMateria == id)).GetValueOrDefault();
        }
    }
}
