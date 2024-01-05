using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Customers.ValueObjects;
using Clean.Domain.Shared;

namespace Clean.Domain.Customers;

public class Customer : AggregateRoot<Customer, Guid>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Password { get; private set; }
    public Guid? BasketId { get; private set; }
    public CreditCard? CreditCard { get; private set; }
    public Address Address { get; private set; }


    protected Customer(string firstName, string lastName, string email, string phoneNumber, string password) : base(Guid.NewGuid())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
    }


    private Customer() : base(Guid.NewGuid()) { }

    public static TResult<Customer> CreateCustomer(string firstName, string lastName, string email, string phoneNumber, string password)
    {
        var errors = new List<string>();
        if (string.IsNullOrEmpty(firstName)) errors.Add($"{nameof(firstName)} cannot be empty!");
        if (string.IsNullOrEmpty(lastName)) errors.Add($"{nameof(lastName)} cannot be empty!");
        if (string.IsNullOrEmpty(email)) errors.Add($"{nameof(email)} cannot be empty!");
        if (string.IsNullOrEmpty(phoneNumber)) errors.Add($"{nameof(phoneNumber)} cannot be empty!");
        if (string.IsNullOrEmpty(password)) errors.Add($"{nameof(password)} cannot be empty!");

        if (errors.Count > 0)
            return TResult<Customer>.Fail(errors);

        Customer customer = new(firstName, lastName, email, phoneNumber, password);
        return TResult<Customer>.Ok(customer);

    }
    public void AddBasket(Guid basketId)
    {
        BasketId = basketId;
    }


    public Result AddAddress(string title, string district, int number, string city)
    {
        var errors = new List<string>();
        if (string.IsNullOrEmpty(title)) errors.Add($"{nameof(title)} cannot be empty!");
        if (string.IsNullOrEmpty(district)) errors.Add($"{nameof(district)} cannot be empty!");
        if (string.IsNullOrEmpty(city)) errors.Add($"{nameof(city)} cannot be empty!");
        if (number < 0) errors.Add($"{nameof(number)} cannot be less than 0!");

        if (errors.Count > 0)
            return Result.Fail(errors);

        Address = new Address(title, district, number, city);
        return Result.Ok();
    }


    public Result AddCreditCard(string name, string cardNumber, string cardDate, string cvv, decimal totalLimit)
    {
        var errors = new List<string>();
        if (string.IsNullOrEmpty(name)) errors.Add($"{nameof(this.CreditCard.Name)} cannot be empty!");
        if (string.IsNullOrEmpty(cardNumber)) errors.Add($"{nameof(this.CreditCard.CardNumber)} cannot be empty!");
        if (string.IsNullOrEmpty(cardDate)) errors.Add($"{nameof(this.CreditCard.CardDate)} cannot be empty!");
        if (string.IsNullOrEmpty(cvv)) errors.Add($"{nameof(this.CreditCard.Cvv)} cannot be empty!");
        if (totalLimit < 0) errors.Add($"{nameof(this.CreditCard.TotalLimit)} cannot be less than 0!");

        if (errors.Count > 0)
            return Result.Fail(errors);

        CreditCard = new CreditCard(name, cardNumber, cardDate, cvv, totalLimit);
        return Result.Ok();
    }

}
