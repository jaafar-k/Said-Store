using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Shared.Abstractions.Application.Queries;
using Mapster;
using Said_Store.Domain.Entities;

namespace Said_Store.Application.Queries.OrderItemQueries.Handlers
{
    public class GetOrderItemByIdHandler : IQueryHandler<GetOrderItemByIdQuery, OrderItemDto>
    {
        private readonly IOrderItemRepository _orderItems;

        public GetOrderItemByIdHandler(IOrderItemRepository orderItems)
        {
            _orderItems = orderItems;
        }

        public async Task<OrderItemDto> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItems.GetByIdAsync(request.Id, cancellationToken);
            var setter = TypeAdapterConfig<OrderItem, OrderItemDto>.NewConfig().MaxDepth(2);
            return orderItem.Adapt<OrderItem, OrderItemDto>(setter.Config);
        }
    }
}
