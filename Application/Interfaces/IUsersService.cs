using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IUsersService
    {
        Task<User> GetUserByLoginAsync(string login);
        Task<List<ListUserOrdersDto>> GetListUserOrdersAsync(Guid userId);
    }
}