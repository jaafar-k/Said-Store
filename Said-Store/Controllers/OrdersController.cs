using MediatR;
using Microsoft.AspNetCore.Mvc;
using Said_Store.Application.Commands.OrderCommands;
using Said_Store.Application.DTOs;
using Said_Store.Shared;

namespace Said_Store.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<Response<OrderDto>> Post(CreateOrder command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetOrderById(id);
            var result = await _mediator.Send(query, cancellationToken);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllOrders();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDto>> Put(int id, [FromBody] UpdateOrder command, CancellationToken cancellationToken)
        {
            command = command with { Id = id };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteOrder(id);
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
