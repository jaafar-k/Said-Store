using System;
using System.Collections.Generic;
using System.Linq;

namespace Said_Store.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public int BuyerId { get; private set; }
        public Buyer Buyer { get; private set; }
        public ICollection<OrderItem> OrderItems { get; private set; }
        public string? ShippingAddress { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal TotalAmount { get; private set; }

        public Order(int buyerId, List<OrderItem> orderItems, string shippingAddress)
        {
            if (buyerId <= 0) throw new ArgumentOutOfRangeException(nameof(buyerId), "BuyerId must be positive.");
            if (orderItems == null || !orderItems.Any()) throw new ArgumentException("Order must have at least one item.", nameof(orderItems));
            if (string.IsNullOrWhiteSpace(shippingAddress)) throw new ArgumentException("Shipping address must be provided.", nameof(shippingAddress));

            BuyerId = buyerId;
            OrderItems = new List<OrderItem>(orderItems);
            ShippingAddress = shippingAddress;
            OrderDate = DateTime.UtcNow;
            TotalAmount = orderItems.Sum(item => item.TotalPrice);
        }

        public void AddOrderItem(OrderItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            OrderItems.Add(item);
            TotalAmount += item.TotalPrice;
        }

        public void RemoveOrderItem(OrderItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (OrderItems.Remove(item))
            {
                TotalAmount -= item.TotalPrice;
            }
        }
    }
}
