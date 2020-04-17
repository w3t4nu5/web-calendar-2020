using System;
using System.Collections.Generic;
using System.Text;
using WebCalendar.DAL.Models.Entities;

namespace WebCalendar.Services.Sheduler.Contracts
{
    public interface ISchedulerActivity
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public ICollection<User> Users { get; set;}
    }
}
