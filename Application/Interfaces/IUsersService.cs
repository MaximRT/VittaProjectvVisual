using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IUsersService
    {
        Task Register(string name, string login);
        Task<string> Login (string name, string login);
        Task<User> GetUserByLoginAsync(string login);
        Task<List<ListUserOrdersDto>> GetListUserOrdersAsync(string login);
    }
}