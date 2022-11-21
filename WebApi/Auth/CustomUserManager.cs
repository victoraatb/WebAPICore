namespace WebAPI.Auth;

public class CustomUserManager : ICustomUserManager
{
    private Dictionary<string, string> credentials = new Dictionary<string, string>()
    {
        { "victor", "123" },
        { "mariana", "321" }
    };
    
    private readonly ICustomTokenManager _customTokenManager;

    public CustomUserManager(ICustomTokenManager customTokenManager)
    {
        _customTokenManager = customTokenManager;
    }
    
    public string Authenticate(string userName, string password)
    {
        if (credentials[userName] != password) return string.Empty;
        return _customTokenManager.CreateToken(userName);
    }
    
}