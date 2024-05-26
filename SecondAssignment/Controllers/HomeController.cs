using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SecondAssignment.Models;

namespace SecondAssignment.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return Ok();
    }
}