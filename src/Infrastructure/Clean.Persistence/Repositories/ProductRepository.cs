using AutoMapper;
using Clean.Domain.Entities;
using Clean.Persistence.Contexts;
using Clean.Persistence.Repositories.Abstracts;
using Clean.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clean.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product, SQLiteContext, Guid>, IProductRepository
{
    public ProductRepository(SQLiteContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}
