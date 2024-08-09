using Mapster;
using MediatR;
using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Shared;

namespace Said_Store.Application.Queries.BuyerQueries.Handlers
{
    internal class GetAllBuyersHandler : IRequestHandler<GetAllBuyers, Response<IEnumerable<BuyerDto>>>
    {
        private readonly IBuyerRepository _buyerRepository;

        public GetAllBuyersHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<Response<IEnumerable<BuyerDto>>> Handle(GetAllBuyers request, CancellationToken cancellationToken)
        {
            var buyers = await _buyerRepository.GetAllAsync(cancellationToken);
            var buyerDtos = buyers.Adapt<IEnumerable<BuyerDto>>();
            return Response.Success(buyerDtos, "Buyers retrieved successfully.");
        }
    }
}
