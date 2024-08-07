using Mapster;

using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using Said_Store.Shared;
using Said_Store.Shared.Abstractions.Application.Commands;

namespace Said_Store.Application.Commands.BookCommands.Handlers
{
    internal class CreateBookHandler : ICommandHandler<CreateBook, BookDto>
    {
        private readonly IBookRepository _books;

        public CreateBookHandler(IBookRepository books)
        {
            _books = books;
        }

        public async Task<Response<BookDto>> Handle(CreateBook request, CancellationToken cancellationToken)
        {
            var (title, author, genre, year, price, description) = request;

            var book = new Book(title, author, genre, year, price, description);

            book = await _books.AddAsync(book, cancellationToken);
            
            return Response.Success(book.Adapt<BookDto>(), "Created " + book.Title);
        }
    }
}
