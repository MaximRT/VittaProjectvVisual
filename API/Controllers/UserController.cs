using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("listOrders/{id}")]
        public async Task<IActionResult> GetListOrdersById(Guid id)
        {
            return Ok(await _usersService.GetListUserOrdersAsync(id));
        }
    }
}