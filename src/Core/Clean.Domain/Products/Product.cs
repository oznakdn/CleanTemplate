using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Shared;

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


    public Result AddMoney(Currency currency, decimal amount)
    {
        if (currency < 0)
        {
            return new Error($"{nameof(Price.Currency)} cannot be less than 0!");
        }

        if (amount < 0)
            return new Error($"{nameof(Price.Amount)} cannot be less than 0!");

        Price = new Money(currency, amount);
        return new Result("", false, true);
    }

    public Result AddCategory(string displayName)
    {
        if (displayName.Length < 3 || displayName.Length > 20)
        {
            return new Error($"{nameof(Category.DisplayName)} can be between 3 and 20 characters!");
        }

        Category = new Category(displayName);
        return new Result("", false, true);

    }

    public Result AddInventory(Guid productId, int quantity)
    {
        if (quantity < 0)
            return new Error("Quantity cannot be less than 0!");

        Inventory = new(productId, quantity);
        return new Result("",false,true);
    }

}
