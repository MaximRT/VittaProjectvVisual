using System.Threading.Tasks;

namespace client_app.LoginSection.UserAccountService
{
    public interface IUserAccount
    {
        Task<string> LoginAsync(string login);
    }
}