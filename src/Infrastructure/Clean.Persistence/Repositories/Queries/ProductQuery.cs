using Clean.Domain.Products;
using Clean.Domain.Repositories.Queries;
using Gleeman.Repository.EFCore.Abstracts.Query;

namespace Clean.Persistence.Repositories.Queries;

public class ProductQuery : EFQueryRepository<Product, ApplicationDbContext>,IProductQuery
{
    public ProductQuery(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
