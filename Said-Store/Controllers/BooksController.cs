using Said_Store.Application.DTOs;
using Said_Store.Application.Queries.BookQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Said_Store.Shared;
using Said_Store.Application.Commands.BookCommands;

namespace CleanApiSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
            => _mediator = mediator;

        
        [HttpPost]
        public async Task<BookDto> Post(CreateBook command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);
    }
}