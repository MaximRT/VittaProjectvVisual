using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер отвечающий за функционал связанный с товарами в системе
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }
        
        /// <summary>
        /// Конечная точка отвечающая за фунционал получения списка продуктов
        /// </summary>
        /// <returns> Список с информацией о продуктах  </returns>
        [HttpGet("list")]
        public async Task<IActionResult> GetListProducts()
        {
            return Ok(await _productsService.GetListProductsAsync());
        }
    }
}