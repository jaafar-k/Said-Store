using MediatR;
using Microsoft.AspNetCore.Mvc;
using Said_Store.Application.Commands.BookCommands;
using Said_Store.Application.DTOs;
using Said_Store.Application.Queries.BookQueries;
using Said_Store.Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Said_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllBooksQuery();
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<BookDto> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetBookByIdQuery(id);
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpPost]
        public async Task<Response<BookDto>> Post(CreateBook command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpPut("{id}")]
        public async Task<Response<BookDto>> Put(int id, [FromBody] UpdateBook command, CancellationToken cancellationToken)
        {
            command = command with { Id = id };
            return await _mediator.Send(command, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<Response<BookDto>> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteBook(id);
            return await _mediator.Send(command, cancellationToken);
        }
    }
}
