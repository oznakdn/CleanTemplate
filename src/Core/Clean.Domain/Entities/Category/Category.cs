using Clean.Domain.Contracts.Entities;

namespace Clean.Domain.Entities.Category;

public class Category : AgreegateRoot<Category, Guid>
{
    private List<Product.Product> _products = new();
    public Category(string categoryName, string description) : base(Guid.NewGuid())
    {
        CategoryName = categoryName;
        Description = description;
    }

    private Category() : base(Guid.NewGuid())
    { }

    public string CategoryName { get; private set; }
    public string Description { get; private set; }
    public IEnumerable<Product.Product> Products => _products;


    public void ChangeCategory(string? categoryName, string? description)
    {
        if (!string.IsNullOrEmpty(categoryName) || !string.IsNullOrEmpty(description))
        {
            CategoryName = categoryName;
            Description = description;
        }
    }

    public void ChangeDescription(string description)
    {
        if (!string.IsNullOrEmpty(description))
        {
            Description = description;
        }
        throw new ArgumentNullException("");
    }

    public void AddProduct(Product.Product product)
    {
        if (!string.IsNullOrEmpty(product.ProductName))
        {
            _products.Add(product);

        }
        throw new ArgumentException("");
    }

    public void UpdateProduct(Product.Product product)
    {
        var existProduct = _products.SingleOrDefault(x => x.Id == product.Id);
        if (existProduct != null)
        {
            existProduct = product;
        }

        throw new Exception("");
    }

    public void ClearProducts()
    {
        _products.Clear();
    }

}

