using System;

namespace WebCalendar.DAL.Models
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}