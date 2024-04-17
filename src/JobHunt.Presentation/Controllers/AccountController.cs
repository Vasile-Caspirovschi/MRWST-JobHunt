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
}