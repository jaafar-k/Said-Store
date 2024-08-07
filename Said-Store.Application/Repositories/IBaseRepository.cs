using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Said_Store.Application.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
