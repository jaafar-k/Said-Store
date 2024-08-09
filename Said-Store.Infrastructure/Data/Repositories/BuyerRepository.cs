using Microsoft.EntityFrameworkCore;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Said_Store.Infrastructure.Data.Repositories
{
    internal class BuyerRepository : BaseRepository<Buyer>, IBuyerRepository
    {
        public BuyerRepository(AppDbContext context) : base(context)
        {
        }
        public Task<Buyer> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return _context.Buyers
                .FirstOrDefaultAsync(b => b.Email == email, cancellationToken);
        }

    }
}
