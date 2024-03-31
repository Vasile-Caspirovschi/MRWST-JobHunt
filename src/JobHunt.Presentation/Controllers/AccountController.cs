using Microsoft.AspNetCore.Mvc;

namespace JobHunt.Presentation.Controllers;

public class AccountController : Controller
{
    public IActionResult AboutCompany()
    {
        return View();
    }
    
    public IActionResult ContactData()
    {
        return View();
    }
}