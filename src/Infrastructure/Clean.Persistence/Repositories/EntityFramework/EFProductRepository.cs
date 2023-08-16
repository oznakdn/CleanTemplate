namespace Clean.Persistence.Repositories;

public class EFProductRepository : EFRepository<Product, ApplicationDbContext, Guid>, IEFProductRepository
{
    public EFProductRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}
