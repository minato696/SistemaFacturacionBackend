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
    public class VendedorAntController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendedorAntController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendedorAnt>>> GetVendedoresAnt()
        {
            return await _context.VendedoresAnt.ToListAsync();
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<VendedorAnt>> GetVendedorAnt(int codigo)
        {
            var vendedorAnt = await _context.VendedoresAnt.FirstOrDefaultAsync(v => v.Codigo == codigo);
            if (vendedorAnt == null)
            {
                return NotFound();
            }
            return vendedorAnt;
        }

        [HttpPost]
        public async Task<ActionResult<VendedorAnt>> PostVendedorAnt(VendedorAnt vendedorAnt)
        {
            _context.VendedoresAnt.Add(vendedorAnt);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVendedorAnt), new { codigo = vendedorAnt.Codigo }, vendedorAnt);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutVendedorAnt(int codigo, VendedorAnt vendedorAnt)
        {
            if (codigo != vendedorAnt.Codigo)
            {
                return BadRequest();
            }

            var vendedorAntExistente = await _context.VendedoresAnt.FirstOrDefaultAsync(v => v.Codigo == codigo);
            if (vendedorAntExistente == null)
            {
                return NotFound();
            }

            vendedorAntExistente.Nombre = vendedorAnt.Nombre;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteVendedorAnt(int codigo)
        {
            var vendedorAnt = await _context.VendedoresAnt.FirstOrDefaultAsync(v => v.Codigo == codigo);
            if (vendedorAnt == null)
            {
                return NotFound();
            }

            _context.VendedoresAnt.Remove(vendedorAnt);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
