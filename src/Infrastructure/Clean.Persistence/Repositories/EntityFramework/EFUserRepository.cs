namespace Clean.Persistence.Repositories;

public class EFUserRepository : EFRepository<AppUser, ApplicationDbContext, Guid>,IEFUserRepository
{
    public EFUserRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}
