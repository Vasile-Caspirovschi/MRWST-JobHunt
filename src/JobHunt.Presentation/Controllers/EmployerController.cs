using JobHunt.Application.Common.Interfaces;
using JobHunt.Application.Companies.Commands;
using JobHunt.Application.Companies.Queries;
using JobHunt.Application.Jobs.Queries;
using JobHunt.Domain.Entities;
using JobHunt.Domain.Enums;
using JobHunt.Domain.Shared;
using JobHunt.Presentation.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading;

namespace JobHunt.Presentation.Controllers;

[Authorize]
public class EmployerController(IMediator mediator, UserManager<AppUser> userManager, ICloudImageService imageService) : Controller
{
    private readonly IMediator _mediator = mediator;
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly ICloudImageService _imageService = imageService;

    [Authorize(Roles = nameof(UserRoleType.Employer))]
    public async Task<IActionResult> MyAccount(CancellationToken cancellationToken)
    {
        string companyId = User.FindFirstValue("CompanyId");
        var getCompanyStatisticResult =
            await _mediator.Send(new GetCompanyStatisticQuery(Guid.Parse(companyId)), cancellationToken);
        return View(getCompanyStatisticResult.Value);
    }

    [Authorize(Roles = nameof(UserRoleType.Employer))]
    public async Task<IActionResult> JobPosts(CancellationToken cancellationToken)
    {
        string companyId = User.FindFirstValue("CompanyId");
        var jobPostsResult = await _mediator.Send(new GetCompanyJobPostsQuery(Guid.Parse(companyId)), cancellationToken);
        CompanyJobPostsViewModel vm = new();
        vm.JobPosts = jobPostsResult.Value;
        return View(vm);
    }

    public async Task<IActionResult> AboutCompany(CancellationToken cancellationToken)
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await _mediator.Send(new GetCompanyByRepresentativeIdQuery(Guid.Parse(id)), cancellationToken);

        if (result.IsSuccess) return View(new CompanyViewModel(result.Value));

        ModelState.AddModelError(string.Empty, result.Error.Message);
        return View(new CompanyViewModel());
    }

    public IActionResult ContactData()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCompanyDetails(CompanyViewModel companyViewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return View("AboutCompany", companyViewModel);
        if (companyViewModel.UploadedLogo is not null)
        {
            var image = new UploadedImageFile()
            {
                FileName = companyViewModel.UploadedLogo.FileName,
                Length = companyViewModel.UploadedLogo.Length,
                Stream = companyViewModel.UploadedLogo.OpenReadStream()
            };
            var uploadResult = await _imageService.AddImageAsync(image);
            if (uploadResult.Error is null)
            {
                companyViewModel.Company.LogoUrl = uploadResult.SecureUrl.AbsoluteUri;
                companyViewModel.Company.LogoId = uploadResult.PublicId;
            }
        }
        var result = await _mediator.Send(new UpdateCompanyCommand(companyViewModel.Company), cancellationToken);
        if (result.IsFailure)
            ModelState.AddModelError(string.Empty, result.Error.Message);
        return View("AboutCompany", companyViewModel);
    }
}