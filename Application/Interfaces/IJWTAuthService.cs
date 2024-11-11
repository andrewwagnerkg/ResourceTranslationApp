namespace Application.Interfaces
{
    public interface IJWTAuthService
    {
        Task<string> Authentiticate(string username, string password);
    }
}
