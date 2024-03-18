using MediatR;

namespace JobHunt.Application.Common.CQRS;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}