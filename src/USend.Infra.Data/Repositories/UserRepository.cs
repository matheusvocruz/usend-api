using USend.Domain.Entities;
using USend.Domain.Interfaces;
using USend.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace USend.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly USendContext _context;
        public UserRepository(USendContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> HasUserWithEmail(string email)
            =>  await GetByEmailAsync(email) != null;

        public async Task<User> GetByEmailAsync(string email)
            => await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }
}
