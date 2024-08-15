using Said_Store.Infrastructure.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Said_Store.Infrastructure.Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context) : base(context)
        {
            _context = context;
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
                .SingleOrDefaultAsync(b => b.Id == id, cancellationToken)
                ?? throw new NotFoundException(nameof(Book), id);
        }
    }
}
