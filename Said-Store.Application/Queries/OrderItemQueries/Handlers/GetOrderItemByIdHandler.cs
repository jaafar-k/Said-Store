using Mapster;
using MediatR;
using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Said_Store.Application.Queries.OrderItemQueries.Handlers
{
    internal class GetOrderItemByIdHandler : IRequestHandler<GetOrderItemById, Response<OrderItemDto>>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public GetOrderItemByIdHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<Response<OrderItemDto>> Handle(GetOrderItemById request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(request.Id, cancellationToken);
            if (orderItem == null)
            {
                return Response.Error<OrderItemDto>("Order Item not found.");
            }

            var orderItemDto = orderItem.Adapt<OrderItemDto>();
            return Response.Success(orderItemDto, "Order Item retrieved successfully.");
        }
    }
}
