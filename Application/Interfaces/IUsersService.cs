namespace Application.Interfaces
{
    public interface IUsersService
    {
        Task Register(string name, string login);
        Task<string> Login (string name, string login);
    }
}