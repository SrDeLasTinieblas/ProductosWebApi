using System;
using System.Collections.Generic;

namespace Biblioteca.Domain.Entities;

public partial class Product
{
    public int Idproducts { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
