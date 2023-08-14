using Clean.Domain.Entities.Abstracts;

namespace Clean.Domain.Entities;

public class Product : Entity<int>
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

}
