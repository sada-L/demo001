using System;
using System.Collections.Generic;

namespace demo.Models;

public partial class PartnerType
{
    public int PartnerTypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
