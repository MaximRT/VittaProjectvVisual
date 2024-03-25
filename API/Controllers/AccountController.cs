using API.DTOs;
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

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto )
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == loginDto.Login);

            if (user == null) return Unauthorized();

            return Ok();
        }
    }
}