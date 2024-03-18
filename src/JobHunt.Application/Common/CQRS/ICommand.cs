using MediatR;

namespace JobHunt.Application.Common.CQRS;

public interface ICommand: IRequest
{
}

public interface ICommand<TResponse> : IRequest<TResponse>
{
}
