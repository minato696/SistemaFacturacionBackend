using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionBackend.Data;
using SistemaFacturacionBackend.Data.Models;
using SistemaFacturacionBackend.Models;

namespace SistemaFacturacionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdenController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetOrdenes()
        {
            var ordenes = _context.Ordenes.ToList();
            return Ok(ordenes);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrdenById(int id)
        {
            var orden = _context.Ordenes.Find(id);
            if (orden == null) return NotFound();
            return Ok(orden);
        }

        [HttpPost]
        public IActionResult CreateOrden([FromBody] Orden orden)
        {
            _context.Ordenes.Add(orden);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetOrdenById), new { id = orden.Reg }, orden);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrden(int id, [FromBody] Orden orden)
        {
            if (id != orden.Reg) return BadRequest();

            var existingOrden = _context.Ordenes.Find(id);
            if (existingOrden == null) return NotFound();

            existingOrden.Fecha = orden.Fecha;
            existingOrden.Cliente = orden.Cliente;
            existingOrden.Producto = orden.Producto;
            existingOrden.Motivo = orden.Motivo;
            existingOrden.NetoS = orden.NetoS;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrden(int id)
        {
            var orden = _context.Ordenes.Find(id);
            if (orden == null) return NotFound();

            _context.Ordenes.Remove(orden);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
