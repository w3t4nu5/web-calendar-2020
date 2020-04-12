using System;
using System.Collections.Generic;
using System.Text;
using WebCalendar.DAL.Models.Entities;

namespace WebCalendar.Services.Sheduler.Models
{
    public class SchedulerTask
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsDone { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
