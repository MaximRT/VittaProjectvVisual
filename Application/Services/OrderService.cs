using Application.Interfaces;

namespace Application.Services
{
    public class OrderService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrderService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }


        public async Task<Guid> CreateOrderAsync(Guid userId, decimal price, DateTime dateCreation)
        {
            return await _ordersRepository.CreateOrderAsync(dateCreation, price, userId);
        }
    }
}