using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionBackend.Data.Models;
using SistemaFacturacionBackend.Data;
using SistemaFacturacionBackend.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaFacturacionBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CiudadController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CiudadController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> GetCiudades()
        {
            return _context.Ciudades.ToList();
        }

        [HttpGet("{codigo}")]
        public ActionResult<Ciudad> GetCiudad(string codigo)
        {
            var ciudad = _context.Ciudades.FirstOrDefault(c => c.Codigo == codigo);
            if (ciudad == null)
            {
                return NotFound();
            }
            return ciudad;
        }

        [HttpPost]
        public ActionResult<Ciudad> PostCiudad(Ciudad ciudad)
        {
            _context.Ciudades.Add(ciudad);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCiudad), new { codigo = ciudad.Codigo }, ciudad);
        }

        [HttpPut("{codigo}")]
        public IActionResult PutCiudad(string codigo, Ciudad ciudad)
        {
            if (codigo != ciudad.Codigo)
            {
                return BadRequest();
            }

            var ciudadExistente = _context.Ciudades.FirstOrDefault(c => c.Codigo == codigo);
            if (ciudadExistente == null)
            {
                return NotFound();
            }

            ciudadExistente.NombreCiudad = ciudad.NombreCiudad; // Ajustado
            ciudadExistente.F3 = ciudad.F3;

            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{codigo}")]
        public IActionResult DeleteCiudad(string codigo)
        {
            var ciudad = _context.Ciudades.FirstOrDefault(c => c.Codigo == codigo);
            if (ciudad == null)
            {
                return NotFound();
            }

            _context.Ciudades.Remove(ciudad);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
