using Clean.Persistence.Repositories.EntityFramework;
using Clean.Persistence.Repositories.EntityFramework.Interfaces;

namespace Clean.Application.UnitOfWork.Concretes;

public class EfUnitOfWork : IEfUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public IMapper Mapper { get; }
    public IEFProductRepository Product { get; }
    public IEFUserRepository User { get; }

    public IEFRoleRepository Role { get; }

    public EfUnitOfWork(IMapper mapper, ApplicationDbContext dbContext)
    {
        Mapper = mapper;
        _dbContext = dbContext;
        Product = new EFProductRepository(_dbContext);
        User = new EFUserRepository(_dbContext);
        Role = new EFRoleRepository(_dbContext);
    }

    public void Save() => _dbContext.SaveChanges();
    public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();

}
