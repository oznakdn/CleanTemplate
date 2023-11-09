using Clean.Domain.Products;
using Clean.Domain.Products.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Common;

namespace Clean.Persistence.Repositories.EntityFramework.Commands;

public class ProductCommand : EFCommandRepository<Product, EFContext, Guid>, IProductCommand
{
    public ProductCommand(EFContext context) : base(context)
    {
    }
}
