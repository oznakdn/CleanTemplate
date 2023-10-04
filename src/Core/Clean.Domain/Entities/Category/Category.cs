using Clean.Domain.Contracts.ValueObjects;

namespace Clean.Domain.Entities.Category;

public class Category : ValueObject
{
    public string CategoryName { get; private set; }
    public string CategoryDescription { get; private set; }

    public Category ChangeCategoryName(string newName)
    {
        return new Category
        {
            CategoryName = newName,
            CategoryDescription = CategoryDescription
        };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return CategoryName;
        yield return CategoryDescription;
    }

}

