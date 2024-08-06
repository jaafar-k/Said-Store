using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Said_Store.Application.DTOs;
using Said_Store.Shared.Abstractions.Application.Queries;

namespace Said_Store.Application.Queries.BookQueries
{
    public record GetAllBooksQuery() : IQuery<List<BookDto>>;
}
