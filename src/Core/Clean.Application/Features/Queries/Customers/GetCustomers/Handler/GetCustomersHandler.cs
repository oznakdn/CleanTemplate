namespace Clean.Application.Features.Queries.Customers.GetCustomers.Handler;

public class GetCustomersHandler:AbstractHandler<GetCustomersRequest,List<GetCustomersResponse>>
{
    private readonly IMongoCustomerRepository _mongoCustomer;

    public GetCustomersHandler(IMongoCustomerRepository mongoCustomer)
    {
        _mongoCustomer = mongoCustomer;
    }

    public async override Task<List<GetCustomersResponse>> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
    {
        var customers = await _mongoCustomer.GetAllAsync(cancellationToken);
        var result = _mongoCustomer.Mapper.Map<List<GetCustomersResponse>>(customers);

         return result;
    }
}