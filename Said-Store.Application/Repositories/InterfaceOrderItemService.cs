using Said_Store.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Said_Store.Application.Repositories
{
    internal interface InterfaceOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
        Task<OrderItem?> GetOrderItemByIdAsync(int id);
        Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
        Task<OrderItem?> UpdateOrderItemAsync(int id, OrderItem orderItem);
        Task<bool> DeleteOrderItemAsync(int id);
        Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(int orderId);
    }
}