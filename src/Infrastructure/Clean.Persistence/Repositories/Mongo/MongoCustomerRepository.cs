using Clean.Persistence.Data.Mongo;
using Clean.Persistence.Data.Mongo.Repositories.Abstracts;
using Clean.Persistence.Repositories.Mongo.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Clean.Persistence.Repositories.Mongo;

public class MongoCustomerRepository : MongoRepository<Customer>, IMongoCustomerRepository
{
    public MongoCustomerRepository(IOptions<MongoSetting> setting, IMapper mapper, string collectionName ="Customers") : base(setting, mapper, collectionName)
    {
    }
}