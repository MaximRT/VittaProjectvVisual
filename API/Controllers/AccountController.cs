using API.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task <IActionResult> Register(UserService userService, RegisterDto registerDto)
        {
            await userService.Register(registerDto.Name, registerDto.Login);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserService userService, LoginDto loginDto)
        {
            var token = await userService.Login(loginDto.Name, loginDto.Login);

            return Ok();
        }
    }
}