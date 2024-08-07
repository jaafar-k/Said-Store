using Said_Store.Domain.Entities;

using SaidStore.Application.Repositories;

namespace Said_Store.Application.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        public Task<IEnumerable<Book>> GetWholeAsync(CancellationToken cancellationToken);
        public Task<Book> GetWholeByIdAsync(int id, CancellationToken cancellationToken);
    }
}