﻿using Biblioteca.Domain.DTOs;
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
        Task<IEnumerable<Product>> GetAllProductosAsync();
        Task<Product> GetProductoByIdAsync(int id);
        Task AddProductoAsync(ProductDto productoDTO);
        Task UpdateProductoAsync(ProductDto productoDTO);
        Task DeleteProductoAsync(int id);
    }
}
