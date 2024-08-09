using Mapster;
using MediatR;
using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Shared;

namespace Said_Store.Application.Queries.BuyerQueries.Handlers
{
    internal class GetBuyerByIdHandler : IRequestHandler<GetBuyerById, Response<BuyerDto>>
    {
        private readonly IBuyerRepository _buyerRepository;

        public GetBuyerByIdHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<Response<BuyerDto>> Handle(GetBuyerById request, CancellationToken cancellationToken)
        {
            var buyer = await _buyerRepository.GetByIdAsync(request.Id, cancellationToken);
            if (buyer == null)
            {
                return Response.Error<BuyerDto>("Buyer not found.");
            }

            var buyerDto = buyer.Adapt<BuyerDto>();
            return Response.Success(buyerDto, "Buyer retrieved successfully.");
        }
    }
}
