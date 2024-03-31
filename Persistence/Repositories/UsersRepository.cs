using Application;
using Application.DTOs;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;
        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await SaveChangesAsync();
        }

        public async Task<List<ListUserOrdersDto>> GetListUserOrdersAsync(Guid id)
        {
            return await _context.Orders.Where(x => x.UserId == id)
                .Select(x => new ListUserOrdersDto
                {
                    Id = x.Id,
                    DateCreation = x.DateCreation,
                    Price = x.Price
                })
                .ToListAsync();
        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Login == login);

            if (user != null) return user;

            return new User();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<List<User>> GetByPageAsync(int page, int pageSize)
        {
            return await _context.Users
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}