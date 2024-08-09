using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Shared.Abstractions.Application.Queries;
using Mapster;
using Said_Store.Domain.Entities;

namespace Said_Store.Application.Queries.OrderItemQueries.Handlers
{
    public class GetOrderItemsByOrderIdHandler : IQueryHandler<GetOrderItemsByOrderIdQuery, IEnumerable<OrderItemDto>>
    {
        private readonly IOrderItemRepository _orderItems;

        public GetOrderItemsByOrderIdHandler(IOrderItemRepository orderItems)
        {
            _orderItems = orderItems;
        }

        public async Task<IEnumerable<OrderItemDto>> Handle(GetOrderItemsByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var orderItems = await _orderItems.GetItemsByOrderIdAsync(request.OrderId, cancellationToken);
            var setter = TypeAdapterConfig<OrderItem, OrderItemDto>.NewConfig().MaxDepth(2);
            return orderItems.Adapt<IEnumerable<OrderItem>, IEnumerable<OrderItemDto>>(setter.Config);
        }
    }
}
