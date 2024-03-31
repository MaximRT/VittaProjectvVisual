using Application.Interfaces;
using Domain;

namespace Persistence.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly DataContext _context;
        public OrdersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateOrderAsync(DateTime dateCreation, decimal price, Guid userId)
        {
            var orderId = Guid.NewGuid();

            await _context.Orders.AddAsync(new Order{Id = orderId, DateCreation = dateCreation, Price = price, UserId = userId});
            await _context.SaveChangesAsync();
            
            return orderId;
        }
    }
}