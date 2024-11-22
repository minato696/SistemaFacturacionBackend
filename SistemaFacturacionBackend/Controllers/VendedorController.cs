using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacionBackend.Models;
using SistemaFacturacionBackend.Data;

namespace SistemaFacturacionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendedorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> GetVendedores()
        {
            return await _context.Vendedores.ToListAsync();
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Vendedor>> GetVendedor(int codigo)
        {
            var vendedor = await _context.Vendedores.FindAsync(codigo);
            if (vendedor == null)
            {
                return NotFound();
            }
            return vendedor;
        }

        [HttpPost]
        public async Task<ActionResult<Vendedor>> PostVendedor(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVendedor), new { codigo = vendedor.Codigo }, vendedor);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutVendedor(int codigo, Vendedor vendedor)
        {
            if (codigo != vendedor.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(vendedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendedorExists(codigo))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteVendedor(int codigo)
        {
            var vendedor = await _context.Vendedores.FindAsync(codigo);
            if (vendedor == null)
            {
                return NotFound();
            }

            _context.Vendedores.Remove(vendedor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool VendedorExists(int codigo)
        {
            return _context.Vendedores.Any(e => e.Codigo == codigo);
        }
    }
}
