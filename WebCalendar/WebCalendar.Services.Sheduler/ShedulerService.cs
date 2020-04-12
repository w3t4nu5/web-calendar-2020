using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebCalendar.DAL.Models.Entities;

namespace WebCalendar.Services.Sheduler
{
    public interface ISchedulerService
    {
        Task SheduleReminder(Reminder reminder);
    }
    public class SchedulerService
    {

    }
}
