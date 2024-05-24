using JobHunt.Application.Categories.Queries;
using JobHunt.Application.Companies.Queries;
using JobHunt.Application.Jobs;
using JobHunt.Application.Jobs.Commands;
using JobHunt.Application.Jobs.Queries;
using JobHunt.Domain.Enums;
using JobHunt.Domain.Shared;
using JobHunt.Presentation.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace JobHunt.Presentation.Controllers;

[Authorize(Roles = nameof(UserRoleType.Employer))]
public class JobsController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;

    [AllowAnonymous]
    public async Task<IActionResult> Jobs(PaginationParams paginationParams, JobPostFilterParams filters, CancellationToken cancellationToken)
    {
        var viewModel = new JobsViewModel();
        var result = await _mediator.Send(new GetAllJobsPagedQuery(paginationParams, filters), cancellationToken);
        var categoriesResult = await _mediator.Send(new GetAllJobCategoriesQuery(), cancellationToken);

        if (result.IsSuccess)
        {
            viewModel.Jobs = result.Value;
            viewModel.Categories = categoriesResult.Value;
            viewModel.Pagination = new PaginationViewModel(result.PageCount, result.RowCount, result.PageSize, result.PageNumber);
        }

        return View(viewModel);
    }

    [AllowAnonymous]
    public async Task<IActionResult> JobDetails(Guid jobPostId, CancellationToken cancellationToken)
    {
        var getJobPostResult = await _mediator.Send(new GetJobPostById(jobPostId), cancellationToken);
        if (getJobPostResult.IsFailure)
            return RedirectToAction(nameof(Jobs), nameof(Jobs));

        var getCompanyResult = await _mediator.Send(new GetCompanyByIdQuery(getJobPostResult.Value.CompanyId.Value), cancellationToken);

        if (getCompanyResult.IsFailure)
            return RedirectToAction(nameof(Jobs), nameof(Jobs));

        var viewModel = new JobViewModel()
        {
            JobPost = getJobPostResult.Value,
            Company = getCompanyResult.Value
        };
        return View(viewModel);
    }

    public async Task<IActionResult> PostJob(CancellationToken cancellationToken)
    {
        string companyId = User.FindFirstValue("CompanyId");
        var getCategoriesResult = await _mediator.Send(new GetAllJobCategoriesQuery(), cancellationToken);
        var getCompanyResult = await _mediator.Send(new GetCompanyByIdQuery(Guid.Parse(companyId)), cancellationToken);

        CreateEditJobPostViewModel vm = new()
        {
            Categories = getCategoriesResult.Value,
            CompanyDto = getCompanyResult.Value,
            JobPost = new JobPostDto()
        };
        vm.JobPost.Location = vm.CompanyDto.Location;
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> PostJob(CreateEditJobPostViewModel viewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return View(viewModel);
        var userId = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
        var getCompanyResult = await _mediator.Send(new GetCompanyByRepresentativeIdQuery(Guid.Parse(userId)));
        if (getCompanyResult.IsSuccess)
        {
            viewModel.JobPost.CompanyId = getCompanyResult.Value.Id;
            var result = await _mediator.Send(new CreateJobPostCommand(viewModel.JobPost), cancellationToken);
            //fix this
            if (result.IsSuccess)
                return RedirectToAction(nameof(Jobs), nameof(Jobs));
        }

        return View(viewModel);
    }

    public async Task<IActionResult> EditJobPost(Guid jobPostId, CancellationToken cancellationToken)
    {
        var categoriesResult = await _mediator.Send(new GetAllJobCategoriesQuery(), cancellationToken);
        var getJobPostResult = await _mediator.Send(new GetJobPostById(jobPostId), cancellationToken);

        if (getJobPostResult.IsFailure)
            return RedirectToAction("MyAccount", "Employer");

        CreateEditJobPostViewModel vm = new();
        vm.Categories = categoriesResult.Value;
        vm.JobPost = getJobPostResult.Value;
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> EditJobPost(CreateEditJobPostViewModel viewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var result = await _mediator.Send(new UpdateJobPostCommand(viewModel.JobPost), cancellationToken);
        if (result.IsSuccess)
            return RedirectToAction(nameof(JobDetails), nameof(Jobs), new { jobPostId = viewModel.JobPost.Id });

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteJobPost(Guid jobPostId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteJobPostByIdCommand(jobPostId), cancellationToken);
        if (result.IsSuccess)
        {
            return RedirectToAction("JobPosts", "Employer");
        }
        return RedirectToAction("JobPosts", "Employer");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
