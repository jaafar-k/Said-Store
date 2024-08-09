using MediatR;
using Said_Store.Application.DTOs;
using Said_Store.Shared;

namespace Said_Store.Application.Queries.OrderQueries
{
    public record GetOrdersByBuyerId(int BuyerId) : IRequest<Response<IEnumerable<OrderDto>>>;
}
