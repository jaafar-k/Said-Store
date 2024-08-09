using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Shared.Abstractions.Application.Queries;
using Mapster;
using Said_Store.Domain.Entities;

namespace Said_Store.Application.Queries.OrderQueries.Handlers
{
    public class GetOrderByIdHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orders;

        public GetOrderByIdHandler(IOrderRepository orders)
        {
            _orders = orders;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orders.GetOrderWithDetailsByIdAsync(request.Id, cancellationToken);
            var setter = TypeAdapterConfig<Order, OrderDto>.NewConfig().MaxDepth(2);
            return order.Adapt<Order, OrderDto>(setter.Config);
        }
    }
}
