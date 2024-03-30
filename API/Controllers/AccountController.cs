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
        
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task <IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            await _usersService.Register(registerDto.Name, registerDto.Login);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto  loginDto)
        {
            var token = await _usersService.Login(loginDto.Name, loginDto.Login);

            Response.Cookies.Append("test-cookies", token);

            return Ok(token);
        }
    }
}