using Microsoft.EntityFrameworkCore;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Said_Store.Infrastructure.Data.Repositories
{
    internal class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId, CancellationToken cancellationToken)
        {
            return _context.OrderItems
                .Include(oi => oi.Book)
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync(cancellationToken);
        }

        public Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(int orderId, CancellationToken cancellationToken)
        {
            return _context.OrderItems
                 .Where(oi => oi.OrderId == orderId)
                 .Include(oi => oi.Book)  
                 .ToListAsync(cancellationToken);
        }
    }
}
