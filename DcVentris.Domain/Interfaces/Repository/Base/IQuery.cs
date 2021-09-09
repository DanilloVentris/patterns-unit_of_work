using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DcVentris.Domain.Interfaces.Repository.Base
{
    public interface IQuery<TEntity>
    {
        Task<TEntity> GetById(Guid id);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null);
    }
}
