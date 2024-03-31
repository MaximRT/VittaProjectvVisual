using Application.DTOs;

namespace Application.Interfaces
{
    public interface IOrderPositionService
    {
        Task AddOrderPositionsAsync(Guid userId, List<ProductIdDto> productsIds);
    }
}