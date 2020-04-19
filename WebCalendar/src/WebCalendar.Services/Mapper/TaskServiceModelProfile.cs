using WebCalendar.Common;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.Services.Models.Task;
using WebCalendar.Services.Scheduler.Models;

namespace WebCalendar.Services.Mapper
{
    public class TaskServiceModelProfile : AutoMapperProfile
    {
        public TaskServiceModelProfile()
        {
            CreateMap<TaskCreationServiceModel, Task>();

            CreateMap<TaskEditionServiceModel, Task>();

            CreateMap<Task, TaskServiceModel>();

            CreateMap<TaskServiceModel, Task>();

            CreateMap<Task, SchedulerTask>();
        }
    }
}