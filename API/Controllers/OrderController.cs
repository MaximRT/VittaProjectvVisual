using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        private readonly IProductsService _productsService;
        private readonly IOrderPositionService _orderPositionService;

        public OrderController
        (
            IOrdersService ordersService, 
            IProductsService productsService,
            IOrderPositionService orderPositionService
        )
        {
            _productsService = productsService;
            _ordersService = ordersService;
            _orderPositionService = orderPositionService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            var orderId = await _ordersService.CreateOrderAsync(Guid.Parse(orderDto.UserId), orderDto.Price, DateTime.UtcNow);

            var productsIds = await _productsService.GetListIdProductsAsync(orderDto.Products);

            await _orderPositionService.AddOrderPositionsAsync(orderId, productsIds);

            await _productsService.UpdateCountProductsAsync(productsIds);
            
            return Ok();
        }
    }
}