using System;
using System.Collections.Generic;
using System.Text;

namespace WebCalendar.DAL.Models.Entities
{
    public class ReminderDay
    {
        public Guid ReminderId { get; set; }
        public Reminder Reminder { get; set; }

        public Guid DayId { get; set; }
        public Day Day { get; set; }
    }
}
