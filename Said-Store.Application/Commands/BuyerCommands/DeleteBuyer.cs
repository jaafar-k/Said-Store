using MediatR;
using Said_Store.Application.DTOs;
using Said_Store.Shared.Abstractions.Application.Commands;

namespace Said_Store.Application.Commands.BuyerCommands
{
    public record DeleteBuyer(int Id) : ICommand<BuyerDto>;
}
