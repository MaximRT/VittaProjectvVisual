using Application.Interfaces;
using Domain;

namespace Persistence.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностью Order
    /// </summary>
    public class OrdersRepository : IOrdersRepository
    {
        private readonly DataContext _context;
        public OrdersRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Создание заказа
        /// </summary>
        /// <param name="dateCreation"> Дата создания </param>
        /// <param name="price"> Итоговая цена </param>
        /// <param name="userId"> Идентификатор пользователя </param>
        /// <returns> Идентификатор созданного заказа </returns>
        public async Task<Guid> CreateOrderAsync(DateTime dateCreation, decimal price, Guid userId)
        {
            var orderId = Guid.NewGuid();

            await _context.Orders.AddAsync(new Order{Id = orderId, DateCreation = dateCreation, Price = price, UserId = userId});
            await SaveChangesAsync();
            
            return orderId;
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