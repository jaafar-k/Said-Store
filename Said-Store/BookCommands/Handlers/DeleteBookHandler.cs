using Mapster;
using Said_Store.Shared.Abstractions.Application.Commands;
using Said_Store.Shared;
using Said_Store.Application.Repositories;
using Said_Store.Domain.Entities;
using Said_Store.Application.DTOs;
using MediatR;

namespace Said_Store.Application.Commands.BookCommands.Handlers
{
    internal class DeleteBookHandler : ICommandHandler<DeleteBook, BookDto>
    {
        private readonly IBookRepository _books;

        public DeleteBookHandler(IBookRepository books)
        {
            _books = books;
        }

        public async Task<Response<BookDto>> Handle(DeleteBook request, CancellationToken cancellationToken)
        {
            var book = await _books.GetByIdAsync(request.Id, cancellationToken);
            if (book == null)
            {
                return Response.Error<BookDto>("Book not found");
            }

            await _books.DeleteAsync(book, cancellationToken);

            return Response.Success<BookDto>(null, "Deleted " + book.Title);
        }
    }
}