using System;
using System.Collections.Generic;

namespace demo.Models;

public partial class PartnerProduct
{
    public int PartnerProduct1 { get; set; }

    public int PartnerId { get; set; }

    public int? ProductId { get; set; }

    public int? Count { get; set; }

    public DateTime? Date { get; set; }

    public virtual Partner Partner { get; set; } = null!;

    public virtual Product? Product { get; set; }
}
