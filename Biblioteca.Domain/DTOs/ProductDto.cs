using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.DTOs
{
    public class ProductDto
    {
        public int Idproducts { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; } // Solo el id de la categoría, no la entidad completa
    }
}
