﻿using Clean.Domain.Products;
using Clean.Domain.Products.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Common;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class ProductQuery : EFQueryRepository<Product, EFContext,Guid>, IProductQuery
{
    public ProductQuery(EFContext context) : base(context)
    {
    }

    public async Task<List<Product>> GetAllProductsWithInventoryAsync(int maxPage, int pageSize, int pageNumber, CancellationToken cancellationToken = default)
        => await _context.Products
        .Include(x => x.Inventory)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync(cancellationToken);

}
