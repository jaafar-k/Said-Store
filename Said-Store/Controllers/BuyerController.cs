using MediatR;
using Microsoft.AspNetCore.Mvc;
using Said_Store.Application.Commands.BuyerCommands;
using Said_Store.Application.DTOs;
using Said_Store.Application.Queries.BuyerQueries;
using Said_Store.Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Said_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BuyersController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        public async Task<IEnumerable<BuyerDto>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllBuyersQuery();
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<BuyerDto> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetBuyerByIdQuery(id);
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpPost]
        public async Task<Response<BuyerDto>> Post(CreateBuyer command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpPut("{id}")]
        public async Task<Response<BuyerDto>> Put(int id, [FromBody] UpdateBuyer command, CancellationToken cancellationToken)
        {
            command = command with { Id = id };
            return await _mediator.Send(command, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<Response<Unit>> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteBuyer(id);
            return await _mediator.Send(command, cancellationToken);
        }
    }
}
