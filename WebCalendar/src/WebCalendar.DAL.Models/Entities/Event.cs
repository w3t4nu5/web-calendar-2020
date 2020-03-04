using System;
using System.Collections.Generic;
using WebCalendar.DAL.Models.Entities.Enums;

namespace WebCalendar.DAL.Models.Entities
{
    public class Event  : IEntity, ISoftDeletable
    {
        public Event()
        {
            UserEvents = new HashSet<UserEvent>();
        }
        
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; } 
        public NotifyBeforeMode NotifyBeforeMode { get; set; }
        public RepeatMode RepeatMode { get; set; }

        public Guid CalendarId { get; set; }
        public Calendar Calendar { get; set; }

        public ICollection<UserEvent> UserEvents { get; set; }
    }
}