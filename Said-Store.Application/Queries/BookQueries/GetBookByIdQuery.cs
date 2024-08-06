using Said_Store.Application.DTOs;
using Said_Store.Shared.Abstractions.Application.Queries;
namespace Said_Store.Application.Queries.BookQueries
{
    public record GetBookByIdQuery(int Id) : IQuery<BookDto>;
}
