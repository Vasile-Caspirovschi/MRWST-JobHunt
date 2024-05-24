using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Entities;
using JobHunt.Domain.Shared;

namespace JobHunt.Application.Companies.Commands;

public sealed record CreateCompanyCommand(string Name, Employer Representative) : ICommand;

public class CreateCompanyCommandHandler(IJobHuntDbContext dbContext) : ICommandHandler<CreateCompanyCommand>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        Company newCompany = new()
        {
            Name = request.Name,
            Employer = request.Representative
        };
        _dbContext.Companies.Add(newCompany);

        request.Representative.Company = newCompany;
        request.Representative.CompanyId = newCompany.Id;
        _dbContext.Employers.Update(request.Representative);

        if (await _dbContext.SaveChangesAsync(cancellationToken) > 0)
            return Result.Success();
        return Result.Failure(new Error("CreateCompany.Failed", "Something went wrong when trying to create a new company"));
    }
}