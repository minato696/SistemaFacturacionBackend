using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacionBackend.Data;
using SistemaFacturacionBackend.Data.Models; // Importa el espacio de nombres que contiene tus modelos
using SistemaFacturacionBackend.Models;

namespace SistemaFacturacionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescripcionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DescripcionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Descripcion>>> GetDescripciones()
        {
            return await _context.Descripciones.ToListAsync();
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Descripcion>> GetDescripcion(int codigo)
        {
            var descripcion = await _context.Descripciones.FindAsync(codigo);
            if (descripcion == null)
            {
                return NotFound();
            }
            return descripcion;
        }

        [HttpPost]
        public async Task<ActionResult<Descripcion>> PostDescripcion(Descripcion descripcion)
        {
            _context.Descripciones.Add(descripcion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDescripcion), new { codigo = descripcion.Codigo }, descripcion);
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteDescripcion(int codigo)
        {
            var descripcion = await _context.Descripciones.FindAsync(codigo);
            if (descripcion == null)
            {
                return NotFound();
            }

            _context.Descripciones.Remove(descripcion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
