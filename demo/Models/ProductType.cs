using System;
using System.Collections.Generic;

namespace demo.Models;

public partial class ProductType
{
    public int ProductTypeId { get; set; }

    public string? Name { get; set; }

    public decimal? Procent { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
