using System;
using System.Collections.Generic;
using System.Text;
using WebCalendar.Services.Models.Reminder;

namespace WebCalendar.Services.Contracts
{
    public interface IReminderService : IAsyncService<ReminderServiceModel>
    {
    }
}
