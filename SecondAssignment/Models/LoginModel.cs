﻿namespace SecondAssignment.Models;
using System.ComponentModel.DataAnnotations;
public class LoginModel
{
    [Required]
    [EmailAddress]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    public bool RememberMe { get; set; }
}