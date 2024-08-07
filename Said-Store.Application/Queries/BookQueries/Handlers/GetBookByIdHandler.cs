using Said_Store.Application.DTOs;
using Said_Store.Application.Repositories;
using Said_Store.Shared.Abstractions.Application.Queries;

using Mapster;
using Said_Store.Domain.Entities;

namespace Said_Store.Application.Queries.BookQueries.Handlers
{
    internal class GetBookByIdHandler : IQueryHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IBookRepository _books;

        public GetBookByIdHandler(IBookRepository books)
        {
            _books = books;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _books.GetWholeByIdAsync(request.Id, cancellationToken);
            var setter = TypeAdapterConfig<Book, BookDto>.NewConfig()
                .Map(dest => dest.TagIds, src => src.Tags.Select(t => t.Id)).MaxDepth(2);
            return book.Adapt<Book, BookDto>(setter.Config);
        }
    }
}