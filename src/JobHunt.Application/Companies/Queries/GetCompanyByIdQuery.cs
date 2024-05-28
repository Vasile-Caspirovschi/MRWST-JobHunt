using JobHunt.Application.Common.CQRS;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Application.Companies.Queries;

public sealed record GetCompanyByIdQuery(Guid Id) : IQuery<CompanyDto>;

public class GeCompanyByIdHandler(IJobHuntDbContext dbContext) : IQueryHandler<GetCompanyByIdQuery, CompanyDto>
{
    private readonly IJobHuntDbContext _dbContext = dbContext;

    public async Task<Result<CompanyDto>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await _dbContext.Companies.Include(c => c.Logo).FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        if (company is null)
            return Result.Failure<CompanyDto>(new Error("GetCompany.Failed", "Company not found"));

        return new CompanyDto()
        {
            Id = company.Id,
            Name = company.Name,
            RepresentativeId = company.EmployerId,
            Description = company.Description,
            Location = company.Location,
            LogoUrl = company.Logo?.ImageUrl ?? @"/images/placeholder.png",
            LogoId = company.Logo?.PublicId,
            Phone = company.Phone
        };
    }
}