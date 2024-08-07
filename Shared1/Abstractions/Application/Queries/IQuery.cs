using MediatR;

namespace Said_Store.Shared.Abstractions.Application.Queries
{
    public interface IQuery<TOut> : IRequest<TOut> { }

}
