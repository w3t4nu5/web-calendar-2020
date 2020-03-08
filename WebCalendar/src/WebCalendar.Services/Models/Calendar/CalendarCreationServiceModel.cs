using System;
using System.Collections.Generic;
using System.Text;

namespace WebCalendar.Services.Models.Calendar
{
    public class CalendarCreationServiceModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid UserId { get; set; }
    }
}
