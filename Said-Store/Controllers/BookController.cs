using Said_Store.Application.BookCommands;
using Said_Store.Application.DTOs;
using Said_Store.Application.Queries.BookQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Said_Store.Shared;

namespace CleanApiSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        public async Task<List<BookDto>> Get([FromQuery] GetAllBooksQuery query, CancellationToken cancellationToken)
            => await _mediator.Send(query, cancellationToken);

        [HttpGet("byId")]
        public async Task<BookDto> Get([FromQuery] GetBookByIdQuery query, CancellationToken cancellationToken)
            => await _mediator.Send(query, cancellationToken);

        [HttpPost]
        public async Task<Response<BookDto>> Post(CreateBook command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpPut]
        public async Task<Response<BookDto>> Put(UpdateBook command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpDelete]
        public async Task Delete(DeleteBook command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);
    }
}