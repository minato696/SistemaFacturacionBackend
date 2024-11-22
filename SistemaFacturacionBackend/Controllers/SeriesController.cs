using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionBackend.Data;
using SistemaFacturacionBackend.Data.Models;
using SistemaFacturacionBackend.Models;

namespace SistemaFacturacionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SeriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSeries()
        {
            var series = _context.Series.ToList();
            return Ok(series);
        }

        [HttpGet("{codigo}")]
        public IActionResult GetSerieByCodigo(string codigo)
        {
            var serie = _context.Series.FirstOrDefault(s => s.CodSerie == codigo);
            if (serie == null) return NotFound();
            return Ok(serie);
        }

        [HttpPost]
        public IActionResult CreateSerie([FromBody] Serie serie)
        {
            _context.Series.Add(serie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSerieByCodigo), new { codigo = serie.CodSerie }, serie);
        }

        [HttpPut("{codigo}")]
        public IActionResult UpdateSerie(string codigo, [FromBody] Serie serie)
        {
            if (codigo != serie.CodSerie) return BadRequest();

            var existingSerie = _context.Series.FirstOrDefault(s => s.CodSerie == codigo);
            if (existingSerie == null) return NotFound();

            existingSerie.Ciudad = serie.Ciudad;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public IActionResult DeleteSerie(string codigo)
        {
            var serie = _context.Series.FirstOrDefault(s => s.CodSerie == codigo);
            if (serie == null) return NotFound();

            _context.Series.Remove(serie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
