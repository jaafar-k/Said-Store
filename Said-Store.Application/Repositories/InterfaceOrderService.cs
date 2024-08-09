using Said_Store.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Said_Store.Application.Repositories
{
    internal interface InterfaceOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task<Order> AddOrderAsync(Order order);
        Task<Order?> UpdateOrderAsync(int id, Order order);
        Task<bool> DeleteOrderAsync(int id);
        Task<IEnumerable<Order>> GetOrdersByBuyerIdAsync(int buyerId);
    }
}
