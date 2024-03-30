using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<ProductIdDto>> GetListProductsIdByName(List<ProductDto> products);
    }
}