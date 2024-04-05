using JobHunt.Domain.Shared;
using MediatR;

namespace JobHunt.Application.Common.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}