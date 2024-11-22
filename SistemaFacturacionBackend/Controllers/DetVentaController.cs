using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacionBackend.Data;
using SistemaFacturacionBackend.Data.Models; // Importa el espacio de nombres que contiene tus modelos
using SistemaFacturacionBackend.Models;

namespace SistemaFacturacionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetVentaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DetVentaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetVenta>>> GetDetVentas()
        {
            return await _context.DetVentas.ToListAsync();
        }

        [HttpGet("{codVta}")]
        public async Task<ActionResult<DetVenta>> GetDetVenta(string codVta)
        {
            var detVenta = await _context.DetVentas.FindAsync(codVta);
            if (detVenta == null)
            {
                return NotFound();
            }
            return detVenta;
        }

        [HttpPost]
        public async Task<ActionResult<DetVenta>> PostDetVenta(DetVenta detVenta)
        {
            _context.DetVentas.Add(detVenta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDetVenta), new { codVta = detVenta.CodVta }, detVenta);
        }

        [HttpDelete("{codVta}")]
        public async Task<IActionResult> DeleteDetVenta(string codVta)
        {
            var detVenta = await _context.DetVentas.FindAsync(codVta);
            if (detVenta == null)
            {
                return NotFound();
            }

            _context.DetVentas.Remove(detVenta);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
