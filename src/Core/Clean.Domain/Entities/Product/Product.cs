using Clean.Domain.Contracts.Entities;
using Clean.Domain.ValueObjects;

namespace Clean.Domain.Entities.Product;

public class Product : Entity<Guid>, IAgreegateRoot<Product, Guid>
{

    private readonly List<Product> _products = new();
    public Product(string productName) : base(Guid.NewGuid())
    {
        ProductName = productName;
    }

    public Product(string productName, Inventory inventory, Currency currency) : base(Guid.NewGuid())
    {
        ProductName = productName;
        Inventory = inventory;
        Currency = currency;
    }

    private Product() : base(Guid.NewGuid())
    { }

    public string ProductName { get; private set; }
    public Inventory? Inventory { get; private set; }
    public Currency? Currency { get; private set; }

    public Product Create(string productName)
    {
        if (!string.IsNullOrEmpty(productName))
        {
            var product = new Product
            {
                ProductName = productName,
            };

            _products.Add(product);
            return product;
        }

        throw new ArgumentException("");
    }

    public Product Update(string productId, string productName, Inventory? inventory, Currency? currency)
    {
        if (!string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(productId))
        {
            var currentProduct = _products.Where(p => p.Id == Guid.Parse(productId)).SingleOrDefault();
            if (currentProduct != null)
            {
                currentProduct.ProductName = productName;
                currentProduct.Inventory = inventory;
                currentProduct.Currency = currency;
                return currentProduct;
            }
        }
        throw new ArgumentException("");
    }

    public Product Delete(string productId)
    {
        if (!string.IsNullOrEmpty(productId))
        {
            var currentProduct = _products.Where(p => p.Id == Guid.Parse(productId)).SingleOrDefault();
            if (currentProduct != null)
            {
                currentProduct.IsDeleted = true;
                return currentProduct;
            }
        }
        throw new ArgumentException("");
    }

    public Product AddInventory(int amount)
    {
        if (amount > 0)
        {
            Inventory = new Inventory(amount);
            return this;
        }

        throw new ArgumentException("");
    }

    public Product AddCurrency(CurrencyType currencyType, decimal price)
    {
        if (price > 0)
        {
            Currency = new Currency(currencyType, price);
            return this;
        }

        throw new ArgumentException("");
    }


}
