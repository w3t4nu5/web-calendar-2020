﻿using System;
using System.Collections.Generic;
using WebCalendar.DAL.Models.Entities.Enums;
using WebCalendar.Services.Models.User;

namespace WebCalendar.Services.Models.Event
{
    public class EventEditionServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public NotifyBeforeMode NotifyBeforeMode { get; set; }
        public RepeatMode RepeatMode { get; set; }

        public ICollection<UserServiceModel> SubscribedUsers { get; set; }
    }
}