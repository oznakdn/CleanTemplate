using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Shared;

namespace Clean.Domain.Customers.ValueObjects;

public class CreditCard : ValueObject
{
    public CreditCard(string name, string cardNumber, string cardDate, string cvv, decimal totalLimit)
    {
        Name = name;
        CardNumber = cardNumber;
        CardDate = cardDate;
        Cvv = cvv;
        TotalLimit = totalLimit;
        SetAvailableLimit();
    }

    protected CreditCard() { }

    public string Name { get; private set; }
    public string CardNumber { get; private set; }
    public string CardDate { get; private set; }
    public string Cvv { get; private set; }
    public decimal TotalLimit { get; private set; }
    public decimal TotalDebt { get; private set; }
    public decimal AvailableLimit { get; private set; }


    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
        yield return CardNumber;
        yield return CardDate;
        yield return Cvv;
        yield return TotalLimit;
        yield return TotalDebt;
        yield return AvailableLimit;
    }

    public Result CardSpend(decimal amount)
    {
        SetAvailableLimit();
        if (AvailableLimit >= amount)
        {
            TotalDebt += amount;
            AvailableLimit = TotalLimit - TotalDebt;
            return Result.Ok();
        }
        return Result.Fail("Card limit is not available!");
    }

    private decimal SetAvailableLimit() => AvailableLimit = TotalLimit - TotalDebt;

}
