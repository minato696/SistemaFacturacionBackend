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
    public class DetVentaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DetVentaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DetVenta>> GetDetVentas()
        {
            return _context.DetVentas.ToList();
        }

        [HttpGet("{codVta}")]
        public ActionResult<DetVenta> GetDetVenta(string codVta)
        {
            var detVenta = _context.DetVentas.FirstOrDefault(dv => dv.COD_VTA == codVta);
            if (detVenta == null)
            {
                return NotFound();
            }
            return detVenta;
        }

        [HttpPost]
        public ActionResult<DetVenta> PostDetVenta(DetVenta detVenta)
        {
            _context.DetVentas.Add(detVenta);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetDetVenta), new { codVta = detVenta.COD_VTA }, detVenta);
        }

        [HttpPut("{codVta}")]
        public IActionResult PutDetVenta(string codVta, DetVenta detVenta)
        {
            if (codVta != detVenta.COD_VTA)
            {
                return BadRequest();
            }

            var detVentaExistente = _context.DetVentas.FirstOrDefault(dv => dv.COD_VTA == codVta);
            if (detVentaExistente == null)
            {
                return NotFound();
            }

            // Actualizar todos los campos
            detVentaExistente.ORDEN = detVenta.ORDEN;
            detVentaExistente.DESCRIPCION = detVenta.DESCRIPCION;
            detVentaExistente.CIUDAD = detVenta.CIUDAD;
            detVentaExistente.CANT = detVenta.CANT;
            detVentaExistente.SEG = detVenta.SEG;
            detVentaExistente.PUNIT = detVenta.PUNIT;
            detVentaExistente.IMPORTE = detVenta.IMPORTE;
            detVentaExistente.PORCENTAJE = detVenta.PORCENTAJE;
            detVentaExistente.DSCTO = detVenta.DSCTO;
            detVentaExistente.SECUENCIA = detVenta.SECUENCIA;
            detVentaExistente.C_ORDEN = detVenta.C_ORDEN;
            detVentaExistente.RADIO = detVenta.RADIO;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{codVta}")]
        public IActionResult DeleteDetVenta(string codVta)
        {
            var detVenta = _context.DetVentas.FirstOrDefault(dv => dv.COD_VTA == codVta);
            if (detVenta == null)
            {
                return NotFound();
            }

            _context.DetVentas.Remove(detVenta);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
