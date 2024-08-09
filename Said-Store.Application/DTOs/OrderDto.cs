﻿

namespace Said_Store.Application.DTOs
{
    public record OrderDto
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public string? ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public IReadOnlyCollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}

   