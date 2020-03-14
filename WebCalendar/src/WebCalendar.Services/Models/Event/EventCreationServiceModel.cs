using System;
using System.Collections.Generic;
using WebCalendar.Services.Models.User;

namespace WebCalendar.Services.Models.Event
{
    public class EventCreationServiceModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan? RepetitionInterval { get; set; }
        public TimeSpan? NotifyBeforeInterval { get; set; }
        public int? RepetitionsCount { get; set; }
        public DateTime? RepetitionsEndTime { get; set; }

        public Guid CalendarId { get; set; }
        public ICollection<UserSummaryModel> SubscribedUsers { get; set; }
        public ICollection<DayOfWeek> Days { get; set; }
    }
}