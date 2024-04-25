using JobHunt.Application.Companies.Queries;
using JobHunt.Application.Jobs;
using JobHunt.Application.Jobs.Commands;
using JobHunt.Application.Jobs.Queries;
using JobHunt.Presentation.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace JobHunt.Presentation.Controllers;

[Authorize]
public class JobsController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;

    [AllowAnonymous]
    public async Task<IActionResult> Jobs(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var viewModel = new JobsViewModel();
        var result = await _mediator.Send(new GetAllJobsPagedQuery(pageNumber, pageSize), cancellationToken);

        if (result.IsSuccess)
        {
            viewModel.Jobs = result.Value;
            viewModel.CurrentPage = result.PageNumber;
            viewModel.TotalPages = result.PageCount;
        }

        return View(viewModel);
    }


    [AllowAnonymous]
    public IActionResult JobDetails()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Employer")]
    public async Task<IActionResult> PostJob(JobPostDto newJobPost, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return View();
        var userId = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
        var getCompanyResult = await _mediator.Send(new GetCompanyByRepresentativeIdQuery(userId));
        if (getCompanyResult.IsSuccess)
        {
            newJobPost.CompanyId = getCompanyResult.Value.Id;
            var result = await _mediator.Send(new CreateJobPostCommand(newJobPost), cancellationToken);
            //fix this
            if (result.IsSuccess)
                return RedirectToAction(nameof(Jobs), nameof(Jobs));
        }
        
        return View();
    }

    [Authorize(Roles = "Employer")]
    public IActionResult PostJob()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
