using JobHunt.Domain.Entities;
using JobHunt.Presentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobHunt.Presentation.Controllers;

public class AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IUserStore<AppUser> userStore)
    : Controller
{

    private readonly SignInManager<AppUser> _signInManager = signInManager;
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly IUserStore<AppUser> _userStore = userStore;

    public IActionResult Login(string returnUrl = "/")
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login()
    {
        //        var user = userRepository.GetByUsernameAndPassword(
        //model.Username, model.Password);
        //        if (user == null)
        //            return Unauthorized();

        //        await HttpContext.SignInAsync();

        //        return LocalRedirect(model.ReturnUrl);
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
            var user = new AppUser();
            await _userStore.SetUserNameAsync(user, register.FullName, CancellationToken.None);
            //await /*_emailStore*/.SetEmailAsync(user, register.Email, CancellationToken.None);
            user.Email = register.Email;
            user.PhoneNumber = register.PhoneNumber;
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                //var userId = await _userManager.GetUserIdAsync(user);
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
    public IActionResult RegisterEmployer(string returnUrl = "/")
    {
        return View();
    }
}
