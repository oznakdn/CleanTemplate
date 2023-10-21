using Clean.Domain.Products;
using Clean.Domain.Repositories.Commands;
using Gleeman.Repository.EFCore.Abstracts.Command;

namespace Clean.Persistence.Repositories.Commands;

public class ProductCommand : EFCommandRepository<Product, ApplicationDbContext>, IProductCommand
{
    public ProductCommand(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
