using Mapster;
using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using Said_Store.Shared;
using Said_Store.Shared.Abstractions.Application.Queries;

namespace Said_Store.Application.Queries.BuyerQueries.Handlers
{
    public class GetAllBuyersHandler : IQueryHandler<GetAllBuyersQuery, List<BuyerDto>>
    {
        private readonly IBuyerRepository _buyers;

        public GetAllBuyersHandler(IBuyerRepository buyers)
        {
            _buyers = buyers;
        }

        public async Task<List<BuyerDto>> Handle(GetAllBuyersQuery request, CancellationToken cancellationToken)
        {
            var buyers  = await _buyers.GetWholeAsync(cancellationToken);
            return buyers.Adapt<IEnumerable<Buyer>, IEnumerable<BuyerDto>>().ToList();
        }
    }
}
