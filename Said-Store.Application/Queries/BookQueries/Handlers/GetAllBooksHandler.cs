using System;
using Said_Store.Application.DTOs;
using Said_Store.Shared.Abstractions.Application.Queries;
using Said_Store.Application.Repositories;
using Mapster;
using Said_Store.Domain.Entities;
namespace Said_Store.Application.Queries.BookQueries.Handlers
{
    internal class GetAllBooksHandler : IQueryHandler<GetAllBooksQuery, List<BookDto>>
    {
        private readonly IBookRepository _books;

        public GetAllBooksHandler(IBookRepository books)
        {
            _books = books;
        }

        public async Task<List<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _books.GetWholeAsync(cancellationToken);

            var setter = TypeAdapterConfig<Book, BookDto>.NewConfig()
                .MaxDepth(2);
            var booksDTO = books.Adapt<IEnumerable<Book>, IEnumerable<BookDto>>(setter.Config);

            return booksDTO.ToList();
        }
    }
}