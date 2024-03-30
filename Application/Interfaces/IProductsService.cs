using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductsService
    {
        Task<List<ProductIdDto>> GetListIdProducts(List<ProductDto> products);
    }
}