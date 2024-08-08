using Said_Store.Domain.Entities;

namespace Said_Store.Application.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task DeleteAsync(Book book, CancellationToken cancellationToken);
        public Task<IEnumerable<Book>> GetWholeAsync(CancellationToken cancellationToken);
        public Task<Book> GetWholeByIdAsync(int id, CancellationToken cancellationToken);
    }
}