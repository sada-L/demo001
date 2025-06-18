using System;
using System.Collections.Generic;

namespace demo.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Articul { get; set; }

    public decimal? Cost { get; set; }

    public int ProductTypeId { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public virtual ProductType ProductType { get; set; } = null!;
}
