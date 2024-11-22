using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacionBackend.Data;
using SistemaFacturacionBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaFacturacionBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdenController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orden>>> GetOrdenes()
        {
            return await _context.Ordenes.ToListAsync();
        }

        [HttpGet("{reg}")]
        public async Task<ActionResult<Orden>> GetOrden(int reg)
        {
            var orden = await _context.Ordenes.FirstOrDefaultAsync(o => o.Reg == reg);
            if (orden == null)
            {
                return NotFound();
            }
            return orden;
        }

        [HttpPost]
        public async Task<ActionResult<Orden>> PostOrden(Orden orden)
        {
            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrden), new { reg = orden.Reg }, orden);
        }

        [HttpPut("{reg}")]
        public async Task<IActionResult> PutOrden(int reg, Orden orden)
        {
            if (reg != orden.Reg)
            {
                return BadRequest();
            }

            var ordenExistente = await _context.Ordenes.FirstOrDefaultAsync(o => o.Reg == reg);
            if (ordenExistente == null)
            {
                return NotFound();
            }

            ordenExistente.Neto_S = orden.Neto_S;
            ordenExistente.Neto_Us = orden.Neto_Us;
            ordenExistente.Cliente = orden.Cliente;
            ordenExistente.Producto = orden.Producto;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{reg}")]
        public async Task<IActionResult> DeleteOrden(int reg)
        {
            var orden = await _context.Ordenes.FirstOrDefaultAsync(o => o.Reg == reg);
            if (orden == null)
            {
                return NotFound();
            }

            _context.Ordenes.Remove(orden);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
