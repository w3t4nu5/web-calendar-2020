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

            _context.Users.Add(new User { Id = new Guid("9FF22A9D-C859-4F8C-B0D9-06C398F817BF"), Email = "cosfdfdter730@gmail.com", FirstName = "mtfgvj" });
            _context.Users.Add(new User { Id = new Guid("14EA9830-21DA-484E-8A4B-44DF662E7341"), Email = "coster730@gmail.com", FirstName = "mj" });
            _context.Users.Add(new User { Id = new Guid("E405E7BA-1203-4354-BF96-BC8E3E730C46"), Email = "cofcvter730@gmail.com", FirstName = "mjgfbcv" });
            _context.SaveChanges();
            _context.Calendars.Add(new Calendar { Id = new Guid("60AFBD44-43F5-43A1-85F9-00E5D5513CC2"), UserId = _context.Users.FirstOrDefault().Id });

            _context.SaveChanges();
        }
    }
}