using Clean.Application.Features.Queries.CustomerQueries.Get.Dtos;

namespace Clean.Application.Features.Queries.CustomerQueries.Get.Handler;

public class GetCustomersHandler : IRequestHandler<GetCustomersRequest, List<GetCustomersResponse>>
{

    private readonly IMongoUnitOfWork _mongoUnitOfWork;


    public GetCustomersHandler(IMongoUnitOfWork mongoUnitOfWork)
    {
        _mongoUnitOfWork = mongoUnitOfWork;
    }

    public async Task<List<GetCustomersResponse>> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
    {
        var customers = await _mongoUnitOfWork.Customer.GetAllAsync(cancellationToken);
        var result = _mongoUnitOfWork.Mapper.Map<List<GetCustomersResponse>>(customers);
        return result;
    }
}