﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebCalendar.DAL.Models.Entities
{
    public class User : IdentityUser<Guid>, IEntity, ISoftDeletable
    {   
        public User()
        {
            CalendarUsers = new HashSet<CalendarUser>();
            Calendars = new HashSet<Calendar>();
            UserEvents = new HashSet<UserEvent>();
        }
        
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public bool IsSubscribedToNativeNotifications { get; set; }
        public bool IsSubscribedToEmailNotifications { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<CalendarUser> CalendarUsers { get; set; }
        public ICollection<Calendar> Calendars { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; }

        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}