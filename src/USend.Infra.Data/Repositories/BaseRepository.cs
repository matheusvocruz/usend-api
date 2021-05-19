using USend.Domain.Entities;
using USend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USend.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _context;

        public BaseRepository(DbContext context)
        {
            _context = context.Set<TEntity>();
        }

        public void Delete(TEntity entityToDelete)
        {
            _context.Remove(entityToDelete);
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> Include()
        {
            return _context.AsQueryable();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return Include();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Include().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await Include().FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Insert(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            _context.Update(entityToUpdate);
        }
    }
}
