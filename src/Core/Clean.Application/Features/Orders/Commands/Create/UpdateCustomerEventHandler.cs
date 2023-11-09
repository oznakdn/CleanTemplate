using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Customers;
using Clean.Domain.Customers.Events;

namespace Clean.Application.Features.Orders.Commands.Create;


public class UpdateCustomerEventHandler : DomainEventHandler<UpdateCustomerEvent, Customer>
{
    private readonly IQueryUnitOfWork _query;
    private readonly ICommandUnitOfWork _command;
    public UpdateCustomerEventHandler(IQueryUnitOfWork query, ICommandUnitOfWork command)
    {
        _query = query;
        _command = command;
    }

    protected async override Task<Customer> Handle(UpdateCustomerEvent @event, CancellationToken cancellationToken)
    {
        Event += (s, e) =>
        {
            _command.Customer.Update(@event.Customer);
        };

        EventInvoke(@event);
        await Task.FromResult(@event.Customer);
        return @event.Customer;
    }
}
