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

        public async Task<User> GetUserByLogin(string login)
        {
            return await _usersRepository.GetUserByLoginAsync(login);
        }

        public async Task<string> Login(string name, string login)
        {
            var user = await _usersRepository.GetUserByLoginAsync(login);

            if (user.Login == null) return "The user was not found";

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }

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