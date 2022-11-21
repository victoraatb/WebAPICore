namespace WebAPI.Auth;

public interface ICustomTokenManager
{
    string CreateToken(string userName);
    bool VerifyToken(string token);
    string GetUserInfoByToken(string token);
}