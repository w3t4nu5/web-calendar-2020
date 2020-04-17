using System;
using System.Collections.Generic;
using System.Text;
using WebCalendar.Common;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.Services.Sheduler.Contracts;
using WebCalendar.Services.Sheduler.Models;

namespace WebCalendar.Services.Sheduler.Mapper
{
    class SchedulerTaskProfile : AutoMapperProfile
    {
        public SchedulerTaskProfile()
        {
            CreateMap<Task, SchedulerTask>()
               .ForMember(e => e.Users,
                   o => o.MapFrom(e => e.GetUsers()));
        }
    }
}
