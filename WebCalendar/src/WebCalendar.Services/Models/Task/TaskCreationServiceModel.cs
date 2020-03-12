using System;

namespace WebCalendar.Services.Models.Task
{
    public class TaskCreationServiceModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }

        public Guid CalendarId { get; set; }
    }
}