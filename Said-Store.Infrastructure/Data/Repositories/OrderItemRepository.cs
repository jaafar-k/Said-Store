using Microsoft.EntityFrameworkCore;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Said_Store.Infrastructure.Data.Repositories
{
    internal class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        private readonly AppDbContext _context;

        public OrderItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId, CancellationToken cancellationToken)
        {
            return await _context.OrderItems
                .Include(oi => oi.Book)
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(int orderId, CancellationToken cancellationToken)
        {
            return await _context.OrderItems
                .Include(oi => oi.Book)
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<OrderItem>> GetWholeAsync(CancellationToken cancellationToken)
        {
            return await _context.OrderItems
                     .Include(oi => oi.Book)
                     .ToListAsync(cancellationToken);
        }
    }
}
