using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Products.ValueObjects;

public class Image : ValueObject
{
    public string ImageName { get; private set; }
    public string ImageSize { get; private set; }

    public Image(string imageName, string imageSize)
    {
        ImageName = imageName;
        ImageSize = imageSize;
    }

    private Image() { }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return ImageName;
        yield return ImageSize;
    }
}
