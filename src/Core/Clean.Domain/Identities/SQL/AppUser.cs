namespace Clean.Domain.Identities.SQL;

public class AppUser : UserIdentity<Guid>
{
    public string RefreshToken { get; set; }
    public DateTime ExpiredDate { get; set; }
}
