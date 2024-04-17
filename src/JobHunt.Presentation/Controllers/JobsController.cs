using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JobHunt.Presentation.Models;
using MediatR;
using JobHunt.Application.Jobs.Commands;
using JobHunt.Application.Jobs;

namespace JobHunt.Presentation.Controllers;

public class JobsController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;

    public IActionResult Jobs()
    {
        return View();
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
        else
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
