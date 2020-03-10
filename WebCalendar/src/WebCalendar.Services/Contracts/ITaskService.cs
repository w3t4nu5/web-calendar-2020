using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebCalendar.Services.Models.Task;
using Entities = WebCalendar.DAL.Models.Entities;

namespace WebCalendar.Services.Contracts
{
    public interface ITaskService
    {
        System.Threading.Tasks.Task AddAsync(TaskCreationServiceModel entity);
        Task<IEnumerable<Entities.Task>> GetAllAsync();
        Task<TaskServiceModel> GetByIdAsync(Guid id);
        System.Threading.Tasks.Task RemoveAsync(Guid id);
        System.Threading.Tasks.Task RemoveAsync(TaskServiceModel entity);
        System.Threading.Tasks.Task UpdateAsync(TaskEditionServiceModel entity);
    }
}
