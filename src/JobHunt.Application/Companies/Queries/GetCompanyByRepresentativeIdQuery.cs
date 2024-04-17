using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.Companies.Queries;

public sealed record GetCompanyByRepresentativeIdQuery(string RepresentativeId) : IQuery<CompanyDto>;

public class GetCompanyByRepresentativeIdHanlder(IJobHuntDbContext dbContext) : IQueryHandler<GetCompanyByRepresentativeIdQuery, CompanyDto>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;
    
    public async Task<Result<CompanyDto>> Handle(GetCompanyByRepresentativeIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FindAsync(request.RepresentativeId, cancellationToken);

        if (user == null)
        {
            return Result.Failure<CompanyDto>(
                new Error("GetCompany.Failed", "Company representative not found"));
        }

        var company = await _dbContext.Companies.Include(c => c.Logo)
            .FirstOrDefaultAsync(c => c.CompanyRepresentativeId == request.RepresentativeId, cancellationToken);
        if (company == null)
        {
            return Result.Failure<CompanyDto>(
                new Error("GetCompany.Failed", "Company not found"));
        }
        
        return new CompanyDto()
        {
            Id = company.Id,
            Name = company.Name,
            CompanyRepresentativeId = company.CompanyRepresentativeId,
            Description = company.Description,
            Location = company.Location,
            LogoUrl = company.Logo?.ImageUrl ?? @"/images/placeholder.png",
            LogoId = company.Logo?.PublicId,
            Phone = company.Phone
        };
    }
}