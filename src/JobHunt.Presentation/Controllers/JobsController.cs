using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JobHunt.Presentation.Models;
using MediatR;
using JobHunt.Application.Jobs.Commands;
using JobHunt.Application.Jobs;
using Microsoft.AspNetCore.Authorization;
using JobHunt.Application.Jobs.Queries;

namespace JobHunt.Presentation.Controllers;

[Authorize]
public class JobsController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;

    public async Task<IActionResult> Jobs(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        IEnumerable<JobPostDto> jobs = [];
        var result = await _mediator.Send(new GetAllJobsPagedQuery(pageNumber, pageSize), cancellationToken);
        if (result.IsSuccess)
            jobs = result.Value;
        return View(jobs);
    }

    public IActionResult JobDetails()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> PostJob(JobPostDto newJobPost, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return View();
        var result = await _mediator.Send(new CreateJobPostCommand(newJobPost), cancellationToken);
        if (result.IsSuccess)
            return RedirectToAction(nameof(Jobs), nameof(Jobs));
        return View();
    }

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
