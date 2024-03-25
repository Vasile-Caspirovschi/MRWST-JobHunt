using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JobHunt.Presentation.Models;

#nullable disable
public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [TempData]
    public string ErrorMessage { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}
