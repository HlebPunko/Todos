using Microsoft.EntityFrameworkCore;
using Todos.Domain.Entities;
using Todos.Infastructure.Context;
using Todos.Infastructure.Repositories.Interfaces;

namespace Todos.Infastructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected TodosDbContext _context;

        public BaseRepository(TodosDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity model, CancellationToken cancellationToken)
        {
            var res = await _context.Set<TEntity>().AddAsync(model, cancellationToken);

            return res.Entity;
        }

        public virtual async Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _context.Set<TEntity>().Remove(entity);

            return entity.Id;
        }

        public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken)!;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity model, CancellationToken cancellationToken)
        {
            var res = _context.Set<TEntity>().Update(model);

            return res.Entity;
        }
    }
}
