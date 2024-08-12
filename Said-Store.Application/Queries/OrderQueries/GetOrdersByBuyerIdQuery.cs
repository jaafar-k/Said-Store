using MediatR;
using Said_Store.Application.DTOs;
using Said_Store.Shared;
using Said_Store.Shared.Abstractions.Application.Queries;

namespace Said_Store.Application.Queries.OrderQueries
{
    public record GetOrdersByBuyerIdQuery(int BuyerId) : IQuery<IEnumerable<OrderDto>>;
}
