using MediatR;
using Microsoft.AspNetCore.Mvc;
using Said_Store.Application.Commands.OrderCommands;
using Said_Store.Application.DTOs;
using Said_Store.Application.Queries.OrderItemQueries;
using Said_Store.Application.Queries.OrderQueries;
using Said_Store.Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Said_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        public async Task<Response<IEnumerable<OrderDto>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllOrdersQuery();
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<Response<OrderDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetOrderByIdQuery(id);
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpPost]
        public async Task<Response<OrderDto>> Post(CreateOrder command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpPut("{id}")]
        public async Task<Response<OrderDto>> Put(int id, [FromBody] UpdateOrder command, CancellationToken cancellationToken)
        {
            command = command with { OrderId = id };
            return await _mediator.Send(command, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<Response<OrderDto>> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteOrder(id);
            return await _mediator.Send(command, cancellationToken);
        }
    }
}
