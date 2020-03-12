using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.Services.Models.Reminder;
using Task = System.Threading.Tasks.Task;

namespace WebCalendar.Services.Contracts
{
    public interface IReminderService
    {
        Task AddAsync(ReminderCreationServiceModel entity);
        Task<IEnumerable<Reminder>> GetAllAsync();
        Task<ReminderServiceModel> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task RemoveAsync(ReminderServiceModel entity);
        Task UpdateAsync(ReminderEditionServiceModel entity);
    }
}
