
namespace Said_Store.Application.DTOs
{
    public record BookDto
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public string? Year { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
