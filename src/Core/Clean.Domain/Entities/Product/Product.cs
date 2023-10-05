using Clean.Domain.Contracts.Entities;
using Clean.Domain.ValueObjects;

namespace Clean.Domain.Entities.Product;

public class Product : Entity<Guid>
{

    private readonly List<Product> _products = new();

    public Product(string categoryId, string productName) : base(Guid.NewGuid())
    {
        ProductName = productName;
        CategoryId = Guid.Parse(categoryId);
    }


    public Product(string categoryId, string productName, Inventory inventory, Currency currency) : base(Guid.NewGuid())
    {
        ProductName = productName;
        Inventory = inventory;
        Currency = currency;
        CategoryId = Guid.Parse(categoryId);
    }

    private Product() : base(Guid.NewGuid())
    { }

    public string ProductName { get; private set; }
    public Inventory? Inventory { get; private set; }
    public Currency? Currency { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category.Category Category { get; private set; }


    public void ChangeProduct(string? categoryId, string? productName, Inventory? inventory, Currency? currency)
    {
        if (!string.IsNullOrWhiteSpace(categoryId) || 
            !string.IsNullOrWhiteSpace(productName) || 
            inventory != null || 
            currency != null)
        {
            CategoryId = Guid.Parse(categoryId);
            ProductName = productName;
            Inventory = inventory;
            Currency = currency;
        }

    }

    public void ChangeInventory(int amount)
    {
        if(amount >= 0)
        {
            Inventory.Amount = amount;
        }
    }

    public void ChangeCurrency(CurrencyType currencyType, decimal price)
    {
        if (price >= 0)
        {
            Currency.CurrencyType = currencyType;
            Currency.Price = price;
        }
    }

    public void DeleteProduct()
    {
        IsDeleted = true;
    }

    public void AddInventory(int amount)
    {
        if (amount > 0)
        {
            Inventory = new Inventory(amount);
        }
    }

    public void AddCurrency(CurrencyType currencyType, decimal price)
    {
        if (price > 0)
        {
            Currency = new Currency(currencyType, price);
        }
    }


}
