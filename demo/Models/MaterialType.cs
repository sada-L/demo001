using System;
using System.Collections.Generic;

namespace demo.Models;

public partial class MaterialType
{
    public int MaterialTypeId { get; set; }

    public decimal? Procent { get; set; }

    public string? Name { get; set; }
}
