using Said_Store.Application.Repositories;
using Said_Store.Application.DTOs;
using Said_Store.Shared;
using Said_Store.Shared.Abstractions.Application.Commands;
using MediatR;

namespace Said_Store.Application.Commands.BuyerCommands.Handlers
{
    internal class DeleteBuyerHandler : ICommandHandler<DeleteBuyer, Unit>
    {
        private readonly IBuyerRepository _buyerRepository;

        public DeleteBuyerHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<Response<Unit>> Handle(DeleteBuyer request, CancellationToken cancellationToken)
        {
            var buyer = await _buyerRepository.GetByIdAsync(request.Id, cancellationToken);
            if (buyer == null)
            {
                return Response.Error<Unit>("Buyer not found");
            }

            await _buyerRepository.DeleteAsync(request.Id, cancellationToken);

            return Response.Success(Unit.Value, "Buyer deleted successfully.");
        }
    }
}
