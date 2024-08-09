using Said_Store.Application.DTOs;
using Said_Store.Application.Commands.BuyerCommands;
using Said_Store.Application.Queries.BuyerQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Said_Store.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace CleanApiSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BuyersController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<Response<BuyerDto>> Post(CreateBuyer command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpGet("{id}")]
        public async Task<Response<BuyerDto>> Get(int id, CancellationToken cancellationToken)
        {
            var query = new GetBuyerByIdQuery(id);
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpGet]
        public async Task<Response<IEnumerable<BuyerDto>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllBuyersQuery();
            return await _mediator.Send(query, cancellationToken);
        }
    }
}
