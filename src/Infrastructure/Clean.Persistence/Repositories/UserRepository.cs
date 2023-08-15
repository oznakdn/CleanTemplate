namespace Clean.Persistence.Repositories;

public class UserRepository : GenericRepository<AppUser, ApplicationDbContext, Guid>,IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}
