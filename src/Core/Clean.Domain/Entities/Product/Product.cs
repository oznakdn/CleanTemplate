using Clean.Domain.Contracts.Entities;
using Clean.Domain.ValueObjects;

namespace Clean.Domain.Entities.Product;

public class Product : Entity<Guid>
{
    public Product(string productName, decimal price, Inventory inventory, Currency currency) : base(Guid.NewGuid())
    {
        ProductName = productName;
        Price = price;
        Inventory = inventory;
        Currency = currency;
    }

    private Product() : base(Guid.NewGuid())
    { }

    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public Inventory Inventory { get; set; }
    public Currency Currency { get; set; }


}
