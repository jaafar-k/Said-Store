using CleanApiSample.Infrastructure.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Said_Store.Infrastructure.Data.Repositories
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersByBuyerIdAsync(int buyerId, CancellationToken cancellationToken)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Book)
                .Where(o => o.BuyerId == buyerId)
                .ToListAsync(cancellationToken);
        }

        public async Task<Order> GetOrderWithDetailsByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Book)
                .Include(o => o.Buyer)
                .SingleOrDefaultAsync(o => o.Id == id, cancellationToken)
                ?? throw new NotFoundException(nameof(Order), id);
        }

        public async Task<Order> GetOrderByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Orders
                .SingleOrDefaultAsync(o => o.Id == id, cancellationToken)
                ?? throw new NotFoundException(nameof(Order), id);
        }

        public async Task<IEnumerable<Order>> GetWholeAsync(CancellationToken cancellationToken)
        {
            return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Book)
            .Include(o => o.Buyer)
            .ToListAsync(cancellationToken);
        }

        public async Task<Order> GetWholeByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Orders
                   .Include(o => o.OrderItems)
                   .ThenInclude(oi => oi.Book)
                   .Include(o => o.Buyer)
                   .SingleOrDefaultAsync(o => o.Id == id, cancellationToken)
                   ?? throw new NotFoundException(nameof(Order), id);
        }
    }
}
