using MediatR;

namespace Said_Store.Shared.Abstractions.Application.Commands
{
    public interface ICommand<T> : IRequest<Response<T>> { }
}
