using Mapster;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using Said_Store.Application.DTOs;
using Said_Store.Shared;
using Said_Store.Shared.Abstractions.Application.Commands;

namespace Said_Store.Application.Commands.OrderItemCommands.Handlers
{
    internal class UpdateOrderItemHandler : ICommandHandler<UpdateOrderItem, OrderItemDto>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IBookRepository _bookRepository;

        public UpdateOrderItemHandler(IOrderItemRepository orderItemRepository, IBookRepository bookRepository)
        {
            _orderItemRepository = orderItemRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Response<OrderItemDto>> Handle(UpdateOrderItem request, CancellationToken cancellationToken)
        {
            var (id, orderId, bookId, quantity, price) = request;

            var orderItem = await _orderItemRepository.GetByIdAsync(id, cancellationToken);
            if (orderItem == null)
            {
                return Response.Error<OrderItemDto>("Order item not found.");
            }

            var book = await _bookRepository.GetByIdAsync(bookId, cancellationToken);
            if (book == null)
            {
                return Response.Error<OrderItemDto>($"Book with ID {bookId} not found.");
            }

            orderItem = new OrderItem(bookId, quantity, price)
            {
                Id = id,
                OrderId = orderId
            };

            orderItem = await _orderItemRepository.UpdateAsync(orderItem, cancellationToken);

            var orderItemDto = orderItem.Adapt<OrderItemDto>();

            return Response.Success(orderItemDto, "Order item updated successfully.");
        }
    }
}
