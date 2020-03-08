using System;
using System.Collections.Generic;
using System.Text;
using WebCalendar.Services.Models.Calendar;

namespace WebCalendar.Services.Contracts
{
    public interface ICalendarService : IAsyncService<CalendarServiceModel>
    {
    }
}
