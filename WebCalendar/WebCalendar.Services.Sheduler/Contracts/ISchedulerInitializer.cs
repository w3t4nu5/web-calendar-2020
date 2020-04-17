using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebCalendar.Services.Sheduler.Models;

namespace WebCalendar.Services.Sheduler.Contracts
{
    public interface ISchedulerDataLoader
    {
        Task<IEnumerable<SchedulerEvent>> GetSchedulerEvents();
        Task<IEnumerable<SchedulerTask>> GetSchedulerTasks();
        Task<IEnumerable<SchedulerReminder>> GetSchedulerReminders();
    }
}
