using Said_Store.Application.DTOs;
using Said_Store.Shared.Abstractions.Application.Commands;

namespace Said_Store.Application.Commands.OrderItemCommands
{
    public record CreateOrderItem(
        int OrderId,
        int BookId,
        int Quantity,
        decimal Price
    ) : ICommand<OrderItemDto>;
}
