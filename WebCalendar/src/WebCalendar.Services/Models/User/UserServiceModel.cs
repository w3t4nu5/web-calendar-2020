using System;

namespace WebCalendar.Services.Models.User
{
    public class UserServiceModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSubscribedToNativeNotifications { get; set; }
        public bool IsSubscribedToEmailNotifications { get; set; }

        //public ICollection<CalendarUser> CalendarUsers { get; set; }
        //public ICollection<Calendar> Calendars { get; set; }
        //public ICollection<UserEvent> UserEvents { get; set; }
    }
}