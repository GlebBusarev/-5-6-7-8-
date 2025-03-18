using System;
using System.Collections.Generic;

namespace EfCoreDatabaseFirst.Entities;

public partial class Productsupplier
{
    public int ProductSupplierId { get; set; }

    public int? ProductId { get; set; }

    public int? SupplierId { get; set; }

    public DateTime SupplyDate { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
