using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Customers;

public class Customer : AggregateRoot<Customer,Guid>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Password { get; private set; }
    public Guid? BasketId { get; private set; }
    public CreditCard CreditCard { get; private set; }
    public Address Address { get; private set; }


    public Customer(string firstName, string lastName, string email, string phoneNumber, string password) : base(Guid.NewGuid())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
    }


    private Customer() : base(Guid.NewGuid()) { }


    public void AddBasket(Guid basketId)
    {
        BasketId = basketId;
    }


    public void AddAddress(string title, string district, int number, string city)
    {
        Address = new Address(title, district, number, city);
    }


    public void AddCreditCard(string name,string cardNumber,string cardDate,string cvv, decimal totalLimit)
    {
        CreditCard = new CreditCard(name,cardNumber,cardDate,cvv,totalLimit);
    }

}
