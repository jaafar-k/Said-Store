using Said_Store.Infrastructure.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;

namespace Said_Store.Infrastructure.Data.Repositories
{
    public class BuyerRepository : BaseRepository<Buyer>, IBuyerRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Buyer> _buyers;

        public BuyerRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _buyers = _context.Set<Buyer>();
        }

        public async Task<Buyer> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _buyers.FirstOrDefaultAsync(b => b.Email == email, cancellationToken)
                ?? throw new NotFoundException(nameof(Buyer), email);
        }

        public async Task<IEnumerable<Buyer>> GetAllAsync(CancellationToken cancellationToken)
            => await _buyers.ToListAsync(cancellationToken);

        public async Task<Buyer> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _buyers.FirstOrDefaultAsync(b => b.Id == id, cancellationToken)
                ?? throw new NotFoundException(nameof(Buyer), id);

        public async Task<Buyer> GetWholeByIdAsync(int id, CancellationToken cancellationToken)
            => await _buyers.Include(b => b.Orders) 
                            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken)
                ?? throw new NotFoundException(nameof(Buyer), id);


        public async Task<IEnumerable<Buyer>> GetWholeAsync(CancellationToken cancellationToken)
        
             => await _buyers.Include(b => b.Orders)
                            .ToListAsync(cancellationToken);
        
    }
}
