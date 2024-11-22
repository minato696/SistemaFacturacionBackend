using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionBackend.Data;
using SistemaFacturacionBackend.Data.Models;
using SistemaFacturacionBackend.Models;

namespace SistemaFacturacionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarifasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarifasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTarifas()
        {
            var tarifas = _context.Tarifas.ToList();
            return Ok(tarifas);
        }

        [HttpGet("{codigo}")]
        public IActionResult GetTarifaByCodigo(string codigo)
        {
            var tarifa = _context.Tarifas.FirstOrDefault(t => t.Codigo == codigo);
            if (tarifa == null) return NotFound();
            return Ok(tarifa);
        }

        [HttpPost]
        public IActionResult CreateTarifa([FromBody] Tarifa tarifa)
        {
            _context.Tarifas.Add(tarifa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTarifaByCodigo), new { codigo = tarifa.Codigo }, tarifa);
        }

        [HttpPut("{codigo}")]
        public IActionResult UpdateTarifa(string codigo, [FromBody] Tarifa tarifa)
        {
            if (codigo != tarifa.Codigo) return BadRequest();

            var existingTarifa = _context.Tarifas.FirstOrDefault(t => t.Codigo == codigo);
            if (existingTarifa == null) return NotFound();

            existingTarifa.Radio = tarifa.Radio;
            existingTarifa.Ciudad = tarifa.Ciudad;
            existingTarifa.TarifaValor = tarifa.TarifaValor;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public IActionResult DeleteTarifa(string codigo)
        {
            var tarifa = _context.Tarifas.FirstOrDefault(t => t.Codigo == codigo);
            if (tarifa == null) return NotFound();

            _context.Tarifas.Remove(tarifa);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
