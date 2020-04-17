using System;
using System.Linq;
using WebCalendar.Common.Contracts;
using WebCalendar.DAL.EF.Context;
using WebCalendar.DAL.Models.Entities;

namespace WebCalendar.DAL.EF
{
    public class EFDataInitializer : IDataInitializer
    {
        private readonly ApplicationDbContext _context;

        public EFDataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void Seed()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            /*_context.Users.Add(new User { Id = Guid.NewGuid(), Email = "coster730@gmail.com", FirstName = "mj" });
            _context.SaveChanges();
            _context.Calendars.Add(new Calendar { Id = new Guid("60AFBD44-43F5-43A1-85F9-00E5D5513CC2"), UserId = _context.Users.First().Id });
            _context.SaveChanges();*/
        }
    }
}