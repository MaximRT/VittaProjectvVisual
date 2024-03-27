using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;
        public OrderController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateOrder(string userLogin, List<Product> products)
        {


            var order = new Order
            {
                DateCreation = DateTime.Now,
                Price = 3000,
            };




            await _context.Orders.AddAsync(order);
            
            var result = await _context.SaveChangesAsync() > 0;

            if (result) return Ok();

            return BadRequest();
        }
    }
}