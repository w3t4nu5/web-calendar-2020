using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebCalendar.Services.Contracts;
using WebCalendar.Services.Models.Task;

namespace WebCalendar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TestController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TestController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("hello");
        }

        [HttpPost]
        public async Task<ActionResult<TaskCreationServiceModel>> PostTask(TaskCreationServiceModel task)
        {
            await _taskService.AddAsync(task);

            return Ok(task);
        }
    }
}