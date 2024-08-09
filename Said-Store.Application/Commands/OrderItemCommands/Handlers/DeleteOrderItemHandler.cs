using Said_Store.Application.Repositories;
using Said_Store.Application.DTOs;
using Said_Store.Shared;
using Said_Store.Shared.Abstractions.Application.Commands;
using MediatR;

namespace Said_Store.Application.Commands.OrderItemCommands.Handlers
{
    internal class DeleteOrderItemHandler : ICommandHandler<DeleteOrderItem, OrderItemDto>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public DeleteOrderItemHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<Response<OrderItemDto>> Handle(DeleteOrderItem request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(request.Id, cancellationToken);
            if (orderItem == null)
            {
                return Response.Error<OrderItemDto>("Order item not found.");
            }

            await _orderItemRepository.DeleteAsync(request.Id, cancellationToken);

            return Response.Success<OrderItemDto>(null, "Order item deleted successfully.");
        }
    }
}
