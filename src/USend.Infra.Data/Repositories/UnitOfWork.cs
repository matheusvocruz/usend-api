using USend.Domain.Interfaces;
using USend.Infra.Data.Contexts;
using System;
using System.Threading.Tasks;

namespace USend.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly USendContext _contexto;

        public UnitOfWork(USendContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Commit()
        {
            return await _contexto.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _contexto.Dispose();
        }
    }
}
