using Said_Store.Application.DTOs;
using Said_Store.Application.Commands.OrderItemCommands;
using Said_Store.Application.Queries.OrderItemQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Said_Store.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace CleanApiSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderItemsController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<Response<OrderItemDto>> Post(CreateOrderItem command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpGet("{id}")]
        public async Task<Response<OrderItemDto>> Get(int id, CancellationToken cancellationToken)
        {
            var query = new GetOrderItemByIdQuery(id);
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpGet]
        public async Task<Response<IEnumerable<OrderItemDto>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllOrderItemsQuery();
            return await _mediator.Send(query, cancellationToken);
        }
    }
}
