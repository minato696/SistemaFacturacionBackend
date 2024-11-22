using SistemaFacturacionBackend.Data;
using SistemaFacturacionBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;



namespace SistemaFacturacionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteMotivoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteMotivoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetClienteMotivos()
        {
            var clienteMotivos = _context.ClienteMotivos.ToList();
            return Ok(clienteMotivos);
        }

        [HttpGet("{codigo}")]
        public IActionResult GetClienteMotivoByCodigo(int codigo)
        {
            var clienteMotivo = _context.ClienteMotivos.Find(codigo);
            if (clienteMotivo == null) return NotFound();
            return Ok(clienteMotivo);
        }

        [HttpPost]
        public IActionResult CreateClienteMotivo([FromBody] ClienteMotivo clienteMotivo)
        {
            _context.ClienteMotivos.Add(clienteMotivo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetClienteMotivoByCodigo), new { codigo = clienteMotivo.Codigo }, clienteMotivo);
        }

        [HttpPut("{codigo}")]
        public IActionResult UpdateClienteMotivo(int codigo, [FromBody] ClienteMotivo clienteMotivo)
        {
            if (codigo != clienteMotivo.Codigo) return BadRequest();

            var existingClienteMotivo = _context.ClienteMotivos.Find(codigo);
            if (existingClienteMotivo == null) return NotFound();

            existingClienteMotivo.Cliente = clienteMotivo.Cliente;
            existingClienteMotivo.Vendedor = clienteMotivo.Vendedor;
            existingClienteMotivo.Tipo = clienteMotivo.Tipo;
            existingClienteMotivo.Agencia = clienteMotivo.Agencia;
            existingClienteMotivo.Ruc = clienteMotivo.Ruc;
            existingClienteMotivo.Empresa = clienteMotivo.Empresa;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public IActionResult DeleteClienteMotivo(int codigo)
        {
            var clienteMotivo = _context.ClienteMotivos.Find(codigo);
            if (clienteMotivo == null) return NotFound();

            _context.ClienteMotivos.Remove(clienteMotivo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
