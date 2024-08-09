using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Shared.Abstractions.Application.Queries;
using Mapster;
using Said_Store.Domain.Entities;

namespace Said_Store.Application.Queries.OrderQueries.Handlers
{
    public class GetOrdersByBuyerIdHandler : IQueryHandler<GetOrdersByBuyerIdQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderRepository _orders;

        public GetOrdersByBuyerIdHandler(IOrderRepository orders)
        {
            _orders = orders;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersByBuyerIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orders.GetOrdersByBuyerIdAsync(request.BuyerId, cancellationToken);
            var setter = TypeAdapterConfig<Order, OrderDto>.NewConfig().MaxDepth(2);
            return orders.Adapt<IEnumerable<Order>, IEnumerable<OrderDto>>(setter.Config);
        }
    }
}
