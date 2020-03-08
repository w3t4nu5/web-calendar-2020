using System;
using System.Collections.Generic;
using System.Text;
using WebCalendar.DAL.Models.Entities.Enums;
using WebCalendar.Services.Models.User;

namespace WebCalendar.Services.Models.Event
{
    public class EventCreationServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public NotifyBeforeMode NotifyBeforeMode { get; set; }
        public RepeatMode RepeatMode { get; set; }

        public Guid CalendarId { get; set; }
        public ICollection<UserSummaryModel> SubscribedUsers { get; set; }
    }
}
