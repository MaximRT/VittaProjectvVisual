using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IUsersService
    {
        Task Register(string name, string login);
        //Task<string> Login (string login);
        Task<User> GetUserByLoginAsync(string login);
        Task<List<ListUserOrdersDto>> GetListUserOrdersAsync(Guid userId);
    }
}