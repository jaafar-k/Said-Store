using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;

namespace Said_Store.Infrastructure.Data.Repositories
{
    internal class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Book>> GetWholeAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetWholeByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
