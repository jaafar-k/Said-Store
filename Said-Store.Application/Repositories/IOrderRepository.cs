using Said_Store.Domain.Entities;

namespace Said_Store.Application.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
         Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken);
         Task<IEnumerable<Order>> GetOrdersByBuyerIdAsync(int buyerId, CancellationToken cancellationToken);
        Task<Order> GetOrderWithDetailsByIdAsync(int id, CancellationToken cancellationToken);
        public Task<IEnumerable<Order>> GetWholeAsync(CancellationToken cancellationToken);
        public Task<Order> GetWholeByIdAsync(int id, CancellationToken cancellationToken);
    }
}
