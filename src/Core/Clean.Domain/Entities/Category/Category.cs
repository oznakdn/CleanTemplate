using Clean.Domain.Contracts.Entities;

namespace Clean.Domain.Entities.Category;

public class Category : AgreegateRoot<Category,Guid>
{
    private static readonly List<Category> _categories = new();
    public Category(string categoryName, string description) : base(Guid.NewGuid())
    {
        CategoryName = categoryName;
        Description = description;
        Products = new HashSet<Product.Product>();
    }

    private Category() : base(Guid.NewGuid())
    { }

    public string CategoryName { get; private set; }
    public string Description { get; private set; }
    public ICollection<Product.Product> Products { get; private set; }

    public static Category Create(string categoryName, string description)
    {
        if (!string.IsNullOrEmpty(categoryName) && !string.IsNullOrEmpty(description))
        {
            var category = new Category(categoryName, description);
            _categories.Add(category);
            return category;
        }

        throw new ArgumentException("");
    }

    public Category AddProduct(string productName)
    {
        if (!string.IsNullOrEmpty(productName))
        {
            Products.Add(new Product.Product(this.Id.ToString(), productName));
            return this;

        }
        throw new ArgumentException("");
    }

}

