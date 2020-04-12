using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebCalendar.Services.EmailSender.Contracts;
using WebCalendar.Services.EmailSender.Models;

namespace WebCalendar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public TestController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var message = new Message(new[]{"some@email"}, "Notification", "Hi");
            await _emailSender.SendEmailAsync(message);
            return Ok("hello");
        }
    }
}