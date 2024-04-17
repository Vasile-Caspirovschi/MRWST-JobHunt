using Microsoft.AspNetCore.Mvc;

namespace JobHunt.Presentation.Controllers;

public class AuthController : Controller
{
    public IActionResult Login()
    {
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
