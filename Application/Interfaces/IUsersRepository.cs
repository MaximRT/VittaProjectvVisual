using Application.DTOs;
using Domain;

namespace Application
{
    public interface IUsersRepository
    {
        Task CreateAsync(User user);
        Task<User> GetUserByLoginAsync(string login);
        Task<List<ListUserOrdersDto>> GetListUserOrdersAsync(Guid id);
        Task<List<User>> GetUsersAsync();
        Task<List<User>> GetByPageAsync(int page, int pageSize);  
    }
}