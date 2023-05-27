﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GymSports.Data.ViewModels
{
     public class RegisterViewModel
     {
          [Required(ErrorMessage = "Username can't be blank")]
          public string Username { get; set; }

          [Required(ErrorMessage = "Password can't be blank")]
          public string Password { get; set; }

          [Required(ErrorMessage = "Confirm Password can't be blank")]
          [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
          public string ConfirmPassword { get; set; }

          [Required(ErrorMessage = "Email can't be blank")]
          [EmailAddress(ErrorMessage = "Invalid email")]
          public string Email { get; set; }
     }
}
