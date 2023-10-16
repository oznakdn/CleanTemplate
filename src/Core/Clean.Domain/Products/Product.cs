using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Products;

public class Product : AggregateRoot<Product,Guid>
{
    public string DisplayName { get; private set; }
    public Money Price { get; private set; }
    public Inventory Inventory { get; private set; }
    public Category Category { get; private set; }


    public Product(string displayName, Money price, Category category) : base(Guid.NewGuid())
    {
        DisplayName = displayName;
        Price = price;
        Category = category;
    }

    private Product() : base(Guid.Empty) { }



    public void AddInventory(int quantity)
    {
        Inventory = new(this.Id, quantity);
    }

}
