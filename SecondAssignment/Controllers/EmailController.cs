namespace SecondAssignment.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SecondAssignment.Models;
using SecondAssignment.Servise;
public class EmailController : Controller
{
    private readonly EmailService _emailService;
    
    public EmailController(EmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendEmail([FromBody] EmailModel emailDto)
    {
        await _emailService.SendEmailAsync(emailDto.Email, emailDto.Subject, emailDto.Message);
        return Ok();
    }
    [HttpGet("Files")]
    public IActionResult Files()
    {
        // Ваш код здесь
        return Ok();
    }
    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return Content("Файл не выбран");

        var path = Path.Combine(
            Directory.GetCurrentDirectory(), "wwwroot",
            file.GetFilename());

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return RedirectToAction("Files");
    }

}