using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacionBackend.Models;
using SistemaFacturacionBackend.Data;

namespace SistemaFacturacionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        [HttpGet("{ruc}")]
        public async Task<ActionResult<Cliente>> GetCliente(string ruc)
        {
            var cliente = await _context.Clientes.FindAsync(ruc);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCliente), new { ruc = cliente.Ruc }, cliente);
        }

        [HttpPut("{ruc}")]
        public async Task<IActionResult> PutCliente(string ruc, Cliente cliente)
        {
            if (ruc != cliente.Ruc)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(ruc))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{ruc}")]
        public async Task<IActionResult> DeleteCliente(string ruc)
        {
            var cliente = await _context.Clientes.FindAsync(ruc);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ClienteExists(string ruc)
        {
            return _context.Clientes.Any(e => e.Ruc == ruc);
        }
    }
}
