using Application.DTOs;
using Application.Interfaces;

namespace Application.Services
{
    public class ProductService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        
        public ProductService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<List<ProductToUserDto>> GetListProductsAsync()
        {
            return await _productsRepository.GetListProductsAsync();
        }

        public async Task<List<ProductIdDto>> GetListIdProductsAsync(List<ProductNameDto> products)
        {
            return await _productsRepository.GetListProductsIdByNameAsync(products);
        }

        public async Task UpdateCountProductsAsync(List<ProductIdDto> products)
        {
            await _productsRepository.UpdateCountProductsAsync(products);
        }
    }
}