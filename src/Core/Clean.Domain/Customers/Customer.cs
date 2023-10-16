using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Customers;

public class Customer : AggregateRoot<Customer,Guid>
{
    private List<Address> _adresses = new();
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Password { get; private set; }
    public Guid? BasketId { get; private set; }
    public IReadOnlyCollection<Address> Addresses => _adresses;


    public Customer(string firstName, string lastName, string email, string phoneNumber, string password) : base(Guid.NewGuid())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
    }

    private Customer() : base(Guid.Empty) { }

    public void AddBasket(Guid basketId)
    {
        BasketId = basketId;
    }


    public void AddAddress(string title, string district, int number, string city)
    {
        _adresses.Add(new Address(title,district,number,city));
    }


    public void ClearAddresses()
    {
        _adresses.Clear();
    }

}
