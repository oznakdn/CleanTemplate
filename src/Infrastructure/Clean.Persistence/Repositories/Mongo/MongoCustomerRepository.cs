namespace Clean.Persistence.Repositories.Mongo;

public class MongoCustomerRepository : MongoRepository<Customer>, IMongoCustomerRepository
{
    public MongoCustomerRepository(IOptions<MongoSetting> setting, IMapper mapper, string collectionName ="Customers") : base(setting, mapper, collectionName)
    {
    }
}