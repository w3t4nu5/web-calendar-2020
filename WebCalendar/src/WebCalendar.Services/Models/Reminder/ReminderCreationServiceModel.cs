using System;
using System.Collections.Generic;

namespace WebCalendar.Services.Models.Reminder
{
    public class ReminderCreationServiceModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan? RepetitionInterval { get; set; }
        public int? RepetitionsCount { get; set; }
        public DateTime? RepetitionsEndTime { get; set; }

        public ICollection<DayOfWeek> Days { get; set; }
        public Guid CalendarId { get; set; }
    }
}