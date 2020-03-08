using System;
using System.Collections.Generic;
using System.Text;

namespace WebCalendar.Services.Models.Reminder
{
    public class ReminderCreationServiceModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }

        public Guid CalendarId { get; set; }
    }
}
