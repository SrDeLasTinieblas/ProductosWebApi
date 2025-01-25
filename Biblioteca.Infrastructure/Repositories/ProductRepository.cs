using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.DTOs;
using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Data;
using Biblioteca.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProductosAsync()
        {
            return await _appDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductoByIdAsync(int id)
        {
            return await _appDbContext.Products.FirstOrDefaultAsync(p => p.Idproducts == id);
        }

        public async Task AddProductoAsync(ProductDto productoDTO)
        {
            var product = new Product
            {
                Name = productoDTO.Name,
                Price = productoDTO.Price,
                CategoryId = productoDTO.CategoryId
            };

            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<string> UpdateProductoAsync(ProductDto productoDTO)
        {
            // Find existing product
            var existingProduct = await _appDbContext.Products
                .FirstOrDefaultAsync(p => p.Idproducts == productoDTO.Idproducts);

            if (existingProduct == null)
                throw new NotFoundException("Producto no encontrado");

            // Update properties
            existingProduct.Name = productoDTO.Name;
            existingProduct.Price = productoDTO.Price;
            existingProduct.CategoryId = productoDTO.CategoryId;

            _appDbContext.Products.Update(existingProduct);
            await _appDbContext.SaveChangesAsync();
            return "Producto actualizado exitosamente";
        }

        public async Task DeleteProductoAsync(int id)
        {
            var producto = await _appDbContext.Products.FindAsync(id);
            if (producto != null)
            {
                _appDbContext.Products.Remove(producto);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
