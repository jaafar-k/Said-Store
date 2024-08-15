using MathNet.Numerics;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Said_Store.Domain.Entities
{
    public class Book
    {
        public int Id { get; private set; }
        public string? Title { get; private set; }
        public string? Author { get; private set; }
        public string? Genre { get; private set; }
        public int Year { get; private set; }
        public decimal Price { get; private set; }
        public string? Description { get; private set; }

        public Book(string? title, string? author, string? genre, int year, decimal price, string? description)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
            Price = price < 0 ? throw new ArgumentOutOfRangeException() : price;
            Description = description;
        }
        public Book(int id, string? title, string? author, string? genre, int year, decimal price, string? description)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
            Price = price < 0 ? throw new ArgumentOutOfRangeException() : price;
            Description = description;
        }

        public void UpdateDetails(string? title, string? author, string? genre, int year, decimal price, string? description)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
            Price = price < 0 ? throw new ArgumentOutOfRangeException() : price;
            Description = description;
        }
    }
}
