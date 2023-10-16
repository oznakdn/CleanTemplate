using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Products;

public class Money : ValueObject
{
    public Money(MoneyType moneyType, decimal amount)
    {
        MoneyType = moneyType;
        Amount = amount;
    }

    private Money() { }

    public MoneyType MoneyType { get; private set; }
    public decimal Amount { get; private set; }


    public void UpdateMoneyType(MoneyType moneyType)
    {
        MoneyType = moneyType;
    }

    public void UpdateMoneyAmount(decimal amount)
    {
        Amount = amount;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return MoneyType.ToString();
        yield return Amount;
    }
}
