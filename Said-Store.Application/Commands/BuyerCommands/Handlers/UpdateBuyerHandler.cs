using Mapster;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using Said_Store.Application.DTOs;
using Said_Store.Shared;
using Said_Store.Shared.Abstractions.Application.Commands;

namespace Said_Store.Application.Commands.BuyerCommands.Handlers
{
    internal class UpdateBuyerHandler : ICommandHandler<UpdateBuyer, BuyerDto>
    {
        private readonly IBuyerRepository _buyerRepository;

        public UpdateBuyerHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<Response<BuyerDto>> Handle(UpdateBuyer request, CancellationToken cancellationToken)
        {
            var (id, name, email, address) = request;

            var buyer = await _buyerRepository.GetByIdAsync(id, cancellationToken);
            if (buyer == null)
            {
                return Response.Error<BuyerDto>("Buyer not found");
            }

            buyer.UpdateDetails(name, email, address);

            buyer = await _buyerRepository.UpdateAsync(buyer, cancellationToken);

            var buyerDto = buyer.Adapt<BuyerDto>();

            return Response.Success(buyerDto, "Buyer updated successfully.");
        }
    }
}
