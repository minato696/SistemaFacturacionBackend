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
    public class SeriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SeriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Serie>> GetSeries()
        {
            return _context.Series.ToList();
        }

        [HttpGet("{codSerie}")]
        public ActionResult<Serie> GetSerie(string codSerie)
        {
            var serie = _context.Series.FirstOrDefault(s => s.COD_SERIE == codSerie);
            if (serie == null)
            {
                return NotFound();
            }
            return serie;
        }

        [HttpPost]
        public ActionResult<Serie> PostSerie(Serie serie)
        {
            _context.Series.Add(serie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSerie), new { codSerie = serie.COD_SERIE }, serie);
        }

        [HttpPut("{codSerie}")]
        public IActionResult PutSerie(string codSerie, Serie serie)
        {
            if (codSerie != serie.COD_SERIE)
            {
                return BadRequest();
            }

            var serieExistente = _context.Series.FirstOrDefault(s => s.COD_SERIE == codSerie);
            if (serieExistente == null)
            {
                return NotFound();
            }

            serieExistente.Ciudad = serie.Ciudad;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{codSerie}")]
        public IActionResult DeleteSerie(string codSerie)
        {
            var serie = _context.Series.FirstOrDefault(s => s.COD_SERIE == codSerie);
            if (serie == null)
            {
                return NotFound();
            }

            _context.Series.Remove(serie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
