using System;
using System.Collections.Generic;
using System.Text;

namespace WebCalendar.DAL.Models.Entities
{
    public class EventDay
    {
        public Guid EventId { get; set; }
        public Event Event { get; set; }

        public Guid DayId { get; set; }
        public Day Day { get; set; }
    }
}
