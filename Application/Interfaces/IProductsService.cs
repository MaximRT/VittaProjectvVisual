using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductsService
    {
        Task<List<ProductIdDto>> GetListIdProductsAsync(List<ProductNameDto> products);
        Task UpdateCountProductsAsync(List<ProductIdDto> products);
        Task<List<ProductToUserDto>> GetListProductsAsync();
    }
}