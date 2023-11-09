using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Products.ValueObjects;

public class Category : ValueObject
{
    public string DisplayName { get; private set; }

    public Category(string displayName)
    {
        DisplayName = displayName;
    }

    private Category() { }

    public void Update(string newName)
    {
        DisplayName = newName;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return DisplayName;
    }
}
