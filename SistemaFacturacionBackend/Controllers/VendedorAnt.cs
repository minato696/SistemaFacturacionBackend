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
    public class VendedorAntController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendedorAntController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VendedorAnt>> GetVendedoresAnt()
        {
            return _context.VendedoresAnt.ToList();
        }

        [HttpGet("{codigo}")]
        public ActionResult<VendedorAnt> GetVendedorAnt(int codigo)
        {
            var vendedorAnt = _context.VendedoresAnt.FirstOrDefault(v => v.Codigo == codigo);
            if (vendedorAnt == null)
            {
                return NotFound();
            }
            return vendedorAnt;
        }

        [HttpPost]
        public ActionResult<VendedorAnt> PostVendedorAnt(VendedorAnt vendedorAnt)
        {
            _context.VendedoresAnt.Add(vendedorAnt);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVendedorAnt), new { codigo = vendedorAnt.Codigo }, vendedorAnt);
        }

        [HttpPut("{codigo}")]
        public IActionResult PutVendedorAnt(int codigo, VendedorAnt vendedorAnt)
        {
            if (codigo != vendedorAnt.Codigo)
            {
                return BadRequest();
            }

            var vendedorAntExistente = _context.VendedoresAnt.FirstOrDefault(v => v.Codigo == codigo);
            if (vendedorAntExistente == null)
            {
                return NotFound();
            }

            vendedorAntExistente.NombreVendedorAnt = vendedorAnt.NombreVendedorAnt; // Ajustado

            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{codigo}")]
        public IActionResult DeleteVendedorAnt(int codigo)
        {
            var vendedorAnt = _context.VendedoresAnt.FirstOrDefault(v => v.Codigo == codigo);
            if (vendedorAnt == null)
            {
                return NotFound();
            }

            _context.VendedoresAnt.Remove(vendedorAnt);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
