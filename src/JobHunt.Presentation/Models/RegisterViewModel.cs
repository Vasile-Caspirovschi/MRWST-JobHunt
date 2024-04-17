﻿using System.ComponentModel.DataAnnotations;

namespace JobHunt.Presentation.Models;

#nullable disable
public class RegisterViewModel
{

    [Required]
    [Display(Name = "Full Name")]
    public string FullName { get; set; }

    [Display(Name = "Company Name")]
    public string? CompanyName { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [Phone]
    [Display(Name = "Phone")]
    public string PhoneNumber { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

   
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}
