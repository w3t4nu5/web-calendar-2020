using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebCalendar.Common.Contracts;
using WebCalendar.DAL;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.Services.Contracts;
using WebCalendar.Services.Models.Reminder;
using Task = System.Threading.Tasks.Task;

namespace WebCalendar.Services.Implementation
{
    public class ReminderService : IReminderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ReminderService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task AddAsync(ReminderCreationServiceModel entity)
        {
            Reminder reminder = _mapper.Map<ReminderCreationServiceModel, Reminder>(entity);
            await _uow.GetRepository<Reminder>().AddAsync(reminder);

            await _uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReminderServiceModel>> GetAllAsync()
        {
            var reminders = await _uow.GetRepository<Reminder>()
                .GetAllAsync();

            IEnumerable<ReminderServiceModel> reminderServiceModels = _mapper
                .Map<IEnumerable<Reminder>, IEnumerable<ReminderServiceModel>>(reminders);

            return reminderServiceModels;
        }

        public async Task<ReminderServiceModel> GetByIdAsync(Guid id)
        {
            var reminder = await _uow.GetRepository<Reminder>()
                .GetByIdAsync(id);
            var reminderServiceModel = _mapper.Map<Reminder, ReminderServiceModel>(reminder);

            return reminderServiceModel;
        }

        public async Task RemoveAsync(Guid id)
        {
            Reminder reminder = await _uow.GetRepository<Reminder>()
                .GetByIdAsync(id);
            ReminderServiceModel reminderServiceModel = _mapper
                .Map<Reminder, ReminderServiceModel>(reminder);

            await RemoveAsync(reminderServiceModel);
        }

        public async Task RemoveAsync(ReminderServiceModel entity)
        {
            Reminder reminder = _mapper
                .Map<ReminderServiceModel, Reminder>(entity);
            _uow.GetRepository<Reminder>().Remove(reminder);

            await _uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(ReminderEditionServiceModel entity)
        {
            Reminder reminder = _mapper
                .Map<ReminderEditionServiceModel, Reminder>(entity);
            _uow.GetRepository<Reminder>().Update(reminder);

            await _uow.SaveChangesAsync();
        }
    }
}
