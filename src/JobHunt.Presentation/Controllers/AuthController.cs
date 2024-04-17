using JobHunt.Domain.Entities;
using JobHunt.Presentation.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobHunt.Presentation.Controllers;

public class AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IUserStore<AppUser> userStore)
    : Controller
{
    private readonly SignInManager<AppUser> _signInManager = signInManager;
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly IUserStore<AppUser> _userStore = userStore;

    public async Task<IActionResult> Login()
    {
        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel login, string? returnUrl = null!)
    {
        returnUrl ??= Url.Content("~/");
        if (ModelState.IsValid)
        {
            var user = _signInManager.UserManager.Users.FirstOrDefault(u => u.Email == login.Email);
            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Username does not exist.");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName!, login.Password, login.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded) return LocalRedirect(returnUrl);
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }
        return View();
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
    public async Task<IActionResult> RegisterJobSeeker(RegisterViewModel register, string returnUrl = "/")
    {
        if (ModelState.IsValid)
        {
            AppUser user = await AppUserInit(register);
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, UserRoleType.JobSeeker.ToString());
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(register);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterEmployer(RegisterViewModel register, string returnUrl = "/")
    {
        if (ModelState.IsValid)
        {
            AppUser user = await AppUserInit(register);
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, UserRoleType.Employer.ToString());
                await _signInManager.SignInAsync(user, isPersistent: false);

                // TODO: create new company where a employer registers

                return LocalRedirect(returnUrl);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(register);
    }

    private async Task<AppUser> AppUserInit(RegisterViewModel register)
    {
        var user = new AppUser();
        await _userStore.SetUserNameAsync(user, register.FullName, CancellationToken.None);
        //await /*_emailStore*/.SetEmailAsync(user, register.Email, CancellationToken.None);
        user.Email = register.Email;
        user.PhoneNumber = register.PhoneNumber;
        return user;
    }
}
