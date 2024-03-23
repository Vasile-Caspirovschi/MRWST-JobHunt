using JobHunt.Domain.Shared;
using MediatR;

namespace JobHunt.Application.Common.CQRS;

public interface ICommand: IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
