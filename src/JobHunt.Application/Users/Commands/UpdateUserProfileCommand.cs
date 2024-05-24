using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using JobHunt.Domain.Enums;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.Users.Commands;

public sealed record UpdateUserProfileCommand(AppUserDto User) : ICommand;

public class UpdateUserProfileCommandHandler(IJobHuntDbContext dbContext) : ICommandHandler<UpdateUserProfileCommand>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = null;
        user = await _dbContext.Employers.FirstOrDefaultAsync(x => x.Id == request.User.Id);

        if (user is null)
            return Result.Failure(new Error("UpdateUser.Failed", "User not found"));

        user.UserName = request.User.Fullname;
        user.Email = request.User.Email;
        user.PhoneNumber = request.User.Phone;

        _dbContext.Users.Update(user);
        if (await _dbContext.SaveChangesAsync(cancellationToken) > 0)
            return Result.Success();

        return Result.Failure(new Error("UpdateUser.Failed", "Something went wrong when trying to update the job post"));
    }
}