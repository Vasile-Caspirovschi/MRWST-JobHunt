using CloudinaryDotNet.Actions;
using JobHunt.Application.JobSeekers.Commands;
using JobHunt.Application.JobSeekers.Queries;
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
public class JobSeekerController(IMediator mediator, UserManager<AppUser> userManager) : Controller
{
    private readonly IMediator _mediator = mediator;
    private readonly UserManager<AppUser> _userManager = userManager;

    [Authorize(Roles = nameof(UserRoleType.JobSeeker))]
    public async Task<IActionResult> MyAccount(CancellationToken cancellationToken)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await _mediator.Send(new GetJobSeekerByIdQuery(Guid.Parse(userId)), cancellationToken);

        JobSeekerViewModel vm = new();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
            return View(new JobSeekerViewModel());
        }
        vm.JobSeeker = result.Value;
        return View(vm);
    }


    public async Task<IActionResult> UpdateProfile(JobSeekerViewModel viewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return View("MyAccount", viewModel);
        var user = await _userManager.GetUserAsync(User);

        user.UserName = viewModel.JobSeeker.Profile.Fullname;
        user.Email = viewModel.JobSeeker.Profile.Email;
        user.PhoneNumber = viewModel.JobSeeker.Profile.Phone;

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
            ModelState.AddModelError(string.Empty, string.Join(", ", result.Errors.Select(e => e.Description)));
        return View("MyAccount", viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> UploadCV(JobSeekerViewModel viewModel, CancellationToken cancellationToken)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!viewModel.JobSeeker.HasUploadedCV && viewModel.UploadedCV is not null)
        {
            UploadedFile cv = new()
            {
                FileName = viewModel.UploadedCV.FileName,
                Length = viewModel.UploadedCV.Length,
                Stream = viewModel.UploadedCV.OpenReadStream()
            };
            var uploadCVResult = await _mediator.Send(new UploadCVCommand(Guid.Parse(userId), cv), cancellationToken);

            if (uploadCVResult.IsFailure)
            {
                //TODO handle this i'm lazy now
            }
        }
        return RedirectToAction("MyAccount");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteCV(Guid jobSeekerId, CancellationToken cancellationToken)
    {
        var deleteCVResult = await _mediator.Send(new DeleteCVCommand(jobSeekerId), cancellationToken);
        if (deleteCVResult.IsFailure)
        {
            //TODO handle this i'm lazy now
        }
        return RedirectToAction("MyAccount");
    }
}
