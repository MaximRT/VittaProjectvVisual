using Application.DTOs;
using Application.Interfaces;
using Domain;

namespace Application.Services
{
    public class UserService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtProvider _jwtProvider;
        public UserService(IUsersRepository usersRepository, IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
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

        /*
        public async Task<string> Login(string login)
        {
            var user = await _usersRepository.GetUserByLoginAsync(login);

            if (user.Login == null) return null;

            return user.Id.ToString();
        }
        */

        public async Task Register(string name, string login)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Login = login
            };

            await _usersRepository.CreateAsync(user);  
        }
    }
}