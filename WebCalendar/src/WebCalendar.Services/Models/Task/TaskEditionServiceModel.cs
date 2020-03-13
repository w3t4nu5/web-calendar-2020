using System;

namespace WebCalendar.Services.Models.Task
{
    public class TaskEditionServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsDone { get; set; }
    }
}