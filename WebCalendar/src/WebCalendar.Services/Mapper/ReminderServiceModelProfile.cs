using System.Linq;
using WebCalendar.Common;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.Services.Models.Reminder;

namespace WebCalendar.Services.Mapper
{
    public class ReminderServiceModelProfile : AutoMapperProfile
    {
        public ReminderServiceModelProfile()
        {
            CreateMap<ReminderCreationServiceModel, Reminder>()
                .ForMember(e => e.ReminderDays,
                    o => o.MapFrom(e => e.Days));

            CreateMap<ReminderEditionServiceModel, Reminder>()
                .ForMember(e => e.ReminderDays,
                    o => o.MapFrom(e => e.Days));

            CreateMap<Reminder, ReminderServiceModel>()
                .ForMember(e => e.Days,
                    o => o.MapFrom(e => e.ReminderDays.Select(ed =>
                        ed.Day.Value)));

            CreateMap<ReminderServiceModel, Reminder>()
                .ForMember(e => e.ReminderDays,
                    o => o.MapFrom(e => e.Days));
        }
    }
}