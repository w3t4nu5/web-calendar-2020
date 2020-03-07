using System;
using System.Collections.Generic;
using WebCalendar.Services.Models.Calendar;
using WebCalendar.Services.Models.Event;

namespace WebCalendar.Services.Models.User
{
    public class UserServiceModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSubscribedToNativeNotifications { get; set; } = true;
        public bool IsSubscribedToEmailNotifications { get; set; }
        public ICollection<CalendarServiceModel> SharedCalenadars { get; set; }
        //public ICollection<CalendarUser> CalendarUsers { get; set; }
        public ICollection<CalendarServiceModel> Calendars { get; set; }
        public ICollection<EventServiceModel> SharedEvents { get; set; }
        //public ICollection<UserEvent> UserEvents { get; set; }
    }
}