using Mapster;
using MediatR;
using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Shared;

namespace Said_Store.Application.Queries.OrderQueries.Handlers
{
    internal class GetOrderByIdHandler : IRequestHandler<GetOrderById, Response<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Response<OrderDto>> Handle(GetOrderById request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
            if (order == null)
            {
                return Response.Error<OrderDto>("Order not found.");
            }

            var orderDto = order.Adapt<OrderDto>();
            return Response.Success(orderDto, "Order retrieved successfully.");
        }
    }
}
