using Microsoft.EntityFrameworkCore;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Said_Store.Infrastructure.Data.Repositories
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Order>> GetByBuyerIdAsync(int buyerId, CancellationToken cancellationToken)
        {
            return _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Book)
                .Where(o => o.BuyerId == buyerId)
                .ToListAsync(cancellationToken);
        }

        public Task<IEnumerable<Order>> GetOrdersByBuyerIdAsync(int buyerId, CancellationToken cancellationToken)
        {
            return _context.Orders
                .Where(o => o.BuyerId == buyerId)
                .ToListAsync(cancellationToken);
        }

        public Task<Order> GetOrderWithDetailsByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _context.Orders
              .Include(o => o.OrderItems)
              .ThenInclude(oi => oi.Book) 
              .Include(o => o.Buyer)      
              .SingleOrDefaultAsync(o => o.Id == id, cancellationToken);
        }
    }
}
