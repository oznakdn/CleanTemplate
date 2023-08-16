namespace Clean.Persistence.Repositories.Mongo.Common;


public abstract class MongoRepository<TEntity> : IMongoRepositroy<TEntity>
where TEntity : MongoEntity, new()
{

    public IMapper Mapper { get; }
    private readonly IMongoCollection<TEntity> _collection;
    private readonly MongoSetting _setting;
    private readonly IMongoClient _mongoClient;
    public MongoRepository(IOptions<MongoSetting> setting, IMapper mapper,string collectionName)
    {
        Mapper = mapper;
        _setting = setting.Value;
        _mongoClient = new MongoClient(_setting.Connection);
        IMongoDatabase database = _mongoClient.GetDatabase(_setting.Database);
        _collection = database.GetCollection<TEntity>(collectionName);
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