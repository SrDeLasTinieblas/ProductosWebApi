using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productoRepository;

        // Inyección de dependencias
        public ProductService(IProductRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductosAsync()
        {
            //return (List<Product>)await _productoRepository.GetAllProductosAsync();
            return await _productoRepository.GetAllProductosAsync();
        }

        public async Task<Product> GetProductoByIdAsync(int id)
        {
            return await _productoRepository.GetProductoByIdAsync(id);
        }

        public async Task AddProductoAsync(Product producto)
        {
            await _productoRepository.AddProductoAsync(producto);
        }

        public async Task UpdateProductoAsync(Product producto)
        {
            await _productoRepository.UpdateProductoAsync(producto);
        }

        public async Task DeleteProductoAsync(int id)
        {
            await _productoRepository.DeleteProductoAsync(id);
        }

    }
}
