using JobHunt.Domain.Shared;
using MediatR;

namespace JobHunt.Application.Common.CQRS;

public interface IPagedQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, PagedResult<TResponse>>
    where TQuery : IPagedQuery<TResponse>;
