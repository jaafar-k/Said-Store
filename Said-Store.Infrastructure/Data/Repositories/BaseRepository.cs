using Microsoft.EntityFrameworkCore;

using Said_Store.Application.Repositories;

namespace Said_Store.Infrastructure.Data.Repositories
{
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
            => await _dbSet.ToListAsync(cancellationToken);

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _dbSet.FindAsync(new object?[] { id }, cancellationToken: cancellationToken)
                ?? throw new Exception(typeof(TEntity).Name + " not found");

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var updatedEntity = _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return updatedEntity.Entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var createdEntity = await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return createdEntity.Entity;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
