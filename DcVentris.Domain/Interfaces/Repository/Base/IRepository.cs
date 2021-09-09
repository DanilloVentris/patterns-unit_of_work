using DcVentris.Domain.Entities.Base;

namespace DcVentris.Domain.Interfaces.Repository.Base
{
    public interface IRepository<TEntity> : IQuery<TEntity>, ICommand<TEntity> where TEntity: Entity
    {
    }
}
