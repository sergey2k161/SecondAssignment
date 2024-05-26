using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondAssignment.Models;
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecondAssignment.Controllers;
[ApiController]
[Route("[controller]")]
public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet("RegisterUser")]
    public IActionResult Register()
    {
        return Ok();
    }

    [HttpPost("RegisterModel")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser { UserName = model.UserName };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // Log ModelState errors for debugging
        foreach (var key in ModelState.Keys)
        {
            var errors = ModelState[key].Errors;
            foreach (var error in errors)
            {
                // Log each error
                Console.WriteLine($"Error in {key}: {error.ErrorMessage}");
            }
        }

        return BadRequest(ModelState);
    }

        
    [HttpGet("LoginUser")]
    public IActionResult Login()
    {
        return Ok();
    }
    [HttpGet("CurrentUser")]
    public IActionResult CurrentUser()
    {
        if (User.Identity.IsAuthenticated)
        {
            return Ok($"Authenticated user: {User.Identity.Name}");
        }
        else
        {
            return Ok("User not authenticated");
        }
    }

    [HttpPost("LoginModel")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok("Login successful");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }
        }

        // Неверные данные в модели, возвращаем ошибку.
        return BadRequest(ModelState);
    }

    /*
    [HttpPost("LogOutModel")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }
    */
}
