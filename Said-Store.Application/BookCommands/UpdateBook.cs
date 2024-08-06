using Said_Store.Application.DTOs;
using Said_Store.Shared.Abstractions.Application.Commands;

namespace Said_Store.Application.BookCommands
{
    public record UpdateBook(
        int ID,
        string Title,
        string Author,
        string Genre,
        string Year,
        decimal Price,
        string Description
    ) : ICommand<BookDto>;
}
