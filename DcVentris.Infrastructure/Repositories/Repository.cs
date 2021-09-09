using System;
using System.Linq;
using System.Linq.Expressions;
using DcVentris.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using DcVentris.Domain.Entities.Base;
using DcVentris.Domain.Interfaces.Repository.Base;

namespace DcVentris.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DcVentrisContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DcVentrisContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task Add(TEntity entity) => await _dbSet.AddAsync(entity);

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate) => await _dbSet.FirstOrDefaultAsync(predicate);

        public async Task<TEntity> GetById(Guid id) => await _dbSet.FirstOrDefaultAsync(entity => entity.Id == id);

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null) =>
            await _dbSet.AsNoTracking().Where(predicate).ToListAsync();

        public async Task Remove(Guid id)
        {
            var entity = await GetById(id);

            if (entity != null)
                _dbSet.Remove(entity);
        }

        public async Task Update(Guid id, TEntity newEntity)
        {
            var entity = await GetById(id);

            if (entity != null)
                _dbSet.Update(entity);
        }

    }
}
