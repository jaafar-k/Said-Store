using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Shared.Abstractions.Application.Queries;
using Mapster;
using Said_Store.Domain.Entities;

namespace Said_Store.Application.Queries.BuyerQueries.Handlers
{
    public class GetBuyerByIdHandler : IQueryHandler<GetBuyerByIdQuery, BuyerDto>
    {
        private readonly IBuyerRepository _buyers;

        public GetBuyerByIdHandler(IBuyerRepository buyers)
        {
            _buyers = buyers;
        }

        public async Task<BuyerDto> Handle(GetBuyerByIdQuery request, CancellationToken cancellationToken)
        {
            var buyer = await _buyers.GetWholeByIdAsync(request.Id, cancellationToken);
            var setter = TypeAdapterConfig<Buyer, BuyerDto>.NewConfig().MaxDepth(2);
            return buyer.Adapt<Buyer, BuyerDto>(setter.Config);
        }
    }
}
