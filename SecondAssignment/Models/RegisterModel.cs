namespace SecondAssignment.Models;
using System.ComponentModel.DataAnnotations;

public class RegisterModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
    public string ConfirmPassword { get; set; }
}