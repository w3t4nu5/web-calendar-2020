using System;
using Microsoft.AspNetCore.Identity;

namespace WebCalendar.DAL.Models.Entity
{
    public class User : IdentityUser<Guid>, IBaseEntity, ISoftDeletable
    {
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}