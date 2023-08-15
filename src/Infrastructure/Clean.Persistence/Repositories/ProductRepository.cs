namespace Clean.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product, ApplicationDbContext, Guid>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}
