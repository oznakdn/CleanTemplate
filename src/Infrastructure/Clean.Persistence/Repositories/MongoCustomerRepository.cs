using Clean.Domain.Entities.Customer;
using Clean.Persistence.Repositories.Common;

namespace Clean.Persistence.Repositories;

public class MongoCustomerRepository : MongoRepository<Customer>, IMongoCustomerRepository
{
    public MongoCustomerRepository(IOptions<MongoSettings> setting, string collectionName ="Customers") : base(setting, collectionName)
    {
    }
}