using Mapster;
using Said_Store.Application.DTOs;
using Said_Store.Application.Queries.OrderItemQueries;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using Said_Store.Shared.Abstractions.Application.Queries;

namespace Said_Store.Application.Queries.OrderQueries.Handlers
{
    public class GetAllOrdersHandler : IQueryHandler<GetAllOrdersQuery, List<OrderDto>>
        {
            private readonly IOrderRepository _orders;

            public GetAllOrdersHandler(IOrderRepository orders)
            {
                _orders = orders;
            }

            public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            {
                var orders = await _orders.GetWholeAsync(cancellationToken);
                return orders.Adapt<IEnumerable<Order>, IEnumerable<OrderDto>>().ToList();
            }
        }
    }
