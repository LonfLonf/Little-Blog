using LivingAsIntern.Data;
using LivingAsIntern.Entities;
using Microsoft.EntityFrameworkCore;

namespace LivingAsIntern.Services
{
    public class UserServiceDb
    {
        private AppDbContext _context;

        public UserServiceDb(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<User> GetUserByUsername(string Username)
        {
            var user = await _context.users.FirstOrDefaultAsync(x => x.Username == Username);

            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            return user;

        }
    }
}
