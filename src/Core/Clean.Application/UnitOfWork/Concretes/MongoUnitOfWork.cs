namespace Clean.Application.UnitOfWork.Concretes;

public class MongoUnitOfWork : IMongoUnitOfWork
{
    public IMapper Mapper { get; }
    public IMongoCustomerRepository Customer { get; }
    private readonly MongoSetting _setting;
    public MongoUnitOfWork(IMapper mapper,IOptions<MongoSetting>setting)
    {
        Mapper = mapper;
        _setting = setting.Value;
        Customer = new MongoCustomerRepository(setting);
    }
}
