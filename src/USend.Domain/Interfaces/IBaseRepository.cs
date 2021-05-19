using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USend.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entityToDelete);
        void Delete(long id);
        IQueryable<TEntity> GetQueryable();
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(long id);
        IQueryable<TEntity> Include();
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}
