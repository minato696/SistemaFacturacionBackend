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
    public class VentasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VentasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Venta>> GetVentas()
        {
            return _context.Ventas.ToList();
        }

        [HttpGet("{codVta}")]
        public ActionResult<Venta> GetVenta(string codVta)
        {
            var venta = _context.Ventas.FirstOrDefault(v => v.Cod_Vta == codVta);
            if (venta == null)
            {
                return NotFound();
            }
            return venta;
        }

        [HttpPost]
        public ActionResult<Venta> PostVenta(Venta venta)
        {
            _context.Ventas.Add(venta);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVenta), new { codVta = venta.Cod_Vta }, venta);
        }

        [HttpPut("{codVta}")]
        public IActionResult PutVenta(string codVta, Venta venta)
        {
            if (codVta != venta.Cod_Vta)
            {
                return BadRequest();
            }

            var ventaExistente = _context.Ventas.FirstOrDefault(v => v.Cod_Vta == codVta);
            if (ventaExistente == null)
            {
                return NotFound();
            }

            ventaExistente.Ruc = venta.Ruc;
            ventaExistente.Cliente = venta.Cliente;
            ventaExistente.Fecha = venta.Fecha;
            ventaExistente.BrutoMN = venta.BrutoMN;
            ventaExistente.BaseMN = venta.BaseMN;
            ventaExistente.IgvMN = venta.IgvMN;
            ventaExistente.TotalMN = venta.TotalMN;
            ventaExistente.BrutoME = venta.BrutoME;
            ventaExistente.BaseME = venta.BaseME;
            ventaExistente.IgvME = venta.IgvME;
            ventaExistente.TotalME = venta.TotalME;
            ventaExistente.Dscto = venta.Dscto;
            ventaExistente.Orden = venta.Orden;
            ventaExistente.Orden_Compra = venta.Orden_Compra;
            ventaExistente.N_Certificacion = venta.N_Certificacion;
            ventaExistente.Agencia = venta.Agencia;
            ventaExistente.Moneda = venta.Moneda;
            ventaExistente.Serie = venta.Serie;
            ventaExistente.CondPago = venta.CondPago;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{codVta}")]
        public IActionResult DeleteVenta(string codVta)
        {
            var venta = _context.Ventas.FirstOrDefault(v => v.Cod_Vta == codVta);
            if (venta == null)
            {
                return NotFound();
            }

            _context.Ventas.Remove(venta);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
