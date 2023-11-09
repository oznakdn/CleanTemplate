using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Baskets.Events;

public class CreateBasketEvent : IDomaintEvent
{
    public CreateBasketEvent(string customerId)
    {
        CustomerId = customerId;
    }

    public string CustomerId { get; set; }
    public Basket Basket { get; set; }
}
