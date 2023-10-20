using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;

namespace Clean.Persistence.Repositories.Common;


public abstract class MongoRepository<TEntity> : IMongoRepositroy<TEntity>
where TEntity : MongoEntity
{

    private readonly IMongoCollection<TEntity> _collection;
    private readonly MongoSettings _setting;
    private readonly IMongoClient _mongoClient;
    public MongoRepository(IOptions<MongoSettings> setting,string collection)
    {
        _setting = setting.Value;
        _mongoClient = new MongoClient(_setting.Connection);
        IMongoDatabase database = _mongoClient.GetDatabase(_setting.Database);
        _collection = database.GetCollection<TEntity>(collection);
    }

    public virtual void Delete(string id, CancellationToken cancellationToken) => _collection.DeleteOne(x => x.Id == id, cancellationToken);
    public virtual async Task DeleteAsync(string id, CancellationToken cancellationToken) => await _collection.DeleteOneAsync(x => x.Id == id, cancellationToken);
    public virtual void Insert(TEntity entity, CancellationToken cancellationToken) => _collection.InsertOne(entity, null, cancellationToken);
    public virtual async Task InsertAsync(TEntity entity, CancellationToken cancellationToken) => await _collection.InsertOneAsync(entity, null, cancellationToken);
    public virtual void Update(TEntity entity, CancellationToken cancellationToken) => _collection.ReplaceOne(x => x.Id == entity.Id, entity);
    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken) => await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>> filter = null) => await _collection.Find<TEntity>(filter == null ? x => true : filter).ToListAsync(cancellationToken);
    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken) => await _collection.Find<TEntity>(filter).SingleOrDefaultAsync(cancellationToken);
    public virtual async Task<TEntity> GetByIdAsync(string id, CancellationToken cancellationToken) => await _collection.Find<TEntity>(x => x.Id == id).SingleOrDefaultAsync(cancellationToken);



}