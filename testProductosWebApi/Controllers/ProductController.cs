using Biblioteca.Application.Interfaces;
using Biblioteca.Application.Services;
using Biblioteca.Domain.DTOs;
using Biblioteca.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace testProductosWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productoService;

        // Inyección de dependencias
        public ProductController(IProductService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/productos
        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await _productoService.GetAllProductosAsync();
            return Ok(productos);  // Devuelve los productos en formato JSON
        }

        // GET: api/productos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null)
                return NotFound();  // Devuelve 404 si no se encuentra el producto
            return Ok(producto);  // Devuelve el producto en formato JSON
        }

        // POST: api/productos
        [HttpPost]
        public async Task<IActionResult> PostProducto([FromBody] ProductDto productoDTO)
        {
            if (productoDTO == null)
                return BadRequest("Producto no puede ser nulo");

            await _productoService.AddProductoAsync(productoDTO);
            return CreatedAtAction(nameof(GetProducto), new { id = productoDTO.CategoryId }, productoDTO);
        }

        // PUT: api/productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, [FromBody] ProductDto productoDTO)
        {
            if (id != productoDTO.Idproducts)
                return BadRequest("El ID del producto no coincide");

            await _productoService.UpdateProductoAsync(productoDTO);
            return NoContent();  // Devuelve 204 si la actualización fue exitosa
        }

        // DELETE: api/productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            await _productoService.DeleteProductoAsync(id);
            return NoContent();  // Devuelve 204 si la eliminación fue exitosa
        }
    }
}
