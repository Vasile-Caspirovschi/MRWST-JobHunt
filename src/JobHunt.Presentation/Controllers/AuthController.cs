using JobHunt.Application.Companies.Commands;
using JobHunt.Application.Companies.Queries;
using JobHunt.Domain.Entities;
using JobHunt.Domain.Enums;
using JobHunt.Presentation.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobHunt.Presentation.Controllers;

public class AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,
    IUserStore<AppUser> userStore, IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;
    private readonly SignInManager<AppUser> _signInManager = signInManager;
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly IUserStore<AppUser> _userStore = userStore;

    public async Task<IActionResult> Login()
    {
        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel login, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return View();

        var user = _signInManager.UserManager.Users.FirstOrDefault(u => u.Email == login.Email);
        if (user is null)
        {
            ModelState.AddModelError(string.Empty, "Username does not exist.");
            return View();
        }

        var result = await _signInManager.PasswordSignInAsync(user.UserName!, login.Password, login.RememberMe, false);

        if (!result.Succeeded)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }
        return RedirectToAction("MyAccount", "Employer");
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult RegisterJobSeeker()
    {
        return View();
    }

    public IActionResult RegisterEmployer()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterJobSeeker(RegisterViewModel register)
    {
        if (!ModelState.IsValid) return View(register);

        JobSeeker newJobSeeker = new()
        {
            Email = register.Email,
            PhoneNumber = register.PhoneNumber,
        };
        await _userStore.SetUserNameAsync(newJobSeeker, register.FullName, CancellationToken.None);
        var result = await _userManager.CreateAsync(newJobSeeker, register.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(newJobSeeker, nameof(UserRoleType.JobSeeker));
            await _signInManager.SignInAsync(newJobSeeker, false);
            return RedirectToAction("MyAccount", "JobSeeker");
        }

        foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);

        return View(register);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterEmployer(RegisterViewModel register)
    {
        if (!ModelState.IsValid) return View(register);
        if (string.IsNullOrEmpty(register.CompanyName))
        {
            ModelState.AddModelError(nameof(register.CompanyName), "Company name is required.");
            return View(register);
        }

        Employer newEmployer = new()
        {
            Email = register.Email,
            PhoneNumber = register.PhoneNumber,
        };
        await _userStore.SetUserNameAsync(newEmployer, register.FullName, CancellationToken.None);
        var result = await _userManager.CreateAsync(newEmployer, register.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(newEmployer, UserRoleType.Employer.ToString());
            await _signInManager.SignInAsync(newEmployer, false);
            var createCompanyResult = await _mediator.Send(new CreateCompanyCommand(register.CompanyName, newEmployer));
            if (createCompanyResult.IsFailure)
            {
                ModelState.AddModelError(string.Empty, "Failed to create the company.");
                return View(register);
            }
            return RedirectToAction("MyAccount", "Employer");
        }

        foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);

        return View(register);
    }
}