namespace MyApp.Repository;

public interface ITokenRepository
{
    Task SetToken(string token);
    Task<string> GetToken();
}