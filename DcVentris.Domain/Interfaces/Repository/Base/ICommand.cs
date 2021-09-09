using System;
using System.Threading.Tasks;

namespace DcVentris.Domain.Interfaces.Repository.Base
{
    public interface ICommand<TEntity>
    {
        Task Add(TEntity entity);
        Task Update(Guid id, TEntity newEntity);
        Task Remove(Guid id);
    }
}
