using System;
using System.Threading.Tasks;

namespace DcVentris.Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
