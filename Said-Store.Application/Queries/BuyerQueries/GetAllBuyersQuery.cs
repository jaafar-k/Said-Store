using MediatR;
using Said_Store.Application.DTOs;
using Said_Store.Shared;

namespace Said_Store.Application.Queries.BuyerQueries
{
    public record GetAllBuyers() : IRequest<Response<IEnumerable<BuyerDto>>>;
}
