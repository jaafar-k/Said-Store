using MediatR;
using Said_Store.Application.DTOs;
using Said_Store.Shared.Abstractions.Application.Commands;

namespace Said_Store.Application.Commands.OrderCommands
{
    public record DeleteOrder(int Id) : ICommand<OrderDto>;
}
