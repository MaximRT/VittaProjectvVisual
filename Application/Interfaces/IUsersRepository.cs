using Application.DTOs;
using Domain;

namespace Application
{
    public interface IUsersRepository
    {
        Task<User> GetUserByLoginAsync(string login);
        Task<List<ListUserOrdersDto>> GetListUserOrdersAsync(Guid id);
        Task SaveChangesAsync();
    }
}