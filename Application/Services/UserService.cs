using Domain;
using Persistence;
using Persistence.Interfaces;

namespace Application.Services
{
    public class UserService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UserService(IUsersRepository usersRepository, IJwtProvider jwtProvider)
        {
            _usersRepository = usersRepository;
        }

        public async Task<string> Login(string name, string login)
        {
            var user = await _usersRepository.GetUserByLoginAsync(login);
            
            throw new NotImplementedException();
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