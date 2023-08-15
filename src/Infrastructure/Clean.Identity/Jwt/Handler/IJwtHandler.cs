namespace Clean.Identity.Jwt.Handler;

public interface IJwtHandler
{
    TokenResponse GenerateToken<TUser, TKey>(TUser user, int ExpiredCount, ExpireType expireType) where TUser : UserIdentity<TKey>;
    TokenResponse GenerateRefreshToken(int ExpiredCount, ExpireType expireType);
}
