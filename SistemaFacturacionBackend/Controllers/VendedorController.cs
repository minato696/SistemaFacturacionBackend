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
    public class VendedorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendedorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vendedor>> GetVendedores()
        {
            return _context.Vendedores.ToList();
        }

        [HttpGet("{codigo}")]
        public ActionResult<Vendedor> GetVendedor(int codigo)
        {
            var vendedor = _context.Vendedores.FirstOrDefault(v => v.Codigo == codigo);
            if (vendedor == null)
            {
                return NotFound();
            }
            return vendedor;
        }

        [HttpPost]
        public ActionResult<Vendedor> PostVendedor(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVendedor), new { codigo = vendedor.Codigo }, vendedor);
        }

        [HttpPut("{codigo}")]
        public IActionResult PutVendedor(int codigo, Vendedor vendedor)
        {
            if (codigo != vendedor.Codigo)
            {
                return BadRequest();
            }

            var vendedorExistente = _context.Vendedores.FirstOrDefault(v => v.Codigo == codigo);
            if (vendedorExistente == null)
            {
                return NotFound();
            }

            vendedorExistente.NombreVendedor = vendedor.NombreVendedor;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public IActionResult DeleteVendedor(int codigo)
        {
            var vendedor = _context.Vendedores.FirstOrDefault(v => v.Codigo == codigo);
            if (vendedor == null)
            {
                return NotFound();
            }

            _context.Vendedores.Remove(vendedor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
