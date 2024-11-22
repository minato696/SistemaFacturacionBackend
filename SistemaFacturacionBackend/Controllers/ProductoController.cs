using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionBackend.Data;
using SistemaFacturacionBackend.Data.Models;
using SistemaFacturacionBackend.Models;

namespace SistemaFacturacionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            var productos = _context.Productos.ToList();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductoById(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpPost]
        public IActionResult CreateProducto([FromBody] Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProductoById), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProducto(int id, [FromBody] Producto producto)
        {
            if (id != producto.Id) return BadRequest();

            var existingProducto = _context.Productos.Find(id);
            if (existingProducto == null) return NotFound();

            existingProducto.Nombre = producto.Nombre;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProducto(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null) return NotFound();

            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
