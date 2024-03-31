using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Shared;

namespace JobHunt.Application.Companies.Commands;

public sealed record UpdateCompanyCommand(CompanyDto Company) : ICommand;

public class UpdateCompanyCommandHandler(IJobHuntDbContext dbContext) : ICommandHandler<UpdateCompanyCommand>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;
    
    public async Task<Result> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _dbContext.Companies.FindAsync(request.Company.Id, cancellationToken);
        if (company is null)
        {
            return Result.Failure(new Error("UpdateCompany.Failed", "Company not found"));
        }

        company.Name = request.Company.Name;
        company.Description = request.Company.Description;
        company.Location = request.Company.Location;
        company.Phone = request.Company.Phone;
        company.Logo = request.Company.Logo;
        _dbContext.Companies.Update(company);
        
        if (await _dbContext.SaveChangesAsync(cancellationToken) > 0)
            return Result.Success();
        return Result.Failure(new Error("UpdateCompany.Failed", "Something went wrong when trying to update the company"));
    }
}