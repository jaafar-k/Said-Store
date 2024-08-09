using Microsoft.EntityFrameworkCore;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
namespace Said_Store.Infrastructure.Data.Repositories
{
    internal class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public async Task DeleteAsync(Book book, CancellationToken cancellationToken)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Book>> GetWholeAsync(CancellationToken cancellationToken)
        {
            return await _context.Books.ToListAsync(cancellationToken);
        }

        public async Task<Book> GetWholeByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Books
                .SingleOrDefaultAsync(b => b.Id == id, cancellationToken);
        }
    }
}
