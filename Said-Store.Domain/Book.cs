using MathNet.Numerics;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Said_Store.Domain
{
    public class Book
    {
        public int ID { get; set; }
        [MaxLength(100)]
        public string? Title { get; set; } = "";
        [MaxLength(100)]
        public string Author { get; set; } = "";
        [MaxLength(100)]
        public string Genre { get; set; } = "";
        [MaxLength(100)]
        public string Year { get; set; } = "";
        [Precision(16, 2)]
        public decimal Price { get; set; }
        public string Description { get; set; } = "";
    }
}
