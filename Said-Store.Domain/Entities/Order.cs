using System;
using System.Collections.Generic;

namespace Said_Store.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public int BuyerId { get; private set; }
        public Buyer Buyer { get; private set; }
        public ICollection<OrderItem> OrderItems { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal TotalAmount { get; private set; }

        public Order(int buyerId)
        {
            if (buyerId <= 0) throw new ArgumentOutOfRangeException(nameof(buyerId), "BuyerId must be positive.");

            BuyerId = buyerId;
            OrderItems = new List<OrderItem>();
            OrderDate = DateTime.UtcNow;
            TotalAmount = 0m; 
        }
        public void AddOrderItem(OrderItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            OrderItems.Add(item);
            TotalAmount += item.TotalPrice;
        }
    }
}
