using System;

using Mapster;

using MediatR;

using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;

namespace Said_Store.Application.Commands.BookCommands.Handlers
{
    internal class CreateBookHandler : IRequestHandler<CreateBook, BookDto>
    {
        private readonly IBookRepository _books;

        public CreateBookHandler(IBookRepository books)
        {
            _books = books;
        }

        public async Task<BookDto> Handle(CreateBook request, CancellationToken cancellationToken)
        {
            var (title, author, genre, year, price, description) = request;

            var book = new Book(title, author, genre, year, price, description);

            book = await _books.AddAsync(book, cancellationToken);
            
            return book.Adapt<BookDto>();
        }
    }
}
