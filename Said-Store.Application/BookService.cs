using Microsoft.EntityFrameworkCore;
using Said_Store.Application.DTOs;
using Said_Store.Infrastructure;
using Said_Store.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using Said_Store.Application.Commands.BookCommands;

namespace Said_Store.Application
{
    public class BookService : InterfaceBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            return await _context.Books
                .Select(book => new BookDto
                {
                    ID = book.ID,
                    Title = book.Title,
                    Author = book.Author,
                    Genre = book.Genre,
                    Year = book.Year,
                    Price = book.Price,
                    Description = book.Description
                }).ToListAsync();
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .Where(book => book.ID == id)
                .Select(book => new BookDto
                {
                    ID = book.ID,
                    Title = book.Title,
                    Author = book.Author,
                    Genre = book.Genre,
                    Year = book.Year,
                    Price = book.Price,
                    Description = book.Description
                }).FirstOrDefaultAsync();
        }

        public async Task<BookDto> AddBookAsync(CreateBook command)
        {
            var book = new Book
            {
                Title = command.Title,
                Author = command.Author,
                Genre = command.Genre,
                Year = command.Year,
                Price = command.Price,
                Description = command.Description
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return new BookDto
            {
                ID = book.ID,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Year = book.Year,
                Price = book.Price,
                Description = book.Description
            };
        }

        public async Task<BookDto?> UpdateBookAsync(UpdateBook command)
        {
            var book = await _context.Books.FindAsync(command.ID);
            if (book == null)
            {
                return null;
            }

            book.Title = command.Title;
            book.Author = command.Author;
            book.Genre = command.Genre;
            book.Year = command.Year;
            book.Price = command.Price;
            book.Description = command.Description;

            await _context.SaveChangesAsync();

            return new BookDto
            {
                ID = book.ID,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Year = book.Year,
                Price = book.Price,
                Description = book.Description
            };
        }

        public async Task<bool> DeleteBookAsync(DeleteBook command)
        {
            var book = await _context.Books.FindAsync(command.ID);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
