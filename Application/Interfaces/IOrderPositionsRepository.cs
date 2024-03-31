using Application.DTOs;

namespace Application.Interfaces
{
    public interface IOrderPositionsRepository
    {
        Task AddOrderPosition(Guid orderId, List<ProductIdDto> productsIds);
        Task SaveChangesAsync();
    }
}