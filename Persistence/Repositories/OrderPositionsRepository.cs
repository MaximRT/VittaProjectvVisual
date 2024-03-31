using Application.DTOs;
using Application.Interfaces;
using Domain;

namespace Persistence.Repositories
{
    public class OrderPositionsRepository : IOrderPositionsRepository
    {
        private readonly DataContext _context;
        public OrderPositionsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddOrderPosition(Guid orderId, List<ProductIdDto> productsIds)
        {
            foreach (var product in productsIds)
            {
                var positionOrder = CreateOrderPositionObject(Guid.NewGuid(), orderId, product.Id, product.Count);
                await _context.OrderPositions.AddAsync(positionOrder);
            }

            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

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