﻿using Microsoft.AspNetCore.Identity;
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
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
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

        return BadRequest(ModelState);
    }
        
    [HttpGet("LoginUser")]
    public IActionResult Login()
    {
        return Ok();
    }
    [HttpPost("LoginModel")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
        }

        return BadRequest(ModelState);
    }

    [HttpPost("LogOutModel")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }
}
