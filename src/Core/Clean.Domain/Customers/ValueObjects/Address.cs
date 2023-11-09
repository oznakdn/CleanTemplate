using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Customers.ValueObjects;

public class Address : ValueObject
{
    public string Title { get; private set; }
    public string District { get; private set; }
    public int Number { get; private set; }
    public string City { get; private set; }

    public Address(string title, string district, int number, string city)
    {
        Title = title;
        District = district;
        Number = number;
        City = city;
    }

    private Address() { }

    public void UpdateDistrict(string district)
    {
        District = district;
    }

    public void UpdateCity(string city)
    {
        City = city;
    }



    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Title;
        yield return District;
        yield return Number;
        yield return City;
    }
}
