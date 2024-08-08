using System;

namespace Said_Store.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; private set; }
        public int OrderId { get; private set; }
        public Order Order { get; private set; }
        public int BookId { get; private set; }
        public Book Book { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public decimal TotalPrice => Quantity * Price;

        public OrderItem(int bookId, int quantity, decimal price)
        {
            if (bookId <= 0) throw new ArgumentOutOfRangeException(nameof(bookId), "BookId must be positive.");
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be positive.");
            if (price < 0) throw new ArgumentOutOfRangeException(nameof(price), "Price must be non-negative.");

            BookId = bookId;
            Quantity = quantity;
            Price = price;
        }
    }
}
