using System;
using System.Collections.Generic;
using System.Text;
using WebCalendar.Common;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.Services.Sheduler.Models;

namespace WebCalendar.Services.Sheduler.Mapper
{
    class SchedulerReminderProfile : AutoMapperProfile
    {
        public SchedulerReminderProfile()
        {
            CreateMap<Reminder, SchedulerReminder>()
               .ForMember(e => e.Users,
                   o => o.MapFrom(e => e.GetUsers()))
               .ForMember(e => e.CronExpression,
                    o => o.MapFrom(e => e.GetCronExpression()));
        }
    }
}
