using Said_Store.Application.DTOs;
using Said_Store.Shared.Abstractions.Application.Commands;
using System.Collections.Generic;

namespace Said_Store.Application.Commands.OrderCommands
{
    public record UpdateOrder(
        int Id,
        int BuyerId,
        List<OrderItemDto> OrderItems,
        decimal TotalAmount,
        string ShippingAddress
    ) : ICommand<OrderDto>;
}
