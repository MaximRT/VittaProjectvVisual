using Application;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IOrdersService _ordersService;
        private readonly IProductsService _productsService;
        public OrderController(IUsersRepository usersRepository, IOrdersService ordersService, IProductsService productsService)
        {
            _productsService = productsService;
            _ordersService = ordersService;
            _usersRepository = usersRepository;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateOrder( [FromBody] OrderDto orderDto)
        {
            var user = await _usersRepository.GetUserByLoginAsync(orderDto.UserLogin);

            var orderId = await _ordersService.CreateAsync(user.Id, orderDto.Price, DateTime.UtcNow);

            var productsIds = await _productsService.GetListIdProducts(orderDto.Products);

            
            return Ok(orderId);
        }
    }
}