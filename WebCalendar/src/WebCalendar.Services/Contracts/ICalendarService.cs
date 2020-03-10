using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.Services.Models.Calendar;
using Task = System.Threading.Tasks.Task;

namespace WebCalendar.Services.Contracts
{
    public interface ICalendarService
    {
        Task AddAsync(CalendarCreationServiceModel entity);
        Task<IEnumerable<Calendar>> GetAllAsync();
        Task<CalendarServiceModel> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task RemoveAsync(CalendarServiceModel entity);
        Task ShareToUser(Guid calendarId, Guid userId);
        Task UnshareToUser(Guid calendarId, Guid userId);
        Task UpdateAsync(CalendarCreationServiceModel entity);
    }
}
