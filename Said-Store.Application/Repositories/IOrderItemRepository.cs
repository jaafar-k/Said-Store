using Said_Store.Domain.Entities;

namespace Said_Store.Application.Repositories
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(int orderId, CancellationToken cancellationToken);
        public Task<IEnumerable<OrderItem>> GetWholeAsync(CancellationToken cancellationToken);
    }
}
