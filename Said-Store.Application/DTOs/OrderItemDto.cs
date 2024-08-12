namespace Said_Store.Application.DTOs
{
    public record OrderItemDto
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public string? Title { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Quantity * Price;
    }
}
