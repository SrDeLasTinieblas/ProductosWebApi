using Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Interfaces
{
    public interface IProductService
    {
        //Task<List<Product>> GetAllProductosAsync();
        Task<IEnumerable<Product>> GetAllProductosAsync();
        Task<Product> GetProductoByIdAsync(int id);
        Task AddProductoAsync(Product producto);
        Task UpdateProductoAsync(Product producto);
        Task DeleteProductoAsync(int id);
    }
}
