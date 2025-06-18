using System;
using System.Collections.Generic;
using System.Linq;

namespace demo.Models;

public partial class Partner
{
    public int PartnerId { get; set; }

    public string? Name { get; set; }

    public string? DirName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Inn { get; set; }

    public int? Rate { get; set; }

    public int PartnerTypeId { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public virtual PartnerType PartnerType { get; set; } = null!;

    public int Discount => SetDis();
    
    public int? Sum => PartnerProducts.Select(x => x.Count).Sum();

    int SetDis()
    {
        var sum = PartnerProducts.Select(x => x.Count).Sum();
        if (sum < 10000) return 0;
        if (sum >= 10000 && sum < 50000) return 5;
        if (sum >= 50000 && sum < 300000) return 10;
        return 15;
    }
}
