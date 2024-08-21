using Mapster;
using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using Said_Store.Shared;
using Said_Store.Shared.Abstractions.Application.Commands;

namespace Said_Store.Application.Commands.OrderCommands.Handlers
{
    internal class CreateOrderHandler : ICommandHandler<CreateOrder, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBookRepository _bookRepository;

        public CreateOrderHandler(IOrderRepository orderRepository, IBookRepository bookRepository)
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Response<OrderDto>> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            var (buyerId, orderItemsDto, totalAmount, shippingAddress) = request;

            if (buyerId <= 0) return Response.Error<OrderDto>("Invalid Buyer ID.");
            if (orderItemsDto == null || !orderItemsDto.Any()) return Response.Error<OrderDto>("Order must have at least one item.");

            var orderItems = new List<OrderItem>();
            decimal calculatedTotalAmount = 0;

            foreach (var itemDto in orderItemsDto)
            {
                var book = await _bookRepository.GetByIdAsync(itemDto.BookId, cancellationToken);
                if (book == null) return Response.Error<OrderDto>($"Book with ID {itemDto.BookId} not found.");

                var orderItem = new OrderItem(
                    book.Id,
                    itemDto.Quantity,
                    book.Price
                )
                {
                    Title = book.Title 
                };
                orderItems.Add(orderItem);
                calculatedTotalAmount += orderItem.TotalPrice;
            }

            if (calculatedTotalAmount != totalAmount)
                return Response.Error<OrderDto>("Total amount mismatch.");

            var order = new Order(buyerId, orderItems, shippingAddress);

            order = await _orderRepository.AddAsync(order, cancellationToken);

            var orderDto = order.Adapt<OrderDto>();

            return Response.Success(orderDto, "Order created successfully.");
        }
    }
}
