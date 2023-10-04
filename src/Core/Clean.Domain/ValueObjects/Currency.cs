using Clean.Domain.Contracts.ValueObjects;

namespace Clean.Domain.ValueObjects;


public enum CurrencyType
{
    TL,
    DOLAR,
    EURO,
    CAD,
}
public class Currency : ValueObject
{
    public CurrencyType CurrencyType { get; private set; }
    public decimal Price { get; private set; }

    public Currency(CurrencyType currencyType, decimal price)
    {
        CurrencyType = currencyType;
        Price = price;
    }

    private Currency() { }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return CurrencyType.ToString();
        yield return Price;
    }
}
