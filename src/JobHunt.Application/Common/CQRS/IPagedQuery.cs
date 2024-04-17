using JobHunt.Domain.Shared;
using MediatR;

namespace JobHunt.Application.Common.CQRS;

public interface IPagedQuery<TResponse> : IRequest<PagedResult<TResponse>>;
