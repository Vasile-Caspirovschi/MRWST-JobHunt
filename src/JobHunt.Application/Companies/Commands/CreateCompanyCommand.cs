using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using JobHunt.Domain.Shared;

namespace JobHunt.Application.Companies.Commands;

public sealed record CreateCompanyCommand(string Name, AppUser Representative) : ICommand;

public class CreateCompanyCommandHandler(IJobHuntDbContext dbContext) : ICommandHandler<CreateCompanyCommand>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var newCompany = new Company()
        {
            Name = request.Name,
            CompanyRepresentativeId = request.Representative.Id,
            CompanyRepresentative = request.Representative
        };

        await _dbContext.Companies.AddAsync(newCompany, cancellationToken);
        if (await _dbContext.SaveChangesAsync(cancellationToken) > 0)
            return Result.Success();
        return Result.Failure(new Error("CreateCompany.Failed", "Something went wrong when trying to create a new company"));
    }
}