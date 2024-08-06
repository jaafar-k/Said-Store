using System;
using Said_Store.Application.DTOs;
using Said_Store.Shared.Abstractions.Application.Commands;
using MediatR;
namespace Said_Store.Application.BookCommands
{
    public record CreateBook(
        string Title,
        string Author,
        string Genre,
        string Year,
        decimal Price,
        string Description
    ) : ICommand<BookDto>;
}
