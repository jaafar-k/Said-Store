using Mapster;
using Said_Store.Shared.Abstractions.Application.Commands;
using Said_Store.Shared;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using Said_Store.Application.DTOs;
using MediatR;

namespace Said_Store.Application.Commands.OrderCommands.Handlers
{
    internal class DeleteOrderHandler : ICommandHandler<DeleteOrder, Unit>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Response<Unit>> Handle(DeleteOrder request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
            if (order == null)
            {
                return Response.Error<Unit>("Order not found");
            }

            await _orderRepository.DeleteAsync(request.Id, cancellationToken);

            return Response.Success(Unit.Value, "Order deleted successfully"); 
        }
    }
}
