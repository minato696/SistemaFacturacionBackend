using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionBackend.Data;
using SistemaFacturacionBackend.Data.Models;
using SistemaFacturacionBackend.Models;

namespace SistemaFacturacionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VentasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetVentas()
        {
            var ventas = _context.Ventas.ToList();
            return Ok(ventas);
        }

        [HttpGet("{codigo}")]
        public IActionResult GetVentaByCodigo(string codigo)
        {
            var venta = _context.Ventas.FirstOrDefault(v => v.CodVta == codigo);
            if (venta == null) return NotFound();
            return Ok(venta);
        }

        [HttpPost]
        public IActionResult CreateVenta([FromBody] Venta venta)
        {
            _context.Ventas.Add(venta);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVentaByCodigo), new { codigo = venta.CodVta }, venta);
        }

        [HttpPut("{codigo}")]
        public IActionResult UpdateVenta(string codigo, [FromBody] Venta venta)
        {
            if (codigo != venta.CodVta) return BadRequest();

            var existingVenta = _context.Ventas.FirstOrDefault(v => v.CodVta == codigo);
            if (existingVenta == null) return NotFound();

            existingVenta.Cliente = venta.Cliente;
            existingVenta.Fecha = venta.Fecha;
            existingVenta.TotalMN = venta.TotalMN;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public IActionResult DeleteVenta(string codigo)
        {
            var venta = _context.Ventas.FirstOrDefault(v => v.CodVta == codigo);
            if (venta == null) return NotFound();

            _context.Ventas.Remove(venta);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
