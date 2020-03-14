using System;
using System.Collections.Generic;

namespace WebCalendar.Services.Models.Reminder
{
    public class ReminderEditionServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan? RepetitionInterval { get; set; }
        public int? RepetitionsCount { get; set; }
        public DateTime? RepetitionsEndTime { get; set; }

        public ICollection<DayOfWeek> Days { get; set; }
    }
}