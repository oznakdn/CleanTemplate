using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Customers.Events;

public class UpdateCustomerEvent : IDomaintEvent
{
    public UpdateCustomerEvent(Customer customer)
    {
        Customer = customer;
    }

    public Customer Customer { get; set; }
}
