using Clean.Domain.Contracts.Interfaces;
using Clean.Persistence.Options.Interfaces;

namespace Clean.Persistence.Repositories.MongoDriver.Common;

public class MongoQueryRepository<TCollection> : MongoContext<TCollection>,IMongoQueryRepository<TCollection>
where TCollection : IDocument
{
    public MongoQueryRepository(IMongoOption option, string CollectionName) : base(option, $"{CollectionName}s")
    { 
    }

    public virtual async Task<IEnumerable<TCollection>> ReadAllAsync(CancellationToken cancellationToken = default, 
        Expression<Func<TCollection, bool>> filter = null)
    {
       
        return await _collection.Find(filter == null ? x => true : filter).ToListAsync(cancellationToken);
    }

    public virtual async Task<TCollection> ReadFirstOrDefaultAsync(Expression<Func<TCollection, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken); ;
    }

    public virtual async Task<TCollection> ReadSingleOrDefaultAsync(Expression<Func<TCollection, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _collection.Find(filter).SingleOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<TCollection> ReadSingleAsync(Expression<Func<TCollection, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _collection.Find(filter).SingleAsync(cancellationToken);
    }

    public virtual async Task<TCollection> ReadFirstAsync(Expression<Func<TCollection, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _collection.Find(filter).FirstAsync(cancellationToken);
    }

    public virtual IEnumerable<TCollection> ReadAll(Expression<Func<TCollection, bool>> filter = null)
    {
        return _collection.Find(filter == null ? x => true : filter).ToList();
    }

    public virtual TCollection ReadSingleOrDefault(Expression<Func<TCollection, bool>> filter)
    {
        return _collection.Find(filter).SingleOrDefault();
    }

    public virtual TCollection ReadFirstOrDefaut(Expression<Func<TCollection, bool>> filter)
    {
        return _collection.Find(filter).FirstOrDefault();
    }

    public virtual TCollection ReadSingle(Expression<Func<TCollection, bool>> filter)
    {
        return _collection.Find(filter).Single();
    }

    public virtual TCollection ReadFirst(Expression<Func<TCollection, bool>> filter)
    {
        return _collection.Find(filter).First();
    }

    public async Task<IEnumerable<TCollection>> ReadAllWithPaginationAsync(int pageSize = 10, int pageNumber = 1, CancellationToken cancellationToken = default, Expression<Func<TCollection, bool>> filter = null)
    {
        return await _collection.Find(filter == null ? x => true : filter).Skip((pageNumber - 1) * pageSize).Limit(pageSize).ToListAsync(cancellationToken);
    }

    public IEnumerable<TCollection> ReadAllWithPagination(int pageSize = 10, int pageNumber = 1, Expression<Func<TCollection, bool>> filter = null)
    {
       return _collection.Find(filter == null ? x => true : filter).Skip((pageNumber - 1) * pageSize).Limit(pageSize).ToList();
    }

}
