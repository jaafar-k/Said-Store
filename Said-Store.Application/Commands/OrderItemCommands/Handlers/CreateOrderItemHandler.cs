using Mapster;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using Said_Store.Application.DTOs;
using Said_Store.Shared;
using Said_Store.Shared.Abstractions.Application.Commands;

namespace Said_Store.Application.Commands.OrderItemCommands.Handlers
{
    internal class CreateOrderItemHandler : ICommandHandler<CreateOrderItem, OrderItemDto>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IBookRepository _bookRepository;

        public CreateOrderItemHandler(IOrderItemRepository orderItemRepository, IBookRepository bookRepository)
        {
            _orderItemRepository = orderItemRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Response<OrderItemDto>> Handle(CreateOrderItem request, CancellationToken cancellationToken)
        {
            var (orderId, bookId, quantity, price) = request;

            var book = await _bookRepository.GetByIdAsync(bookId, cancellationToken);
            if (book == null)
            {
                return Response.Error<OrderItemDto>($"Book with ID {bookId} not found.");
            }

            var orderItem = new OrderItem(bookId, quantity, price);

            orderItem = await _orderItemRepository.AddAsync(orderItem, cancellationToken);

            var orderItemDto = orderItem.Adapt<OrderItemDto>();

            return Response.Success(orderItemDto, "Order item created successfully.");
        }
    }
}
