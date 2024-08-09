using Mapster;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using Said_Store.Application.DTOs;
using Said_Store.Shared;
using Said_Store.Shared.Abstractions.Application.Commands;

namespace Said_Store.Application.Commands.BuyerCommands.Handlers
{
    internal class CreateBuyerHandler : ICommandHandler<CreateBuyer, BuyerDto>
    {
        private readonly IBuyerRepository _buyerRepository;

        public CreateBuyerHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<Response<BuyerDto>> Handle(CreateBuyer request, CancellationToken cancellationToken)
        {
            var (name, email, address) = request;

            var buyer = new Buyer(name, email, address);

            buyer = await _buyerRepository.AddAsync(buyer, cancellationToken);

            var buyerDto = buyer.Adapt<BuyerDto>();

            return Response.Success(buyerDto, "Buyer created successfully.");
        }
    }
}
