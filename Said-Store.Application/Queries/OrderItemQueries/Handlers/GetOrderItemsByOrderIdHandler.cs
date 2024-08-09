using Mapster;
using MediatR;
using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Said_Store.Application.Queries.OrderItemQueries.Handlers
{
    internal class GetOrderItemsByOrderIdHandler : IRequestHandler<GetOrderItemsByOrderId, Response<IEnumerable<OrderItemDto>>>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public GetOrderItemsByOrderIdHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<Response<IEnumerable<OrderItemDto>>> Handle(GetOrderItemsByOrderId request, CancellationToken cancellationToken)
        {
            var orderItems = await _orderItemRepository.GetItemsByOrderIdAsync(request.OrderId, cancellationToken);
            var orderItemDtos = orderItems.Adapt<IEnumerable<OrderItemDto>>();

            return Response.Success(orderItemDtos, "Order Items retrieved successfully.");
        }
    }
}
