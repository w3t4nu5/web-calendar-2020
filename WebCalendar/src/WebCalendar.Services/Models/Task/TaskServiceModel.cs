using System;
using System.Collections.Generic;
using System.Text;
using WebCalendar.Services.Models.Calendar;

namespace WebCalendar.Services.Models.Task
{
    public class TaskServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsDone { get; set; }

        public CalendarServiceModel Calendar { get; set; }
    }
}
