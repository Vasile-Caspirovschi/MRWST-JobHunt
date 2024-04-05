using JobHunt.Domain.Shared;
using MediatR;

namespace JobHunt.Application.Common.CQRS;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
{
}
