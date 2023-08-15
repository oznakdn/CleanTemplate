using AutoMapper;
using Clean.Domain.Entities;
using Clean.Persistence.Contexts;
using Clean.Persistence.Repositories.Abstracts;
using Clean.Persistence.Repositories.Interfaces;

namespace Clean.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product, ApplicationDbContext, Guid>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}
