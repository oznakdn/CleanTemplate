namespace Clean.Identity.Jwt.Handler;

public interface IJwtHandler
{
    TokenResponse GenerateToken<TUser, TKey>(TUser user, int ExpireTime, ExpireType expireType) where TUser : UserIdentity<TKey>;
    TokenResponse GenerateRefreshToken(int ExpireTime, ExpireType expireType);
}
