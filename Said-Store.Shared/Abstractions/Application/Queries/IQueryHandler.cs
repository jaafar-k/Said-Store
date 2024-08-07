using MediatR;

namespace Said_Store.Shared.Abstractions.Application.Queries
{
    public interface IQueryHandler<TIn, TOut> : IRequestHandler<TIn, TOut>
            where TIn : IQuery<TOut>
    { }
}
