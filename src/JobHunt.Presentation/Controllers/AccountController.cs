using JobHunt.Application.Common.Interfaces;
using JobHunt.Application.Companies;
using JobHunt.Application.Companies.Commands;
using JobHunt.Application.Companies.Queries;
using JobHunt.Domain.Shared;
using JobHunt.Presentation.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobHunt.Presentation.Controllers;

[Authorize]
public class AccountController(IMediator mediator, ICloudImageService imageService) : Controller
{
    private readonly IMediator _mediator = mediator;
    private readonly ICloudImageService _imageService = imageService;

    public async Task<IActionResult> AboutCompany(CancellationToken cancellationToken)
    {
        var id = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
        var result = await _mediator.Send(new GetCompanyByRepresentativeIdQuery(id), cancellationToken);

        if (!result.IsFailure) return View(new CompanyViewModel(result.Value));

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