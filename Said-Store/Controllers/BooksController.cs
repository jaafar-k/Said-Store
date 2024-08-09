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

        [HttpPost]
        public async Task<ActionResult<Response<BookDto>>> Post(CreateBook command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);
            if (response.Error)
            {
                return BadRequest(new { message = response.Message });
            }

            return CreatedAtAction(nameof(Get), new { id = response.Data.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<BookDto>>> Get(int id, CancellationToken cancellationToken)
        {
            var query = new GetBookByIdQuery(id);
            var response = await _mediator.Send(query, cancellationToken);
            if (response.Error)
            {
                return NotFound(new { message = response.Message });
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<BookDto>>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllBooksQuery();
            var response = await _mediator.Send(query, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<BookDto>>> Put(int id, UpdateBook command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest(new { message = "Id mismatch" });
            }

            var response = await _mediator.Send(command, cancellationToken);
            if (response.Error)
            {
                return NotFound(new { message = response.Message });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<BookDto>>> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteBook(id);
            var response = await _mediator.Send(command, cancellationToken);
            if (response.Error)
            {
                return NotFound(new { message = response.Message });
            }

            return NoContent();
        }
    }
}
