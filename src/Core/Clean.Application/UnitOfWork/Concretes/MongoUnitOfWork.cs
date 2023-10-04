using Clean.Domain.Entities.Customer;
using Clean.Persistence;

namespace Clean.Application.UnitOfWork.Concretes;

public class MongoUnitOfWork : IMongoUnitOfWork
{
    public IMapper Mapper { get; }
    public IMongoCustomerRepository Customer { get; }
    private readonly MongoSettings _setting;
    public MongoUnitOfWork(IMapper mapper,IOptions<MongoSettings>setting)
    {
        Mapper = mapper;
        _setting = setting.Value;
        Customer = new MongoCustomerRepository(setting);
    }
}
