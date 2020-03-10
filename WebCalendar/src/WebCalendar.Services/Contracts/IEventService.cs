using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.Services.Models.Event;
using Task = System.Threading.Tasks.Task;

namespace WebCalendar.Services.Contracts
{
    public interface IEventService
    {
        Task AddAsync(EventCreationServiceModel entity);
        Task<IEnumerable<Event>> GetAllAsync();
        Task<EventServiceModel> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task RemoveAsync(EventServiceModel entity);
        Task UpdateAsync(EventCreationServiceModel entity);
    }
}
