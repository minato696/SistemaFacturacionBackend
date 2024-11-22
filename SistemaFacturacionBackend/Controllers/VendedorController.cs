using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionBackend.Data;
using SistemaFacturacionBackend.Data.Models;
using SistemaFacturacionBackend.Models;

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
        public IActionResult GetVendedores()
        {
            var vendedores = _context.Vendedores.ToList();
            return Ok(vendedores);
        }

        [HttpGet("{codigo}")]
        public IActionResult GetVendedorByCodigo(int codigo)
        {
            var vendedor = _context.Vendedores.Find(codigo);
            if (vendedor == null) return NotFound();
            return Ok(vendedor);
        }

        [HttpPost]
        public IActionResult CreateVendedor([FromBody] Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVendedorByCodigo), new { codigo = vendedor.Codigo }, vendedor);
        }

        [HttpPut("{codigo}")]
        public IActionResult UpdateVendedor(int codigo, [FromBody] Vendedor vendedor)
        {
            if (codigo != vendedor.Codigo) return BadRequest();

            var existingVendedor = _context.Vendedores.Find(codigo);
            if (existingVendedor == null) return NotFound();

            existingVendedor.Nombre = vendedor.Nombre;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public IActionResult DeleteVendedor(int codigo)
        {
            var vendedor = _context.Vendedores.Find(codigo);
            if (vendedor == null) return NotFound();

            _context.Vendedores.Remove(vendedor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
