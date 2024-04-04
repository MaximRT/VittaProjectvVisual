using Application.DTOs;
using Application.Interfaces;

namespace Application.Services
{
    /// <summary>
    /// Сервис взаимодействия с областью OrderPosition
    /// </summary>
    public class OrderPositionService : IOrderPositionService
    {
        private readonly IOrderPositionsRepository _orderPositionsRepository;
        public OrderPositionService(IOrderPositionsRepository orderPositionsRepository)
        {
            _orderPositionsRepository = orderPositionsRepository;
        }

        /// <summary>
        /// Добавление позиций товаров в заказ
        /// </summary>
        /// <param name="orderId"> Идентификатор задача </param>
        /// <param name="productsIds"> Список идентификаторов товаров </param>
        /// <returns> Результат выполнения задачи </returns>
        public async Task AddOrderPositionsAsync(Guid orderId, List<ProductIdDto> productsIds)
        {
            await _orderPositionsRepository.AddOrderPosition(orderId, productsIds);
        }
    }
}