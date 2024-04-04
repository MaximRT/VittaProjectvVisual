using Application.DTOs;
using Application.Interfaces;
using Domain;

namespace Application.Services
{
    public class UserService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<List<ListUserOrdersDto>> GetListUserOrdersAsync(Guid userId)
        {
            return await _usersRepository.GetListUserOrdersAsync(userId);
        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            return await _usersRepository.GetUserByLoginAsync(login);
        }
    }
}