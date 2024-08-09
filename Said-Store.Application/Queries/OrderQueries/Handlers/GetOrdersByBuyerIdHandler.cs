using Mapster;
using MediatR;
using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Said_Store.Application.Queries.OrderQueries.Handlers
{
    internal class GetOrdersByBuyerIdHandler : IRequestHandler<GetOrdersByBuyerId, Response<IEnumerable<OrderDto>>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByBuyerIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Response<IEnumerable<OrderDto>>> Handle(GetOrdersByBuyerId request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByBuyerIdAsync(request.BuyerId, cancellationToken);
            var orderDtos = orders.Adapt<IEnumerable<OrderDto>>();

            return Response.Success(orderDtos, "Orders retrieved successfully.");
        }
    }
}
