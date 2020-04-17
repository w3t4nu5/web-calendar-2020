﻿using System;
using System.Collections.Generic;
using WebCalendar.DAL.Models;

namespace WebCalendar.Services.Models.Reminder
{
    public class ReminderCreationServiceModel// : IRepeatableActivity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? RepetitionsCount { get; set; }
        public TimeSpan NotifyAt { get; set; }
        public ICollection<int> DaysOfWeek { get; set; }
        public ICollection<int> DaysOfMounth { get; set; }
        public ICollection<int> Monthes { get; set; }
        public ICollection<int> Years { get; set; }

        public Guid CalendarId { get; set; }
    }
}