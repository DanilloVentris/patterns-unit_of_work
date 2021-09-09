using System;
using System.Threading.Tasks;
using DcVentris.Domain.Interfaces;
using DcVentris.Infrastructure.Context;

namespace DcVentris.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DcVentrisContext _context;

        public UnitOfWork(DcVentrisContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {            
            var success = (await _context.SaveChangesAsync()) > 0;

            if (!success) await Rollback();

            return success;
        }

        public Task Rollback() => Task.CompletedTask;


        ~UnitOfWork() =>
            Dispose();

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing) _context.Dispose();

            _disposed = true;
        }
    }
}
