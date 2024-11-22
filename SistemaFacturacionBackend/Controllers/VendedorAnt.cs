using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionBackend.Data;
using SistemaFacturacionBackend.Data.Models;

namespace SistemaFacturacionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorAntController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendedorAntController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetVendedoresAnt()
        {
            var vendedoresAnt = _context.VendedoresAnt.ToList();
            return Ok(vendedoresAnt);
        }

        [HttpGet("{id}")]
        public IActionResult GetVendedorAntById(int id)
        {
            var vendedorAnt = _context.VendedoresAnt.Find(id);
            if (vendedorAnt == null) return NotFound();
            return Ok(vendedorAnt);
        }

        [HttpPost]
        public IActionResult CreateVendedorAnt([FromBody] VendedorAnt vendedorAnt)
        {
            _context.VendedoresAnt.Add(vendedorAnt);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVendedorAntById), new { id = vendedorAnt.Id }, vendedorAnt);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVendedorAnt(int id, [FromBody] VendedorAnt vendedorAnt)
        {
            if (id != vendedorAnt.Id) return BadRequest();

            var existingVendedorAnt = _context.VendedoresAnt.Find(id);
            if (existingVendedorAnt == null) return NotFound();

            existingVendedorAnt.Nombre = vendedorAnt.Nombre;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVendedorAnt(int id)
        {
            var vendedorAnt = _context.VendedoresAnt.Find(id);
            if (vendedorAnt == null) return NotFound();

            _context.VendedoresAnt.Remove(vendedorAnt);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
