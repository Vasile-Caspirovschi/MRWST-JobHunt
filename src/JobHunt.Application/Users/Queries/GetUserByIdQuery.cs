using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using JobHunt.Domain.Enums;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.Users.Queries;

public sealed record GetUserByIdQuery(Guid Id) : IQuery<AppUserDto>;

public class GetUserByIdHandler(IJobHuntDbContext context) : IQueryHandler<GetUserByIdQuery, AppUserDto>
{
    private readonly IJobHuntDbContext _dbContext = context;

    public async Task<Result<AppUserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        AppUser? user = null;
            user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (user is null)
            return Result.Failure<AppUserDto>(new Error("GetCompany.Failed", "User not found"));

        return new AppUserDto
        {
            Id = user.Id,
            Fullname = user.UserName,
            Email = user.Email,
            Phone = user.PhoneNumber
        };
    }
}