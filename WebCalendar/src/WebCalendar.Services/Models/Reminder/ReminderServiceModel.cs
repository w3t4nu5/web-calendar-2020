using System;
using System.Collections.Generic;
using System.Text;
using WebCalendar.Services.Models.Calendar;

namespace WebCalendar.Services.Models.Reminder
{
    public class ReminderServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }

        public CalendarServiceModel Calendar { get; set; }
    }
}
