using MediatR;
using Said_Store.Application.DTOs;
using Said_Store.Shared;

namespace Said_Store.Application.Queries.OrderItemQueries
{
    public record GetOrderItemsByOrderId(int OrderId) : IRequest<Response<IEnumerable<OrderItemDto>>>;
}
