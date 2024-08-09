using Mapster;
using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using Said_Store.Shared;
using Said_Store.Shared.Abstractions.Application.Commands;

namespace Said_Store.Application.Commands.OrderCommands.Handlers
{
    internal class UpdateOrderHandler : ICommandHandler<UpdateOrder, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBookRepository _bookRepository;

        public UpdateOrderHandler(IOrderRepository orderRepository, IBookRepository bookRepository)
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Response<OrderDto>> Handle(UpdateOrder request, CancellationToken cancellationToken)
        {
            var (orderId, buyerId, orderItemsDto, totalAmount, shippingAddress) = request;

            var order = await _orderRepository.GetByIdAsync(orderId, cancellationToken);
            if (order == null) return Response.Error<OrderDto>("Order not found.");

            
            order = new Order(buyerId, new List<OrderItem>(), shippingAddress);
            foreach (var itemDto in orderItemsDto)
            {
                var book = await _bookRepository.GetByIdAsync(itemDto.BookId, cancellationToken);
                if (book == null) return Response.Error<OrderDto>($"Book with ID {itemDto.BookId} not found.");

                var orderItem = new OrderItem(
                    book.Id,
                    itemDto.Quantity,
                    book.Price
                );
                order.AddOrderItem(orderItem);
            }

            
            var calculatedTotalAmount = order.OrderItems.Sum(item => item.TotalPrice);
            if (calculatedTotalAmount != totalAmount)
                return Response.Error<OrderDto>("Total amount mismatch.");

          
            order = await _orderRepository.UpdateAsync(order, cancellationToken);

            var orderDto = order.Adapt<OrderDto>();

            return Response.Success(orderDto, "Order updated successfully.");
        }
    }
}
