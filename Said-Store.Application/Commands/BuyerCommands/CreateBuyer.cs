using Said_Store.Application.DTOs;
using Said_Store.Shared.Abstractions.Application.Commands;

namespace Said_Store.Application.Commands.BuyerCommands
{
    public record CreateBuyer(
        string Name,
        string Email,
        string Address
    ) : ICommand<BuyerDto>;
}

