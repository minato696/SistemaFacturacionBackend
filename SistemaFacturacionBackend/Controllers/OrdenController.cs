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
    public class OrdenController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdenController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Orden>> GetOrdenes()
        {
            return _context.Ordenes.ToList();
        }

        [HttpGet("{reg}")]
        public ActionResult<Orden> GetOrden(int reg)
        {
            var orden = _context.Ordenes.FirstOrDefault(o => o.Reg == reg);
            if (orden == null)
            {
                return NotFound();
            }
            return orden;
        }

        [HttpPost]
        public ActionResult<Orden> PostOrden(Orden orden)
        {
            _context.Ordenes.Add(orden);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetOrden), new { reg = orden.Reg }, orden);
        }

        [HttpPut("{reg}")]
        public IActionResult PutOrden(int reg, Orden orden)
        {
            if (reg != orden.Reg)
            {
                return BadRequest();
            }

            var ordenExistente = _context.Ordenes.FirstOrDefault(o => o.Reg == reg);
            if (ordenExistente == null)
            {
                return NotFound();
            }

            ordenExistente.Neto_S = orden.Neto_S;
            ordenExistente.Neto_Us = orden.Neto_Us;
            // Actualiza otros campos necesarios

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{reg}")]
        public IActionResult DeleteOrden(int reg)
        {
            var orden = _context.Ordenes.FirstOrDefault(o => o.Reg == reg);
            if (orden == null)
            {
                return NotFound();
            }

            _context.Ordenes.Remove(orden);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
