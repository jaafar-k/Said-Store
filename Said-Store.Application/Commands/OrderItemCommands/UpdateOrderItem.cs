using Said_Store.Application.DTOs;
using Said_Store.Shared.Abstractions.Application.Commands;

namespace Said_Store.Application.Commands.OrderItemCommands
{
    public record UpdateOrderItem(
        int Id,
        int OrderId,
        int BookId,
        int Quantity,
        decimal Price
    ) : ICommand<OrderItemDto>;
}
