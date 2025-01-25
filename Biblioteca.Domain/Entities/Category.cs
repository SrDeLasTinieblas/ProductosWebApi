using System;
using System.Collections.Generic;

namespace Biblioteca.Domain.Entities;

public partial class Category
{
    public int Idcategories { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
