using Application.DTOs;
using Application.Interfaces;

namespace Application.Services
{
    /// <summary>
    /// Сервис взаимодействия с областью Product
    /// </summary>
    public class ProductService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        
        public ProductService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        /// <summary>
        /// Получение списка продуктов
        /// </summary>
        /// <returns> Список продуктов </returns>
        public async Task<List<ProductToUserDto>> GetListProductsAsync()
        {
            return await _productsRepository.GetListProductsAsync();
        }

        /// <summary>
        /// Получение списка идентификаторов товаров по их названиям
        /// </summary>
        /// <param name="products"> Список название товаров </param>
        /// <returns> Список идентификаторов </returns>
        public async Task<List<ProductIdDto>> GetListIdProductsAsync(List<ProductNameDto> products)
        {
            return await _productsRepository.GetListProductsIdByNameAsync(products);
        }

        /// <summary>
        /// Обновление количества товаров
        /// </summary>
        /// <param name="products"> Список идентификаторов </param>
        /// <returns> Результат выполнения задачи </returns>
        public async Task UpdateCountProductsAsync(List<ProductIdDto> products)
        {
            await _productsRepository.UpdateCountProductsAsync(products);
        }
    }
}