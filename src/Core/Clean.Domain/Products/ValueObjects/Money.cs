using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Products.Enums;

namespace Clean.Domain.Products.ValueObjects;

public class Money : ValueObject
{
    public Money(Currency moneyType, decimal amount)
    {
        Currency = moneyType;
        Amount = amount;
    }

    private Money() { }

    public Currency Currency { get; private set; }
    public decimal Amount { get; private set; }


    public void UpdateMoneyType(Currency? moneyType)
    {
        Currency = moneyType ?? default;
    }

    public void UpdateMoneyAmount(decimal? amount)
    {
        Amount = amount ?? default;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Currency.ToString();
        yield return Amount;
    }
}
