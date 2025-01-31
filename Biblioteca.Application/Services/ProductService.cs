﻿using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.DTOs;
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
            return await _productoRepository.GetAllProductosAsync();
        }

        public async Task<Product> GetProductoByIdAsync(int id)
        {
            return await _productoRepository.GetProductoByIdAsync(id);
        }

        public async Task AddProductoAsync(ProductDto productoDTO)
        {
            await _productoRepository.AddProductoAsync(productoDTO);
        }

        public async Task UpdateProductoAsync(ProductDto productoDTO)
        {
            await _productoRepository.UpdateProductoAsync(productoDTO);
        }

        public async Task DeleteProductoAsync(int id)
        {
            await _productoRepository.DeleteProductoAsync(id);
        }

    }
}
