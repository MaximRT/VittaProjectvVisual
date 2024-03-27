using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class CoursesRepository
    {
        private readonly DataContext _context;
        public CoursesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByLogin(string login)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Login == login);

            if (user != null) return user;

            return new User();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<List<User>> GetByPage(int page, int pageSize)
        {
            return await _context.Users
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}