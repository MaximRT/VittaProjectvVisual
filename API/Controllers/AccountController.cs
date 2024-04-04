using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер отвечающий за функционал аккаунта пользователя
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public AccountController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        /// <summary>
        /// Конечная точка отвечающая за вход пользователя в систему
        /// </summary>
        /// <param name="login"> email пользователя </param>
        /// <returns> Id пользователя </returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var user = await _usersService.GetUserByLoginAsync(login.Login);

            if (user.Name == null) return BadRequest("Пользователь не найден");

            return Ok(user.Id);
        }
    }
}