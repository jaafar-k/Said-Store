using MediatR;

using Said_Store.Application.DTOs;

namespace Said_Store.Application.Commands.BookCommands
{
    public record CreateBook(
        string? Title,
        string? Author,
        string? Genre,
        string? Year,
        decimal Price,
        string? Description) : IRequest<BookDto>;
}
