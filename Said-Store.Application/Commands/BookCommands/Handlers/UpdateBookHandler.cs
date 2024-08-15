using Mapster;
using Said_Store.Shared.Abstractions.Application.Commands;
using Said_Store.Shared;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using Said_Store.Application.DTOs;

namespace Said_Store.Application.Commands.BookCommands.Handlers
{
    internal class UpdateBookHandler : ICommandHandler<UpdateBook, BookDto>
    {
        private readonly IBookRepository _books;

        public UpdateBookHandler(IBookRepository books)
        {
            _books = books;
        }

        public async Task<Response<BookDto>> Handle(UpdateBook request, CancellationToken cancellationToken)
        {
            var(id,title, author, genre, year, price, description) = request;

            var book = await _books.GetByIdAsync(id, cancellationToken);

            if (book == null)
            {
                return Response.Error<BookDto>("Book not found");
            }

            book.UpdateDetails(title, author, genre, year, price, description);

            await _books.UpdateAsync(book, cancellationToken);

            return Response.Success(book.Adapt<BookDto>(), "Updated " + book.Title);
        }
    }
}