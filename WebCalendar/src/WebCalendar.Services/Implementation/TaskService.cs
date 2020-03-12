using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebCalendar.Common.Contracts;
using WebCalendar.DAL;
using WebCalendar.Services.Contracts;
using WebCalendar.Services.Models.Task;
using Entities = WebCalendar.DAL.Models.Entities;

namespace WebCalendar.Services.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public async Task AddAsync(TaskCreationServiceModel entity)
        {
            Entities.Task task = _mapper.Map<TaskCreationServiceModel, Entities.Task>(entity);
            await _uow.GetRepository<Entities.Task>().AddAsync(task);

            await _uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entities.Task>> GetAllAsync()
        {
            var tasks = await _uow.GetRepository<Entities.Task>()
                .GetAllAsync();

            return tasks;
        }

        public async Task<TaskServiceModel> GetByIdAsync(Guid id)
        {
            var task = await _uow.GetRepository<Entities.Task>()
                .GetByIdAsync(id);
            var taskServiceModel = _mapper.Map<Entities.Task, TaskServiceModel>(task);

            return taskServiceModel;
        }

        public async Task RemoveAsync(Guid id)
        {
            Entities.Task task = await _uow.GetRepository<Entities.Task>()
                .GetByIdAsync(id);
            TaskServiceModel taskServiceModel = _mapper
                .Map<Entities.Task, TaskServiceModel>(task);

            await RemoveAsync(taskServiceModel);
        }

        public async Task RemoveAsync(TaskServiceModel entity)
        {
            Entities.Task task = _mapper
                .Map<TaskServiceModel, Entities.Task>(entity);
            _uow.GetRepository<Entities.Task>().Remove(task);

            await _uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskEditionServiceModel entity)
        {
            Entities.Task task = _mapper
                .Map<TaskEditionServiceModel, Entities.Task>(entity);
            _uow.GetRepository<Entities.Task>().Update(task);

            await _uow.SaveChangesAsync();
        }
    }
}
