using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebCalendar.Common.Contracts;
using WebCalendar.DAL;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.Services.Contracts;
using WebCalendar.Services.Models.Calendar;

namespace WebCalendar.Services.Implementation
{
    public class CalendarService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public async Task AddAsync(CalendarCreationServiceModel entity)
        {
            Calendar calendar = _mapper.Map<CalendarCreationServiceModel, Calendar>(entity);
            await _uow.GetRepository<Calendar>().AddAsync(calendar);

            return _uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<Calendar>> GetAllAsync()
        {
            var calendars = await _uow.GetRepository<Calendar>()
                .GetAllAsync();

            return calendars;
        }

        public async Task<CalendarServiceModel> GetByIdAsync(Guid id)
        {
            var calendar = await _uow.GetRepository<Calendar>()
                .GetByIdAsync(id);
            var calendarServiceModel = _mapper.Map<Calendar, CalendarServiceModel>(calendar);

            return calendarServiceModel;
        }

        public async Task RemoveAsync(Guid id)
        {
            var calendar = await _uow.GetRepository<Calendar>()
                .GetByIdAsync(id);
            var caledarServiceModel = _mapper
                .Map<Calendar, CalendarServiceModel>(calendar);

            return await RemoveAsync(caledarServiceModel);
        }

        public async Task RemoveAsync(CalendarServiceModel entity)
        {
            var calendar = _mapper
                .Map<CalendarServiceModel, Calendar>(entity);
            _uow.GetRepository<Calendar>().Remove(calendar);

            return await _uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(CalendarCreationServiceModel entity)
        {
            Calendar calendar = _mapper.Map<CalendarCreationServiceModel, Calendar>(entity);
            _uow.GetRepository<Calendar>().Update(calendar);

            return await _uow.SaveChangesAsync();
        }

        public async Task ShareToUser(Guid calendarId, Guid userId)
        {
            var calendarUser =
                new CalendarUser
                {
                    CalendarId = calendarId,
                    UserId = userId
                };
            await _uow.GetRepository<CalendarUser>().AddAsync(calendarUser);

            return await _uow.SaveChangesAsync();
        }

        public async Task UnshareToUser(Guid calendarId, Guid userId)
        {
            var calendarUser = await _uow.GetRepository<CalendarUser>()
                .GetFirstOrDefaultAsync(cu => cu.UserId == userId
                && cu.CalendarId == calendarId);
            _uow.GetRepository<CalendarUser>().Remove(calendarUser);

            return await _uow.SaveChangesAsync();
        }
    }
}
