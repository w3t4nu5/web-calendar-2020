using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCalendar.Common;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.Services.Sheduler.Models;

namespace WebCalendar.Services.Sheduler.Mapper
{
    class SchedulerEventProfile : AutoMapperProfile
    {
        public SchedulerEventProfile()
        {
            CreateMap<Event, SchedulerEvent>()
               .ForMember(e => e.Users,
                   o => o.MapFrom(e => e.GetUsers()))
               .ForMember(e => e.CronExpression,
                    o => o.MapFrom(e => e.GetCronExpression()));
        }
    }
}
