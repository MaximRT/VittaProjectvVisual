using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер отвечающий за функционал связанный с пользователями
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        /// <summary>
        /// Конечная точка отвечающая за фунционал получения списка заказов пользователя
        /// </summary>
        /// <param name="id"> Идентификатор пользователя </param>
        /// <returns> Список заказов пользователя </returns>
        [HttpGet("listOrders/{id}")]
        public async Task<IActionResult> GetListOrdersById(Guid id)
        {
            return Ok(await _usersService.GetListUserOrdersAsync(id));
        }
    }
}