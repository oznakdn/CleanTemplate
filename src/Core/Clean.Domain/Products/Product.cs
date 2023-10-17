using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Products;

public class Product : AggregateRoot<Product, Guid>
{
    public string DisplayName { get; private set; }
    public Money Price { get; private set; }
    public Inventory Inventory { get; private set; }
    public Category Category { get; private set; }


    public Product(string displayName) : base(Guid.NewGuid())
    {
        DisplayName = displayName;
    }

    private Product() : base(Guid.Empty) { }


    public void AddMoney(MoneyType moneyType, decimal amount)
    {
        Price = new Money(moneyType, amount);
    }

    public void AddCategory(string displayName)
    {
        Category = new Category(displayName);
    }

    public void AddInventory(Inventory inventory)
    {
        Inventory = new(inventory.ProductId, inventory.Quantity);
    }

}
