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

        public Task<List<ProductIdDto>> GetListIdProducts(List<ProductDto> products)
        {
            return _productsRepository.GetListProductsIdByName(products);
        }
    }
}