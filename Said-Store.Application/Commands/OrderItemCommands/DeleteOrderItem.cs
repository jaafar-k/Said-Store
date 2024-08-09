using MediatR;
using Said_Store.Application.DTOs;
using Said_Store.Shared.Abstractions.Application.Commands;

namespace Said_Store.Application.Commands.OrderItemCommands
{
    public record DeleteOrderItem(int Id) : ICommand<OrderItemDto>;
}
