using System;
using System.Collections.Generic;
using WebCalendar.Services.Models.Calendar;
using WebCalendar.Services.Models.User;

namespace WebCalendar.Services.Models.Event
{
    public class EventServiceModel
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

        public CalendarServiceModel Calendar { get; set; }
        public ICollection<UserServiceModel> SubscribedUsers { get; set; }
        public ICollection<DayOfWeek> Days { get; set; }
    }
}