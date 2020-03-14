using System.Linq;
using WebCalendar.Common;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.Services.Models.Event;

namespace WebCalendar.Services.Mapper
{
    public class EventServiceModelProfile : AutoMapperProfile
    {
        public EventServiceModelProfile()
        {
            CreateMap<EventCreationServiceModel, Event>()
                .ForMember(ue => ue.UserEvents,
                    o => o.MapFrom(c => c.SubscribedUsers.Select(su =>
                        new UserEvent
                        {
                            UserId = su.Id //NEED TO TEST IT 
                        })))
                .ForMember(e => e.EventDays,
                    o => o.MapFrom(e => e.Days));


            CreateMap<EventEditionServiceModel, Event>()
                .ForMember(ue => ue.UserEvents,
                    o => o.MapFrom(c => c.SubscribedUsers.Select(su =>
                        new UserEvent
                        {
                            UserId = su.Id,
                            EventId = c.Id
                        })))
                .ForMember(e => e.EventDays,
                    o => o.MapFrom(e => e.Days));

            CreateMap<Event, EventServiceModel>()
                .ForMember(e => e.SubscribedUsers,
                    o => o.MapFrom(e => e.UserEvents.Select(ue => ue.User)))
                .ForMember(e => e.Days,
                    o => o.MapFrom(e => e.EventDays.Select(ed =>
                        ed.Day.Value)));

            CreateMap<EventServiceModel, Event>()
                .ForMember(ue => ue.UserEvents,
                    o => o.MapFrom(c => c.SubscribedUsers.Select(su =>
                        new UserEvent
                        {
                            UserId = su.Id,
                            EventId = c.Id
                        })))
                .ForMember(e => e.EventDays,
                    o => o.MapFrom(e => e.Days)); ;
        }
    }
}