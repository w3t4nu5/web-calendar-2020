using System;
using System.Collections.Generic;
using System.Text;
using WebCalendar.DAL.Models.Entities;

namespace WebCalendar.Services.Sheduler.Models
{
    public class SchedulerEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan? RepetitionInterval { get; set; }
        public TimeSpan? NotifyBeforeInterval { get; set; }
        public int? RepetitionsCount { get; set; }
        public DateTime? RepetitionsEndTime { get; set; }

        public ICollection<DayOfWeek> Days { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
