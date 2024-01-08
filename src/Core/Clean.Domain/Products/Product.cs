using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Inventories;
using Clean.Domain.Products.Enums;
using Clean.Domain.Products.ValueObjects;
using Clean.Shared;

namespace Clean.Domain.Products;

public class Product : AggregateRoot<Product, Guid>
{
    private List<Image> _images { get; set; } = new();
    public string DisplayName { get; private set; }
    public Money Price { get; private set; }
    public Inventory Inventory { get; private set; }
    public Category Category { get; private set; }
    public IReadOnlyCollection<Image> Images => _images;


    public Product(string displayName) : base(Guid.NewGuid())
    {
        DisplayName = displayName;
    }

    private Product() : base(Guid.Empty) { }


    public void AddImage(Image image)
    {
        _images.Add(image);
    }

    public void AddImages(List<Image> images)
    {
        _images.AddRange(images);
    }


    public IResult AddMoney(Currency currency, decimal amount)
    {
        var errors = new List<string>();

        if (currency < 0)
        {
            errors.Add($"{nameof(Price.Currency)} cannot be less than 0!");
        }

        if (amount < 0)
        {
            errors.Add($"{nameof(Price.Amount)} cannot be less than 0!");

        }

        if (errors.Count > 0)
        {
            return Result.Fail(errors: errors);
        }

        Price = new Money(currency, amount);
        return Result.Success();
    }

    public IResult AddCategory(string displayName)
    {
        if (displayName.Length < 3 || displayName.Length > 20)
        {
            return Result.Fail(error: $"{nameof(Category.DisplayName)} can be between 3 and 20 characters!");
        }

        Category = new Category(displayName);
        return Result.Success();

    }

    public IResult AddInventory(Guid productId, int quantity)
    {
        if (quantity < 0)
            return Result.Fail("Quantity cannot be less than 0!");

        Inventory = new(productId, quantity);
        return Result.Success();
    }

}
