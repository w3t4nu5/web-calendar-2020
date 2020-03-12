using System;
using System.Collections.Generic;
using System.Text;

namespace WebCalendar.Services.Models.Reminder
{
    public class ReminderEditionServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
    }
}
