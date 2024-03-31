using Application.DTOs;
using Application.Interfaces;

namespace Application.Services
{
    public class OrderPositionService : IOrderPositionService
    {
        private readonly IOrderPositionsRepository _orderPositionsRepository;
        public OrderPositionService(IOrderPositionsRepository orderPositionsRepository)
        {
            _orderPositionsRepository = orderPositionsRepository;
        }

        public async Task AddOrderPositionsAsync(Guid orderId, List<ProductIdDto> productsIds)
        {
            await _orderPositionsRepository.AddOrderPosition(orderId, productsIds);
        }
    }
}