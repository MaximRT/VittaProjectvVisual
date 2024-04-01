using API.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public AccountController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        
        [HttpPost("register")]
        public async Task <IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            await _usersService.Register(registerDto.Name, registerDto.Login);

            return Ok();
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var user = await _usersService.GetUserByLoginAsync(login.Login);

            if (user.Name == null) return BadRequest("Пользователь не найден");

            return Ok(user.Id);
        }
    }
}