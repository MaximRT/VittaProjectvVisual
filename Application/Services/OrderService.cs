using Application.Interfaces;

namespace Application.Services
{
    /// <summary>
    /// Сервис взаимодействия с областью Order
    /// </summary>
    public class OrderService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrderService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        /// <summary>
        /// Создание заказа
        /// </summary>
        /// <param name="userId"> Идентификатор пользователя </param>
        /// <param name="price"> Цена </param>
        /// <param name="dateCreation"> Дата создания </param>
        /// <returns></returns>
        public async Task<Guid> CreateOrderAsync(Guid userId, decimal price, DateTime dateCreation)
        {
            return await _ordersRepository.CreateOrderAsync(dateCreation, price, userId);
        }
    }
}