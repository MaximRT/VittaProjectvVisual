using Application.DTOs;
using Application.Interfaces;
using Domain;

namespace Application.Services
{
    /// <summary>
    /// Сервис взаимодействия с областью User
    /// </summary>
    public class UserService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        /// <summary>
        /// Получение списка заказов пользователя
        /// </summary>
        /// <param name="userId"> Идентификатор </param>
        /// <returns> Список заказов </returns>
        public async Task<List<ListUserOrdersDto>> GetListUserOrdersAsync(Guid userId)
        {
            return await _usersRepository.GetListUserOrdersAsync(userId);
        }

        /// <summary>
        /// Получение пользователя по логину
        /// </summary>
        /// <param name="login"> Логин </param>
        /// <returns> Объект </returns>
        public async Task<User> GetUserByLoginAsync(string login)
        {
            return await _usersRepository.GetUserByLoginAsync(login);
        }
    }
}