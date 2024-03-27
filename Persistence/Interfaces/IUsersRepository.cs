using Domain;

namespace Persistence
{
    public interface IUsersRepository
    {
        Task CreateAsync(User user);
        Task<User> GetUserByLoginAsync(string login);
        Task<List<User>> GetUsersAsync();
        Task<List<User>> GetByPageAsync(int page, int pageSize);
    }
}