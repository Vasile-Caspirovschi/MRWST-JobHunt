using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace JobHunt.Presentation.Controllers;

public class AuthController : Controller
{
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
}
