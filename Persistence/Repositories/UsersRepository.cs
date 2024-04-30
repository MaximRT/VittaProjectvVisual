using Application;
using Application.DTOs;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностью Users
    /// </summary>
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;
        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Тестовый метод
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsFalse()
        {
            return false;
        }


        /// <summary>
        /// Получение списка заказов пользователя
        /// </summary>
        /// <param name="id"> Идентификатор пользователя </param>
        /// <returns> Список заказов пользователя </returns>
        public async Task<List<ListUserOrdersDto>> GetListUserOrdersAsync(Guid id)
        {
            return await _context.Orders.Where(x => x.UserId == id)
                .Select(x => new ListUserOrdersDto
                {
                    Id = x.Id,
                    DateCreation = x.DateCreation,
                    Price = x.Price
                })
                .ToListAsync();
        }

        /// <summary>
        /// Получение пользователя
        /// </summary>
        /// <param name="login"> Электронная почта </param>
        /// <returns> Пользователь </returns>
        public async Task<User> GetUserByLoginAsync(string login)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Login == login);

            if (user != null) return user;

            return new User();
        }
        
        /// <summary>
        /// Сохранение изменений в базе данных
        /// </summary>
        /// <returns> Результат выполнения задачи </returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}