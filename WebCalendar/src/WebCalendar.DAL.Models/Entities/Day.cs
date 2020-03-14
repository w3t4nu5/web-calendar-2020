using System;
using System.Collections.Generic;
using System.Text;

namespace WebCalendar.DAL.Models.Entities
{
    public class Day : IEntity, ISoftDeletable
    {
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public DayOfWeek Value { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<EventDay> EventDays { get; set; }
        public ICollection<ReminderDay> ReminderDays { get; set; }
    }
}
