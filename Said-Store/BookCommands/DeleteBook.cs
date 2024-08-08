using Said_Store.Application.DTOs;
using Said_Store.Shared.Abstractions.Application.Commands;
using MediatR;
namespace Said_Store.Application.Commands.BookCommands
{
    public record DeleteBook(int Id) : ICommand<BookDto>;
}
