using USend.Domain.Entities;
using System.Threading.Tasks;


namespace USend.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> HasUserWithEmail(string email);
        Task<User> GetByEmailAsync(string email);
    }
}
