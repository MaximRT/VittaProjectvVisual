using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<ProductIdDto>> GetListProductsIdByNameAsync(List<ProductNameDto> products);
        Task UpdateCountProductsAsync(List<ProductIdDto> products);
        Task<List<ProductToUserDto>> GetListProductsAsync();
        Task SaveChangesAsync();
    }
}