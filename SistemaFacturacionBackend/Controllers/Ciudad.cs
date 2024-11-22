using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionBackend.Data;
using SistemaFacturacionBackend.Data.Models;
using SistemaFacturacionBackend.Models;

namespace SistemaFacturacionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CiudadController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCiudades()
        {
            var ciudades = _context.Ciudades.ToList();
            return Ok(ciudades);
        }

        [HttpGet("{id}")]
        public IActionResult GetCiudadById(int id)
        {
            var ciudad = _context.Ciudades.Find(id);
            if (ciudad == null) return NotFound();
            return Ok(ciudad);
        }

        [HttpPost]
        public IActionResult CreateCiudad([FromBody] Ciudad ciudad)
        {
            _context.Ciudades.Add(ciudad);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCiudadById), new { id = ciudad.Id }, ciudad);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCiudad(int id, [FromBody] Ciudad ciudad)
        {
            if (id != ciudad.Id) return BadRequest();

            var existingCiudad = _context.Ciudades.Find(id);
            if (existingCiudad == null) return NotFound();

            existingCiudad.Nombre = ciudad.Nombre;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCiudad(int id)
        {
            var ciudad = _context.Ciudades.Find(id);
            if (ciudad == null) return NotFound();

            _context.Ciudades.Remove(ciudad);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
