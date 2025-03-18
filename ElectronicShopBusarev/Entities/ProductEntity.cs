using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShopBusarev.Entities;
public class ProductEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }

    public ProductEntity()
    {

    }

    public ProductEntity(
        string title,
        string description,
        int amount)
    {
        Title = title;
        Description = description;
        Amount = amount;
    }

}
