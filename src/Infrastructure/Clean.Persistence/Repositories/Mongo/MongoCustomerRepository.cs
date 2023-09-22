namespace Clean.Persistence.Repositories.Mongo;

public class MongoCustomerRepository : MongoRepository<Customer>, IMongoCustomerRepository
{
    public MongoCustomerRepository(IOptions<MongoSetting> setting, string collectionName ="Customers") : base(setting, collectionName)
    {
    }
}