using System.Security.Claims;
using JobHunt.Application.Companies;
using JobHunt.Application.Companies.Commands;
using JobHunt.Application.Companies.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobHunt.Presentation.Controllers;

[Authorize]
public class AccountController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;
    
    public async Task<IActionResult> AboutCompany(CancellationToken cancellationToken)
    {
        var id = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
        var result = await _mediator.Send(new GetCompanyByRepresentativeId(id), cancellationToken);
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
            return View(new CompanyDto());
        }
        return View(result.Value);
    }

    public IActionResult ContactData()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCompanyDetails(CompanyDto company, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return View("AboutCompany", company);
        var result = await _mediator.Send(new UpdateCompanyCommand(company), cancellationToken);
        if (result.IsFailure)
            ModelState.AddModelError(string.Empty, result.Error.Message);
        return View("AboutCompany", company);
    }
}