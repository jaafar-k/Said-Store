using MediatR;
using Microsoft.AspNetCore.Mvc;
using Said_Store.Application.Commands.OrderItemCommands;
using Said_Store.Application.DTOs;
using Said_Store.Application.Queries.OrderItemQueries;
using Said_Store.Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Said_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderItemsController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        public async Task<IEnumerable<OrderItemDto>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllOrderItemsQuery();
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<OrderItemDto> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetOrderItemByIdQuery(id);
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpPost]
        public async Task<Response<OrderItemDto>> Post(CreateOrderItem command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpPut("{id}")]
        public async Task<Response<OrderItemDto>> Put(int id, [FromBody] UpdateOrderItem command, CancellationToken cancellationToken)
        {
            command = command with { Id = id };
            return await _mediator.Send(command, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<Response<Unit>> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteOrderItem(id);
            return await _mediator.Send(command, cancellationToken);
        }
    }
}
