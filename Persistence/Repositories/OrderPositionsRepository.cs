using Application.DTOs;
using Application.Interfaces;
using Domain;

namespace Persistence.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностью OrderPosition
    /// </summary>
    public class OrderPositionsRepository : IOrderPositionsRepository
    {
        private readonly DataContext _context;
        public OrderPositionsRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавить позиции товаров в заказе
        /// </summary>
        /// <param name="orderId"> Идентификатор заказа </param>
        /// <param name="productsIds"> Список индентификаторов товаров </param>
        /// <returns> Результат выполнения задачи </returns>
        public async Task AddOrderPosition(Guid orderId, List<ProductIdDto> productsIds)
        {
            foreach (var product in productsIds)
            {
                var positionOrder = CreateOrderPositionObject(Guid.NewGuid(), orderId, product.Id, product.Count);
                await _context.OrderPositions.AddAsync(positionOrder);
            }

            await SaveChangesAsync();
        }
        
        /// <summary>
        /// Сохранение изменений в базе данных
        /// </summary>
        /// <returns> Результат выполнения задачи </returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Создание объекта сущности OrderPosition
        /// </summary>
        /// <param name="id"> Идентификатор OrderPosition </param>
        /// <param name="orderId"> Идентификатор заказа </param>
        /// <param name="productId"> Идентификатор товара </param>
        /// <param name="count"> Количество товара </param>
        /// <returns></returns>
        private OrderPosition CreateOrderPositionObject(Guid id, Guid orderId, Guid productId, int count)
        {
            return new OrderPosition
            {
                Id = id,
                OrderId = orderId,
                ProductId = productId,
                Count = count
            };
        }
    }
}