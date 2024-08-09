using Mapster;
using Said_Store.Application.DTOs;
using Said_Store.Application.Queries.OrderItemQueries;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using Said_Store.Shared.Abstractions.Application.Queries;

namespace Said_Store.Application.Queries.OrderQueries.Handlers
{
    public class GetAllOrderItemsHandler : IQueryHandler<GetAllOrderItemsQuery, List<OrderItemDto>>
    {
        private readonly IOrderItemRepository _orderItems;

        public GetAllOrderItemsHandler(IOrderItemRepository orderItems)
        {
            _orderItems = orderItems;
        }

        public async Task<List<OrderItemDto>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
        {
            var orderItems = await _orderItems.GetWholeAsync(cancellationToken);
            return orderItems.Adapt<IEnumerable<OrderItem>, IEnumerable<OrderItemDto>>().ToList();
        }
    }
}
