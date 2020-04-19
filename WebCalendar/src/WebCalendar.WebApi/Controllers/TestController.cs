using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCalendar.DAL;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.Services.Contracts;
using WebCalendar.Services.Models.Event;
using WebCalendar.Services.Models.Task;

namespace WebCalendar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TestController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IEventService _eventService;
        private readonly IUnitOfWork unitOfWork;
        public TestController(ITaskService taskService, IEventService eventService, IUnitOfWork y)
        {
            _taskService = taskService;
            _eventService = eventService;
            unitOfWork = y;
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

        [HttpPost("arara")]
        public async Task<ActionResult<EventCreationServiceModel>> PostTask(EventCreationServiceModel task)
        {
            await _eventService.AddAsync(task);

            return Ok(task);
        }

        [HttpGet("ass")]
        public async Task<ActionResult<IEnumerable<User>>> vcvcvcvc()
        {
            var users = await unitOfWork.GetRepository<User>().GetAllAsync();

            return Ok(users);
        }
    }
}